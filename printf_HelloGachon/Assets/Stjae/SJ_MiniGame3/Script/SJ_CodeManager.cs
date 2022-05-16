using System;
using System.Reflection;
using System.Collections.Generic;
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

    void Start()
    {

    }

    void Update()
    {
        GetCodeLines();
    }

    void GetCodeLines()  // InputField 에 입력된 코드를 받아옴
    {
        string[] codeLines = userInputCode.text.Split('\n');
        
        foreach (string code in codeLines)
            DetectCode(code);
    }

    void DetectCode(string rawCode)   // 코드의 종류(변수, 함수, 루프..) 탐지
    {
        string[] codeSegments = rawCode.Split('(');
        string codeSegmentLeft = codeSegments[0];
        string[] codeSegmentRight = {""};
        string funcName = "";
        string argument = "";

        if (codeSegmentLeft != "" && codeSegments.Length > 1)   // 문자열 및 '(' 이 입력된 경우
        {
            codeSegmentRight = codeSegments[1].Split(')');  // ')' 기준으로 자른 오른쪽 문자열을 codeSegmentRight 변수에 대입
            funcName = codeSegmentLeft;                     // '(' 이전 문자열은 함수 이름으로 저장
        }
        
        if (codeSegmentRight.Length > 1 && codeSegmentRight[1] == "" && codeSegmentRight[0].Trim() == "")   // 인수 X
        {
            ExecFunc(funcName);
        }

        if (codeSegmentRight.Length > 1 && codeSegmentRight[1] == "" && codeSegmentRight[0].Trim() != "")   // 인수 O
        {
            argument = codeSegmentRight[0];
            ExecFunc(funcName, argument);
        }
    }

    bool searchFunc(string funcName)
    {
        if(funcList.Exists(x => x.getName() == funcName))  // funcName 리스트 중 실행하려는 함수가 있다면 true
            return true;
        else if(Array.Exists(preDefinedFunc, x => x == funcName))
            return true;
        else
            return false;
    }

    void ExecFunc(string funcName)
    {
        if(searchFunc(funcName))
        {
            Debug.Log("함수 사용, 인수 X");
            new Loop();
        }
        else
            Debug.Log("no function found");
    }

    void ExecFunc(string funcName, string argument)
    {
        if(searchFunc(funcName))
        {
            Debug.Log("함수 사용, 인수 O");
            Type funcType = Type.GetType($"SJ_CodeManager+{funcName}");
            MethodInfo methodInfo = funcType.GetMethod("Body");
            object funcObj = Activator.CreateInstance(funcType, Int32.Parse(argument));
            methodInfo.Invoke(funcObj, null);
        }
        else
            Debug.Log("no function found");
    }
}
