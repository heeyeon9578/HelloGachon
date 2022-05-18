using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class SJ_CodeManager : MonoBehaviour
{
    public TMP_InputField userInputCode;
    public static GameObject[] tmpObj;
    public static TMP_Text tmpOutput;
    public static TMP_Text tmpError;

    public static bool initConsole = false;
    public static string output = "";

    private static List<Function> funcList = new List<Function>();
    private static string[] reservedFunc = {"Loop","Print"};
    private static Dictionary<string, string> varDict = new Dictionary<string, string>();
    
    abstract class Function
    {
        protected string name;
        protected string arg_str;
        protected int arg_int;
        private bool bracket = false;
        protected string body;

        public bool requireBracket
        {
            get { return bracket; }
            set { bracket = value; }
        }

        public string bodyInput
        {
            get { return body; }
            set { body = value; }
        }

        public abstract dynamic Body(dynamic param);

        public Function()
        {

        }

        public Function(string argument)
        {
            this.arg_str = argument;
        }

        public Function(int argument)
        {
            this.arg_int = argument;
        }

        public string GetName()
        {
            return this.name;
        }
    }

    private class Loop : Function
    {
        public Loop(int argument) : base(argument)
        {
            this.arg_int = argument;
            this.requireBracket = true;
        }

        public Loop(string argument) : base(argument)
        {
            tmpError.text = "Error: function \"Loop()\" only supports integer as input";
        }

        public override dynamic Body(dynamic param)
        {
            for(int i=0; i<arg_int; i++)
            {
                TokenizeCode(body);
            }
            
            return null;
        }
    }

    private class Print : Function
    {
        public Print(int argument) : base(argument)
        {
            this.arg_int = argument;
        }

        public Print(string argument) : base(argument)
        {
            this.arg_str = argument;
        }

        public override dynamic Body(dynamic param)
        {
            output += $"{body}\n";
            UpdateOutput(output);

            return null;
        }
    }

    void Start()
    {
        tmpObj = GameObject.FindGameObjectsWithTag("TMP_text");
        tmpOutput = tmpObj[0].GetComponent<TMP_Text>();
        tmpError = tmpObj[1].GetComponent<TMP_Text>();
    }

    string prevInput = "";

    public void FetchCodeInput()  // InputField 에 입력된 코드를 받아옴
    {
        string newInput = Regex.Replace(userInputCode.text, @"\s+", string.Empty);

        if(prevInput != newInput)
        {
            output = "";
            prevInput = newInput;
            TokenizeCode(userInputCode.text);
        }
    }

    static void TokenizeCode(string inputCode)
    {
        Regex regex = new Regex(@"(\w+ *[^\d()]? *\w+)|\(([^()]*)\)|\{([\s\S]*)\}");
        MatchCollection matches = regex.Matches(inputCode);

        parseCode(matches);
    }

    static void parseCode(MatchCollection tokens)   // 코드 분석
    {
        foreach(Match token in tokens)  // Group[1]: 함수 이름, Group[2]: 함수 인풋, Group[3]: 함수 바디
        {
            // Debug.Log($"토큰 값: {token}, 다음 토큰 값: {token.NextMatch()}, {token.NextMatch().Groups[1].Success}");
            if(token.NextMatch().Groups[2].Success)     // 문자열 우측에 ()이 존재한다면 문자열로 함수를 검색
                searchFunc(token);
            else if(token.Groups[1].Success)
                OperateValue(token.Value);
        }
    }

    static void searchFunc(Match token)
    {
        if(funcList.Exists(x => x.GetName() == token.Value) || Array.Exists(reservedFunc, x => x == token.Value))
        {
            ExecFunc(token);
        }
        else
            tmpError.text = $"Error: no function name \"{token.Value}\" is found";
    }

    static void OperateValue(string value)
    {
        Regex regex = new Regex(@"\W*[^a-zA-Z\d]");
        Match match = regex.Match(value);

        int result = 0;

        string[] values;
        string Lvalue;
        string Rvalue;

        switch(match.Value)
        {
            case "=":
            values = value.Split('=');
            Lvalue = values[0].Trim();
            Rvalue = values[1].Trim();

            if(int.TryParse(Lvalue, out result))     // 좌측이 숫자일 경우
                tmpError.text = "Error: Lvalue should be string or character";
            else
            {
                try
                {
                varDict.Add(Lvalue, Rvalue);
                }
                catch
                {
                varDict[Lvalue] = Rvalue;
                }
            }
            break;
        }

        // foreach(KeyValuePair<string, string> variable in varDict)
        // {
        //     Debug.Log($"{variable.Key}, {variable.Value}");
        // }

    }

    static void ExecFunc(Match token)
    {
        string funcName = token.Value;
        int int_arg = 0;
        string str_arg = "";
        object funcObj;
        bool requireBracket = false;
        bool acquiredBracket = false;
        string varInDict = "";

        Type funcType = Type.GetType($"SJ_CodeManager+{funcName}");
        MethodInfo Body = funcType.GetMethod("Body");
        PropertyInfo bracketInfo = funcType.GetProperty("requireBracket");
        PropertyInfo bodyInfo = funcType.GetProperty("bodyInput");

        str_arg = token.NextMatch().Groups[2].Value;
        bool result = int.TryParse(str_arg, out int_arg);

        if(result)
        {
            funcObj = Activator.CreateInstance(funcType, int_arg);                                      // 함수이름과 동일한 이름을 가진 타입의 클래스 인스턴스 생성
        }
        else
            funcObj = Activator.CreateInstance(funcType, str_arg);

        requireBracket = (bool)bracketInfo.GetValue(funcObj, null);                                     // 함수가 실행되기 위해 {} 이 필요한지에 대한 여부를 받아옴
        acquiredBracket = token.NextMatch().NextMatch().Groups[3].Success;                              // {} 안의 내용을 받아옴

        if(requireBracket)
            bodyInfo.SetValue(funcObj, token.NextMatch().NextMatch().Groups[3].Value);                  // 실행할 함수의 body 정보에 {} 안의 내용을 입력
        else if(varDict.TryGetValue(token.NextMatch().Groups[2].Value, out varInDict))
            bodyInfo.SetValue(funcObj, varInDict);
        else
            bodyInfo.SetValue(funcObj, token.NextMatch().Groups[2].Value);                              // 실행할 함수의 body 정보에 () 안의 내용을 입력

        if(requireBracket && acquiredBracket == false)
        {
            tmpError.text = $"Error: function \"{funcName}()\" requires bracket";
        }
        else if(requireBracket && acquiredBracket)
        {
            Body.Invoke(funcObj, new object[] { funcObj });
        }
        else
            Body.Invoke(funcObj, new object[] { null });
    }

    static void UpdateOutput(string output)
    {
        if(tmpOutput.text != output)
        {
            tmpOutput.text = "";
            tmpOutput.text = output;
        }
    }
}
