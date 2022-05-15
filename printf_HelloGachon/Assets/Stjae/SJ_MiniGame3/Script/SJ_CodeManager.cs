using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SJ_CodeManager : MonoBehaviour
{
    public TMP_InputField userInputCode;

    private static List<Function> funcList = new List<Function>();
    
    private class Function
    {
        private string name;
        private string body;

        public Function(string name)
        {
            this.name = name;
            funcList.Add(this);
        }

        public string getName()
        {
            return this.name;
        }
    }

    void Start()
    {
        Function add = new Function("add");
    }

    // Update is called once per frame
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
        
        if (codeSegmentRight.Length > 1 && codeSegmentRight[1] == "" && codeSegmentRight[0].Trim() == "")   // 함수 사용, 인수 X
        {
            ExecFunc(funcName);
        }

        if (codeSegmentRight[0].Trim() != "")   // 함수 사용, 인수 O
        {
            argument = codeSegmentRight[0];
            ExecFunc(funcName, argument);
        }
    }

    bool searchFunc(string funcName)
    {
        if(funcList.Exists(x => x.getName() == funcName))  // funcName 리스트 중 실행하려는 함수가 있다면 true, 없다면 false 반환
            return true;
        else
            return false;
    }

    void ExecFunc(string funcName)
    {
        if(searchFunc(funcName))
        {
            Debug.Log("function executed");
        }
        else
        {
            Debug.Log("no function found");
        }
    }

    void ExecFunc(string funcName, string argument)
    {
        if(searchFunc(funcName))
        {
            Debug.Log("function executed with arguments");
        }
        else
        {
            Debug.Log("no function found");
        }
    }

    void SplitCode(string rawCode)
    {
        string funcName = "";
        string argument = "";
        bool semiColon = false;

        // if (codeSegmentLeft != "" && codeSegments.Length > 1)   // 문자열 및 '(' 이 입력된 경우
        // {
        //     codeSegmentRight = codeSegments[1].Split(')');
        //     funcName = codeSegmentLeft;
        // }

        // if (codeSegmentRight.Length > 1 && codeSegmentRight[1] == ";")
        // {
        //     semiColon = true;
        // } else
        // {
        //     semiColon = false;
        // }
            
        // if (codeSegmentRight[0] != "")  // 인수 존재
        // {
        //     argument = codeSegmentRight[0];
        // }

        // if (funcName == "printf" && argument != "" && semiColon)
        // {
        //     // HandlePrint(argument);
        // }
    }
}
