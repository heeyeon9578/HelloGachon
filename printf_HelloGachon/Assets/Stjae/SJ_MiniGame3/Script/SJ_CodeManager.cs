using System;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;

public class SJ_CodeManager : MonoBehaviour
{
    public TMP_InputField userInputCode;

    private static List<Function> funcList = new List<Function>();
    private string[] reservedFunc = {"Loop"};
    
    abstract class Function
    {
        protected string name;
        protected string arg_str;
        protected int arg_int;
        private bool bracket;

        public bool requireBracket
        {
            get
            {
                return bracket;
            }
            set
            {
                bracket = value;
            }
        }

        public abstract dynamic Body();

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
        private int num = 0;

        public Loop()
        {
            this.num++;
        }

        public Loop(int argument) : base(argument)
        {
            this.arg_int = argument;
            this.num++;
            this.requireBracket = true;
        }

        public Loop(string argument) : base(argument)
        {
            Debug.Log("Loop() only supports integer as input");
        }

        public override dynamic Body()
        {
            for(int i = 0; i < arg_int; i++)
            {
                Debug.Log($"Loop {i}");
            }
            return null;
        }
    }

    // public struct CodeContext
    // {
    //     public bool isFunction;     // 함수의 사용인지 정의인지 판단필요
    //     public bool isAssignment;
    //     public bool isOperation;

    //     public string funcName;
    //     public string argument;
    // }

    // void Start()
    // {

    // }

    // void Update()
    // {

    // }
    string prevInput = "";

    public void FetchCodeInput()  // InputField 에 입력된 코드를 받아옴
    {
        string newInput = Regex.Replace(userInputCode.text, @"\s+", string.Empty);
        if(prevInput != newInput)
        {
            prevInput = newInput;
            TokenizeCode(userInputCode.text);
        }
    }

    void TokenizeCode(string inputCode)
    {
        Regex regex = new Regex(@"(\w+\-*)|\(([^()]*)\)|\{([^{}]*)\}");
        MatchCollection matches = regex.Matches(inputCode);

        parseCode(matches);
    }

    void parseCode(MatchCollection tokens)   // 코드의 종류(변수, 함수, 루프..) 분석
    {
        // CodeContext context = new CodeContext();    // 코드 정보(함수이름, 인자 등)를 저장

        foreach(Match token in tokens)  // Group[1]: 함수 이름, Group[2]: 함수 인풋, Group[3]: 함수 바디
        {
            // Debug.Log($"토큰 값: {token}, 다음 토큰 값: {token.NextMatch()}");
            if(token.NextMatch().Groups[2].Success)
                searchFunc(token);
        }
    }

    void searchFunc(Match token)
    {
        if(funcList.Exists(x => x.GetName() == token.Value) || Array.Exists(reservedFunc, x => x == token.Value))
            ExecFunc(token);
        else
            Debug.Log("No Function Found");
    }

    void ExecFunc(Match token)
    {
        string funcName = token.Value;
        int int_arg = 0;
        object funcObj;
        bool requireBracket = false;
        bool acquiredBracket = false;

        Type funcType = Type.GetType($"SJ_CodeManager+{funcName}");
        MethodInfo Body = funcType.GetMethod("Body");
        PropertyInfo propInfo = funcType.GetProperty("requireBracket");

        string str_arg = token.NextMatch().Groups[2].Value;
        // Debug.Log(str_arg);

        bool result = int.TryParse(str_arg, out int_arg);
        if(result)
        {
            funcObj = Activator.CreateInstance(funcType, int_arg);      // funcName 과 동일한 이름을 가진 타입의 클래스 인스턴스 생성
        }
        else
            funcObj = Activator.CreateInstance(funcType, str_arg);

        requireBracket = (bool)propInfo.GetValue(funcObj, null);
        acquiredBracket = token.NextMatch().NextMatch().Groups[3].Success;

        if(requireBracket && acquiredBracket == false)
        {
            Debug.Log($"function {funcName} require bracket");
        }
        else if(requireBracket && acquiredBracket)
        {
            Body.Invoke(funcObj, null);
        }
        else
            Body.Invoke(funcObj, null);
    }
}
