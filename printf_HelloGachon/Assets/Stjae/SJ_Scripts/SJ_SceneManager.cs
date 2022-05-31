using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SJ_SceneManager : MonoBehaviour
{
    // external
    public SJ_DialManager dialManager;
    public SJ_CodeManager codeManager;
    public Dictionary<string, string> varDict = SJ_CodeManager.varDict;
    public List<object> funcObjList = SJ_CodeManager.objList;
    public static GameObject[] tmpObj;
    public static TMP_Text tmpOutput;
    public TMP_InputField userInputCode;

    // internal
    string month;
    public Text dialText;
    public Image optionBtn;
    public Image dialToggleBtn;
    private Color dialToggleBtnColor;
    public GameObject dialogue;
    public GameObject repeatBtn;
    public GameObject optionPanel;
    public Class currentClass;
    public AudioSource classBGM;
    public AudioSource clearSFX;
    public AudioSource passSFX;
    public AudioSource failSFX;
    public AudioSource errorSFX;

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
        tmpObj = GameObject.FindGameObjectsWithTag("TMP_text");
        tmpOutput = tmpObj[0].GetComponent<TMP_Text>();
        
        if (month == "3월")
        {
            currentClass = new Class(dialManager.Dial_Class_1);
            classBGM.Play();
        }
        else if(month == "4월")
        {
            varDict.Clear();
            currentClass = new Class(dialManager.Dial_Class_2);
            classBGM.Play();
        }
        else if(month == "중간")
        {
            varDict.Clear();
            funcObjList.Clear();
            currentClass = new Class(dialManager.Dial_Exam_1);
        }
        else if(month == "5월")
        {
            varDict.Clear();
            currentClass = new Class(dialManager.Dial_Class_3);
            classBGM.Play();
        }
        else if(month == "6월")
        {
            varDict.Clear();
            currentClass = new Class(dialManager.Dial_Class_4);
            classBGM.Play();
        }
        else if(month == "기말")
        {
            varDict.Clear();
            currentClass = new Class(dialManager.Dial_Exam_2);
        }

        dialText.text = currentClass.GetDial(0);
    }

    void Update()
    {
        dialText.text = currentClass.GetDial(currentClass.dialNumber);
    }

    public void EndCursorOnClick()
    {
        if (month == "3월") DialHandlerClass1();
        if (month == "4월") DialHandlerClass2();
        if (month == "중간") DialHandlerExam1();
        if (month == "5월") DialHandlerClass3();
        if (month == "6월") DialHandlerClass4();
        if (month == "기말") DialHandlerExam2();
    }

    public void SubmitBtnOnClick()
    {
        switch(month)
        {
            case "3월":
                if (varDict.Count > 0 && currentClass.dialNumber != 5)
                {
                    classBGM.Stop();
                    clearSFX.Play();
                    dialogue.SetActive(true);
                    repeatBtn.SetActive(false);
                    dialToggleBtn.enabled = false;
                    currentClass.dialNumber = currentClass.dialSize-1;
                }
                else
                    errorSFX.Play();
            break;

            case "4월":
                if (SJ_CodeManager.tmpOutput.text.Trim() != "" && currentClass.dialNumber != 6)
                {
                    classBGM.Stop();
                    clearSFX.Play();
                    dialogue.SetActive(true);
                    repeatBtn.SetActive(false);
                    dialToggleBtn.enabled = false;
                    currentClass.dialNumber = currentClass.dialSize-1;
                }
                else
                    errorSFX.Play();
            break;

            case "중간":
                List<string> stringArgumentList = new List<string>();
                Type funcType = Type.GetType($"SJ_CodeManager+Print");
                PropertyInfo stringArgumentInfo = funcType.GetProperty("stringArgument");

                foreach(object obj in funcObjList)
                {
                    stringArgumentList.Add((string)stringArgumentInfo.GetValue(funcObjList[0], null));
                }

                string variable = "";
                foreach(string str in stringArgumentList)
                {
                    bool result = false;
                    try
                    {
                        result = varDict.TryGetValue(str, out variable);
                        Debug.Log(str);
                    }
                    catch {}
                    
                    if (result)
                    {
                        dialogue.SetActive(true);
                        dialToggleBtn.enabled = false;
                        currentClass.AddDial(1, "<color=blue>정답입니다!</color>\n(전공 +15, 중간고사 점수: 100)");
                        passSFX.Play();
                        ++currentClass.dialNumber;
                        ModGameDataAfterExam1(true);
                    }
                    else
                    {
                        Debug.Log(variable);
                        dialogue.SetActive(true);
                        dialToggleBtn.enabled = false;
                        currentClass.AddDial(1, "<color=red>틀렸습니다..</color>\n(전공 +5, 스트레스 +10, 중간고사 점수: 50)");
                        failSFX.Play();
                        ++currentClass.dialNumber;
                        ModGameDataAfterExam1(false);
                    }
                }
            break;

            case "5월":
                int numLines = SJ_CodeManager.tmpOutput.text.Trim().Split('\n').Length;
                if (numLines == 10)
                {
                    classBGM.Stop();
                    clearSFX.Play();
                    dialogue.SetActive(true);
                    repeatBtn.SetActive(false);
                    dialToggleBtn.enabled = false;
                    currentClass.dialNumber = currentClass.dialSize-1;
                }
                else
                    errorSFX.Play();
            break;

            case "6월":
                string output = SJ_CodeManager.tmpOutput.text.Trim();
                string newLine = "\n";
                int newLineNumber = output.Length - output.Replace(newLine, "").Length;
                newLineNumber = newLineNumber / newLine.Length;
                string finalOutput = SJ_CodeManager.tmpOutput.text.Trim().Replace("\n", "");
                if (newLineNumber == 7 && finalOutput == "yeeeyeee")
                {
                    classBGM.Stop();
                    clearSFX.Play();
                    dialogue.SetActive(true);
                    repeatBtn.SetActive(false);
                    dialToggleBtn.enabled = false;
                    currentClass.dialNumber = currentClass.dialSize-1;
                }
                else
                    errorSFX.Play();
            break;

            case "기말":
                string output1 = SJ_CodeManager.tmpOutput.text.Trim();
                string newLine1 = "\n";
                int newLineNumber1 = output1.Length - output1.Replace(newLine1, "").Length;
                newLineNumber1 = newLineNumber1 / newLine1.Length;
                string finalOutput1 = SJ_CodeManager.tmpOutput.text.Trim().Replace("\n", "");
                if (newLineNumber1 == 8 && finalOutput1 == "yeeYeeYee")
                {
                    dialogue.SetActive(true);
                    dialToggleBtn.enabled = false;
                    currentClass.AddDial(1, "<color=blue>정답입니다!</color>\n(전공 +15, 기말고사 점수: 100)");
                    passSFX.Play();
                    ++currentClass.dialNumber;
                    ModGameDataAfterExam2(true);
                }
                else
                {
                    dialogue.SetActive(true);
                    dialToggleBtn.enabled = false;
                    currentClass.AddDial(1, "<color=red>틀렸습니다..</color>\n(전공 +5, 스트레스 + 10, 기말고사 점수: 50)");
                    failSFX.Play();
                    ++currentClass.dialNumber;
                    ModGameDataAfterExam2(false);
                }
            break;
        }
    }

    public void DialHandlerClass1()
    {
        switch(currentClass.dialNumber)
        {
            case 7:
                dialogue.SetActive(false);
                GameData.gamedata.month = "4월";
                ModGameDataAfterClass();
                Debug.Log("3월 수업 종료");
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Group");
            break;

            default:
                if (currentClass.dialNumber == 4)
                {
                    userInputCode.text = "x=1";
                }
                if (currentClass.dialNumber == 5)
                {
                    userInputCode.text = "";
                    repeatBtn.SetActive(true);
                }
                if (currentClass.dialNumber < currentClass.dialSize-2)
                    ++currentClass.dialNumber;
                else
                    DialToggleBtnOnClick();
            break;
        }
    }

    public void DialHandlerClass2()
    {
        switch(currentClass.dialNumber)
        {
            case 8:
                dialogue.SetActive(false);
                GameData.gamedata.month = "중간";
                ModGameDataAfterClass();
                Debug.Log("4월 수업 종료");
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeMonth4");
            break;

            default:
                if (currentClass.dialNumber == 5)
                {
                    userInputCode.text = "print(안녕)";
                }
                if (currentClass.dialNumber == 6)
                {
                    userInputCode.text = "";
                    tmpOutput.text = "";
                    repeatBtn.SetActive(true);
                }
                if (currentClass.dialNumber < currentClass.dialSize-2)
                    ++currentClass.dialNumber;
                else
                    DialToggleBtnOnClick();
            break;
        }
    }

    public void DialHandlerExam1()
    {
        if (currentClass.dialNumber == 1)
        {
            dialogue.SetActive(false);
            GameData.gamedata.month = "5월";
            ModGameDataAfterClass();
            Debug.Log("중간고사 종료");
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Set_Activity_5May");
        }
        else if (currentClass.dialNumber < currentClass.dialSize-1)
            ++currentClass.dialNumber;
        else
            DialToggleBtnOnClick();
    }

    public void DialHandlerClass3()
    {
        switch(currentClass.dialNumber)
        {
            case 7:
                dialogue.SetActive(false);
                GameData.gamedata.month = "6월";
                ModGameDataAfterClass();
                Debug.Log("5월 수업 종료");
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Set_Activity_6June");
            break;

            default:
                if (currentClass.dialNumber == 4)
                {
                    userInputCode.text = "loop(5)\n{\n  <color=blue>반복하고 싶은 명령문</color>\n}";
                }
                if (currentClass.dialNumber == 5)
                {
                    userInputCode.text = "";
                    tmpOutput.text = "";
                    repeatBtn.SetActive(true);
                }
                if (currentClass.dialNumber < currentClass.dialSize-2)
                    ++currentClass.dialNumber;
                else
                    DialToggleBtnOnClick();
            break;
        }
    }

    public void DialHandlerClass4()
    {
        switch(currentClass.dialNumber)
        {
            case 6:
                dialogue.SetActive(false);
                GameData.gamedata.month = "기말";
                ModGameDataAfterClass();
                Debug.Log("6월 수업 종료");
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom5_2");
            break;

            default:
                if (currentClass.dialNumber == 3)
                {
                    userInputCode.text = "loop(2)\n{\n  <color=blue>반복하고 싶은 명령문1</color>\n  loop(3)\n  {\n    <color=blue>반복하고 싶은 명령문2</color>\n  }\n}";
                }
                if (currentClass.dialNumber == 4)
                {
                    userInputCode.text = "";
                    tmpOutput.text = "";
                    repeatBtn.SetActive(true);
                }
                if (currentClass.dialNumber < currentClass.dialSize-2)
                    ++currentClass.dialNumber;
                else
                    DialToggleBtnOnClick();
            break;
        }
    }

    public void DialHandlerExam2()
    {
        if (currentClass.dialNumber == 1)
        {
            dialogue.SetActive(false);
            GameData.gamedata.month = "방학";
            ModGameDataAfterClass();
            Debug.Log("기말고사 종료");
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom6");
        }
        else if (currentClass.dialNumber < currentClass.dialSize-1)
            ++currentClass.dialNumber;
        else
            DialToggleBtnOnClick();
    }

    void ModGameDataAfterClass()
    {
        GameData.gamedata.major += 5;
        GameData.gamedata.health -= 2;
        GameData.gamedata.stress += 5;

        //능력치 보정
        //전공
        if(GameData.gamedata.major>100){GameData.gamedata.major=100;}
        else if(GameData.gamedata.major<0){GameData.gamedata.major=0;}
        //체력
        if(GameData.gamedata.health>100){GameData.gamedata.health=100;}
        else if(GameData.gamedata.health<0){GameData.gamedata.health=0;}
        //알코올 분해력
        if(GameData.gamedata.alchol>100){GameData.gamedata.alchol=100;}
        else if(GameData.gamedata.alchol<0){GameData.gamedata.alchol=0;}
        //인기도
        if(GameData.gamedata.popular>100){GameData.gamedata.popular=100;}
        else if(GameData.gamedata.popular<0){GameData.gamedata.popular=0;}
        //스트레스
        if(GameData.gamedata.stress<0){GameData.gamedata.stress=0;}
        else if(GameData.gamedata.stress>100){GameData.gamedata.stress=100;}
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
            GameData.gamedata.major += 5;
            GameData.gamedata.stress += 10;
            GameData.gamedata.scoreExam1 += 50;
        }

        //능력치 보정
        //전공
        if(GameData.gamedata.major>100){GameData.gamedata.major=100;}
        else if(GameData.gamedata.major<0){GameData.gamedata.major=0;}
        //체력
        if(GameData.gamedata.health>100){GameData.gamedata.health=100;}
        else if(GameData.gamedata.health<0){GameData.gamedata.health=0;}
        //알코올 분해력
        if(GameData.gamedata.alchol>100){GameData.gamedata.alchol=100;}
        else if(GameData.gamedata.alchol<0){GameData.gamedata.alchol=0;}
        //인기도
        if(GameData.gamedata.popular>100){GameData.gamedata.popular=100;}
        else if(GameData.gamedata.popular<0){GameData.gamedata.popular=0;}
        //스트레스
        if(GameData.gamedata.stress<0){GameData.gamedata.stress=0;}
        else if(GameData.gamedata.stress>100){GameData.gamedata.stress=100;}
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
            GameData.gamedata.major += 5;
            GameData.gamedata.stress += 10;
            GameData.gamedata.scoreExam2 += 50;
        }

        //능력치 보정
        //전공
        if(GameData.gamedata.major>100){GameData.gamedata.major=100;}
        else if(GameData.gamedata.major<0){GameData.gamedata.major=0;}
        //체력
        if(GameData.gamedata.health>100){GameData.gamedata.health=100;}
        else if(GameData.gamedata.health<0){GameData.gamedata.health=0;}
        //알코올 분해력
        if(GameData.gamedata.alchol>100){GameData.gamedata.alchol=100;}
        else if(GameData.gamedata.alchol<0){GameData.gamedata.alchol=0;}
        //인기도
        if(GameData.gamedata.popular>100){GameData.gamedata.popular=100;}
        else if(GameData.gamedata.popular<0){GameData.gamedata.popular=0;}
        //스트레스
        if(GameData.gamedata.stress<0){GameData.gamedata.stress=0;}
        else if(GameData.gamedata.stress>100){GameData.gamedata.stress=100;}
    }

    public void OptionBtnOnClick()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
    }

    public void RepeatBtnOnClick()
    {
        currentClass.dialNumber = 1;
        repeatBtn.SetActive(false);
    }

    public void DialToggleBtnOnClick()
    {
        dialToggleBtnColor = dialToggleBtn.color;
        dialToggleBtnColor.a = Math.Abs(dialToggleBtnColor.a - 1.5f);
        dialToggleBtn.color = dialToggleBtnColor;
        dialogue.SetActive(!dialogue.activeSelf);
    }
}
