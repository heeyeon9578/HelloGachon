using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.Text.RegularExpressions;

public class SJ_SceneManager : MonoBehaviour
{
    // external
    public SJ_DialManager dialManager;
    public SJ_CodeManager codeManager;
    public Dictionary<string, string> varDict = SJ_CodeManager.varDict;

    // internal
    string sceneName;
    public Text dialText;
    public Class currentClass;

    public class Class
    {
        public SJ_DialManager.Dialogue dialogue;
        public int dialNumber = 0;
        public int dialSize;

        public Class(SJ_DialManager.Dialogue dialogue)
        {
            this.dialogue = dialogue;
            this.dialSize = dialogue.GetDialDictSize();
        }

        public string GetDial(int dialNumber)
        {
            return dialogue.GetDial(dialNumber);
        }
    }

    void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Class_1")
            currentClass = new Class(dialManager.Dial_Class_1);
        else if(sceneName == "Class_2")
            currentClass = new Class(dialManager.Dial_Class_2);
        else if(sceneName == "Class_3")
            currentClass = new Class(dialManager.Dial_Class_3);

        dialText.text = currentClass.GetDial(0);
    }

    void Update()
    {
        dialText.text = currentClass.GetDial(currentClass.dialNumber);
    }

    public void EndCursorOnClick()
    {
        if (sceneName == "Class_1") EventHandlerClass1();
        if (sceneName == "Class_2") EventHandlerClass2();
        if (sceneName == "Class_3") EventHandlerClass3();
    }

    public void EventHandlerClass1()
    {
        switch(currentClass.dialNumber)
        {
            case 6:
                if (varDict.Count > 0)
                    ++currentClass.dialNumber;
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                {
                    ++currentClass.dialNumber;
                }
            break;
        }
    }

    public void EventHandlerClass2()
    {
        Debug.Log(SJ_CodeManager.tmpOutput.text);
        switch(currentClass.dialNumber)
        {
            case 7:
                if (SJ_CodeManager.tmpOutput.text.Trim() != "")
                    ++currentClass.dialNumber;
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                    ++currentClass.dialNumber;
            break;
        }
    }

    public void EventHandlerClass3()
    {
        switch(currentClass.dialNumber)
        {
            case 6:
                int numLines = SJ_CodeManager.tmpOutput.text.Trim().Split('\n').Length;
                if (numLines == 10)
                    ++currentClass.dialNumber;
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                    ++currentClass.dialNumber;
            break;
        }
    }
}
