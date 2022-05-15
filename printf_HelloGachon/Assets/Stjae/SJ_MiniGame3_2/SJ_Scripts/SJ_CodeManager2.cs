using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJ_CodeManager2 : MonoBehaviour
{
    public InputField funcBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetCodeLines();
    }

    void GetCodeLines()  // scene에 입력된 코드를 텍스트 형태로 받아옴
    {
        string[] codeLines = funcBody.text.Split('\n');
        
        foreach (string code in codeLines)
            SplitCode(code);
    }

    void SplitCode(string rawCode)
    {
        string[] codeSegments = rawCode.Split('(');
        string codeSegmentLeft = codeSegments[0];
        string[] codeSegmentRight = {""};
        bool semiColon = false;

        string funcName = "";
        string argument = "";

        if (codeSegmentLeft != "" && codeSegments.Length > 1)   // 문자열 및 '(' 이 입력된 경우
        {
            codeSegmentRight = codeSegments[1].Split(')');
            funcName = codeSegmentLeft;
        }

        if (codeSegmentRight.Length > 1 && codeSegmentRight[1] == ";")
        {
            semiColon = true;
        } else
        {
            semiColon = false;
        }
            
        if (codeSegmentRight[0] != "")  // 인수 존재
        {
            argument = codeSegmentRight[0];
        }

        if (funcName == "printf" && argument != "" && semiColon)
        {
            HandlePrint(argument);
        }
    }

    void HandlePrint(string argument)
    {
        var output = GameObject.Find("Output").GetComponent<UnityEngine.UI.Text>();
        output.text = argument;
    }
}
