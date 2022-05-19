using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SJ_SceneManager : MonoBehaviour
{
    // external
    public SJ_DialManager dialManager;
    public SJ_CodeManager codeManager;
    public Dictionary<string, string> varDict = SJ_CodeManager.varDict;
    public List<object> funcObjList = SJ_CodeManager.objList;

    // internal
    string month;
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

        public void AddDial(int key, string value)
        {
            dialogue.AddDial(key, value);
        }

        public string GetDial(int dialNumber)
        {
            return dialogue.GetDial(dialNumber);
        }
    }

    void Awake()
    {
        month = GameData.gamedata.month;
    }

    void Start()
    {
        if (month == "3월")
            currentClass = new Class(dialManager.Dial_Class_1);
        else if(month == "4월")
            currentClass = new Class(dialManager.Dial_Class_2);
        else if(month == "중간")
            currentClass = new Class(dialManager.Dial_Exam_1);
        else if(month == "5월")
            currentClass = new Class(dialManager.Dial_Class_3);
        else if(month == "6월")
            currentClass = new Class(dialManager.Dial_Class_4);
        else if(month == "기말")
            currentClass = new Class(dialManager.Dial_Exam_2);

        dialText.text = currentClass.GetDial(0);
    }

    void Update()
    {
        dialText.text = currentClass.GetDial(currentClass.dialNumber);
    }

    public void EndCursorOnClick()
    {
        if (month == "3월") EventHandlerClass1();
        if (month == "4월") EventHandlerClass2();
        if (month == "중간") EventHandlerExam1();
        if (month == "5월") EventHandlerClass3();
        if (month == "6월") EventHandlerClass4();
        if (month == "기말") EventHandlerExam2();
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
                    ++currentClass.dialNumber;
                else
                {
                    GameData.gamedata.month = "4월";
                    ModGameDataAfterClass();
                    Debug.Log("3월 수업 종료");
                    SceneManager.LoadScene("Group");
                }
            break;
        }
    }

    public void EventHandlerClass2()
    {
        switch(currentClass.dialNumber)
        {
            case 7:
                if (SJ_CodeManager.tmpOutput.text.Trim() != "")
                    ++currentClass.dialNumber;
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                    ++currentClass.dialNumber;
                else
                {
                    GameData.gamedata.month = "중간";
                    ModGameDataAfterClass();
                    Debug.Log("4월 수업 종료");
                    SceneManager.LoadScene("heeMonth4");
                }
            break;
        }
    }

    public void EventHandlerExam1()
    {
        List<string> stringArgumentList = new List<string>();
        Type funcType = Type.GetType($"SJ_CodeManager+Print");
        PropertyInfo stringArgumentInfo = funcType.GetProperty("stringArgument");

        foreach(object obj in funcObjList)
        {
            stringArgumentList.Add((string)stringArgumentInfo.GetValue(funcObjList[0], null));
        }

        switch(currentClass.dialNumber)
        {
            case 0:
                string variable = "";
                foreach(string str in stringArgumentList)
                {
                    bool result = false;
                    try
                    {
                        result = varDict.TryGetValue(str, out variable);
                    }
                    catch {}
                    
                    if (result)
                    {
                        currentClass.AddDial(1, "<color=blue>정답입니다!</color>");
                        ++currentClass.dialNumber;
                        ModGameDataAfterExam1(true);
                    }
                    else
                    {
                        currentClass.AddDial(1, "<color=red>틀렸습니다!</color>");
                        ++currentClass.dialNumber;
                        ModGameDataAfterExam1(false);
                    }
                }
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                    ++currentClass.dialNumber;
                else
                {
                    GameData.gamedata.month = "5월";
                    ModGameDataAfterClass();
                    Debug.Log("중간고사 종료");
                    SceneManager.LoadScene("Set_Activity_May");
                }
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
                else
                {
                    GameData.gamedata.month = "6월";
                    ModGameDataAfterClass();
                    Debug.Log("5월 수업 종료");
                    SceneManager.LoadScene("heeMonth4");
                }
            break;
        }
    }

    public void EventHandlerClass4()
    {       
        switch(currentClass.dialNumber)
        {
            case 5:
                string output = SJ_CodeManager.tmpOutput.text.Trim();
                string newLine = "\n";
                int newLineNumber = output.Length - output.Replace(newLine, "").Length;
                newLineNumber = newLineNumber / newLine.Length;
                string finalOutput = SJ_CodeManager.tmpOutput.text.Trim().Replace("\n", "");
                if (newLineNumber == 7 && finalOutput == "yeeeyeee")
                    ++currentClass.dialNumber;
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                    ++currentClass.dialNumber;
                else
                {
                    GameData.gamedata.month = "기말";
                    ModGameDataAfterClass();
                    Debug.Log("6월 수업 종료");
                    SceneManager.LoadScene("MiniGame3");
                }
            break;
        }
    }

    public void EventHandlerExam2()
    {
        switch(currentClass.dialNumber)
        {
            case 0:
                string output = SJ_CodeManager.tmpOutput.text.Trim();
                string newLine = "\n";
                int newLineNumber = output.Length - output.Replace(newLine, "").Length;
                newLineNumber = newLineNumber / newLine.Length;
                string finalOutput = SJ_CodeManager.tmpOutput.text.Trim().Replace("\n", "");
                if (newLineNumber == 8 && finalOutput == "yeeYeeYee")
                {
                    currentClass.AddDial(1, "<color=blue>정답입니다!</color>");
                    ++currentClass.dialNumber;
                    ModGameDataAfterExam2(true);
                }
                else
                {
                    currentClass.AddDial(1, "<color=red>틀렸습니다!</color>");
                    ++currentClass.dialNumber;
                    ModGameDataAfterExam2(false);
                }
            break;

            default:
                if (currentClass.dialNumber < currentClass.dialSize-1)
                    ++currentClass.dialNumber;
                else
                {
                    GameData.gamedata.month = "방학";
                    ModGameDataAfterClass();
                    Debug.Log("기말고사 종료");
                    SceneManager.LoadScene("heeRoom6");
                }
            break;
        }
    }

    void ModGameDataAfterClass()
    {
        GameData.gamedata.major += 5;
        GameData.gamedata.health -= 5;
        GameData.gamedata.stress += 5;
    }

    void ModGameDataAfterExam1(bool correct)
    {
        if (correct)
        {
            GameData.gamedata.major += 15;
            GameData.gamedata.scoreExam1 += 100;
        } 
        else
        {
            GameData.gamedata.stress += 10;
            GameData.gamedata.scoreExam1 += 50;
        }
    }

    void ModGameDataAfterExam2(bool correct)
    {
        if (correct)
        {
            GameData.gamedata.major += 15;
            GameData.gamedata.scoreExam2 += 100;
        } 
        else
        {
            GameData.gamedata.stress += 10;
            GameData.gamedata.scoreExam2 += 50;
        }
    }
}
