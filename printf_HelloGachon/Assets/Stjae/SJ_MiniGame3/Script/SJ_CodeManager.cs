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
    private string[] preDefinedFunc = {"Loop"};
    
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

        public string getName()
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

    public struct CodeContext
    {
        public bool isFunction;     // 함수의 사용인지 정의인지 판단필요
        public bool isAssignment;
        public bool isOperation;

        public string funcName;
        public string argument;
    }

    // void Start()
    // {

    // }

    // void Update()
    // {

    // }

    public void FetchCodeInput()  // InputField 에 입력된 코드를 받아옴
    {
        TokenizeCode(userInputCode.text);
    }

    void TokenizeCode(string inputCode)
    {
        Regex regex = new Regex(@"(\w+\-*)|\(([^()]*)\)|\{([^{}]*)\}");
        MatchCollection matches = regex.Matches(inputCode);

        foreach(Match match in matches)
            Regex.Replace(match.Value, @"\s", "");

        parseCode(matches);
    }

    void parseCode(MatchCollection tokens)   // 코드의 종류(변수, 함수, 루프..) 분석
    {
        CodeContext context = new CodeContext();    // 코드 정보(함수이름, 인자 등)를 저장

        foreach(Match token in tokens)  // Group[1]: 함수 이름, Group[2]: 함수 인풋, Group[3]: 함수 바디
        {
            Debug.Log($"토큰 값: {token.Value}, 다음 토큰 값: {token.NextMatch()}");
        }

        // List<string> nameTokens = new List<string>();

        // if (codeSegmentLeft != "" && codeSegments.Length > 1)   // 문자열 및 '(' 이 입력된 경우
        // {
        //     codeSegmentRight = codeSegments[1].Split(')');  // ')' 기준으로 자른 오른쪽 문자열을 codeSegmentRight 변수에 대입
        //     funcName = codeSegmentLeft;                     // '(' 이전 문자열은 함수 이름으로 저장

        //     codeContext.funcName = funcName;
        // }
        
        // if (codeSegmentRight.Length > 1 && codeSegmentRight[0].Trim() == "")  // 인수 X
        // {
        //     codeContext.codeNextFunc = codeSegmentRight[1];

        //     searchFunc(codeContext);
        // }

        // if (codeSegmentRight.Length > 1 && codeSegmentRight[0].Trim() != "")   // 인수 O
        // {
        //     argument = codeSegmentRight[0];

        //     codeContext.argument = argument;
        //     codeContext.codeNextFunc = codeSegmentRight[1];

        //     searchFunc(codeContext);
        // }
    }

    void searchFunc(CodeContext code)
    {
        if(funcList.Exists(x => x.getName() == code.funcName) || Array.Exists(preDefinedFunc, x => x == code.funcName))
            ExecFunc(code);
        else
            Debug.Log("No Function Found");
    }

    void ExecFunc(CodeContext code)
    {
        int int_arg = 0;
        object funcObj;
        bool requireBracket = false;

        Type funcType = Type.GetType($"SJ_CodeManager+{code.funcName}");
        MethodInfo methodInfo = funcType.GetMethod("Body");
        PropertyInfo propInfo = funcType.GetProperty("requireBracket");

        bool result = int.TryParse(code.argument, out int_arg);
        if(result)
        {
            funcObj = Activator.CreateInstance(funcType, int_arg);      // funcName 과 동일한 이름을 가진 타입의 클래스 인스턴스를 동적 생성
        }
        else
            funcObj = Activator.CreateInstance(funcType, code.argument);

        methodInfo.Invoke(funcObj, null);
        requireBracket = (bool)propInfo.GetValue(funcObj, null);

        if(requireBracket)
        {
            
        }
    }
}
