using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TypeGameManager_mg1 : MonoBehaviour
{
    //**타이머 변수들 선언
    public string remainingTime = @"00:00:000";
    private bool isPlaying = true;
    public Text timerTxt;
    public float setTime; //inspecter 창에서 초를 입력받음
    private float getSetTime;

    //**수강신청 게임 변수들 선언
    public FadeInOut_sk fade;
    public GameObject Register;
    public GameObject registerResult;
    public GameObject dialogPanel;
    public GameObject optionPanel;
    public List<ClassNum_mg1> classNumList;
    public string[] successTalkList;
    public string[] failTalkList;
    public Sprite[] portraitArr;
    public Sprite[] scheduleArr;
    public Text classNumTxt;
    public Text resultTxt;
    public Text dialogName;
    public Text dialogText;
    public Image portraitImg;
    public Image scheduleImg;
    public InputField inputClassNum;
    public Button applyBtn;
    public Button okBtn;
    public AudioSource successSound;
    public AudioSource failedSound;
    public AudioSource timeoverSound;
    public AudioSource typeGameBGM;
    public bool isApplyBtn = false;
    public int currentClassNum;
    public int successCnt = 0;
    private int loop = 0;
    private int index = 0;
    public float getMajor;
    public float getStress;

    void Start()
    {
        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;

        typeGameBGM.Play();
        displayClassNum();
        getSetTime = setTime;
        resetTimer();
    }

    void Update() {
        if(loop < 6)
        {
            if(isPlaying) {
                remainingTime = CountdowmTimer();
            }

            if(setTime < 0 && !isApplyBtn)
            {
                setZero();
                typeGameBGM.Stop();
                timeoverSound.Play(); 
                resultTxt.text = "타임오버!";
                registerResult.SetActive(true);
                classNumList.RemoveAt(currentClassNum);
            }

            if(isApplyBtn)
            {
                setZero();
                typeGameBGM.Stop();

                if(inputClassNum.text == classNumList[currentClassNum].classNum)
                {
                    successSound.Play();
                    resultTxt.text = "성공!";                    
                    successCnt++;
                }
                else
                {
                    failedSound.Play(); 
                    resultTxt.text = "실패!";
                }

                registerResult.SetActive(true);
                classNumList.RemoveAt(currentClassNum);
                isApplyBtn = false;           
            }        
            
            if(timerTxt) {
                timerTxt.text = remainingTime;
            }
        }
        else
        {
            typeGameBGM.Stop();
            classNumTxt.text = "";
            if(successCnt > 3)
            {
                resultTxt.text = "수강신청 성공!\n" + "성공 횟수 : " + successCnt;
            }
            else
            {
                resultTxt.text = "수강신청 실패..\n" + "성공 횟수 : " + successCnt;                
            }
            registerResult.SetActive(true);
        }
    }

    //**타이머 로직
    private string CountdowmTimer(bool isUpdate = true)
    {
        if(isUpdate) {
            setTime -= Time.deltaTime;
        }

        TimeSpan timeSpan = TimeSpan.FromSeconds(setTime);
        string timer = string.Format("{0:00}:{1:00}:{2:000}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
        return timer;
    }

    void resetTimer()
    {
        if(loop < 6)
        {
            typeGameBGM.Play();
            registerResult.SetActive(false);
            setTime = getSetTime;
            remainingTime = CountdowmTimer(true);            
            isPlaying = true;
            loop++;
            displayClassNum();
        }
        else
        {
            dialogPanel.SetActive(true);
            resultTalk();
        }        
    }

    void setZero()
    {
        remainingTime = @"00:00:000";
        setTime = 0;
        isPlaying = false;
    }

    public void openOption() {
        isPlaying = false;
        optionPanel.SetActive(true);
        typeGameBGM.Stop();
    }

    public void closeOption() {
        isPlaying = true;
        optionPanel.SetActive(false);
        typeGameBGM.Play();
    }

    //**수강신청 게임 로직
    void displayClassNum()
    {
        currentClassNum = UnityEngine.Random.Range(0, classNumList.Count);
        classNumTxt.text = classNumList[currentClassNum].className + ": " + classNumList[currentClassNum].classNum;
        //classNumList.RemoveAt(currentClassNum);
    }
    
    public void ApplyBtnClick()
    {
        isApplyBtn = true;         
    }

    public void resultTalk()
    {
        registerResult.SetActive(false);
        string playerName = GameData.gamedata.playerName;
        dialogName.text = playerName;

        if(successCnt > 3)
        {
            if(index == successTalkList.Length){
                //능력치 부여 및 저장
                getMajor += successCnt * 5;
                GameData.gamedata.major=getMajor;

                dialogPanel.SetActive(false);

                //다음 씬으로 넘어가기
                GameObject.Find("GameUI").GetComponent<FadeINOUT>().LoadFadeOut("Set_Activity_3March");
                return;
            }
            dialogText.text = successTalkList[index];
            portraitImg.sprite = portraitArr[0];
            scheduleImg.sprite = scheduleArr[0];

            dialogPanel.SetActive(true);
            index++;

            if(index == 2) {
                portraitImg.sprite = portraitArr[2];
            }
            else if (index == 3 || index == 4) {
                portraitImg.sprite = portraitArr[4];
            }
            else if (index == 5) {
                portraitImg.sprite = portraitArr[5];
            }
        }
        else
        {
            if(index == failTalkList.Length){
                //능력치 부여 및 저장
                getMajor += successCnt * 5;
                getStress += 5;
                GameData.gamedata.major=getMajor;
                GameData.gamedata.stress=getStress;

                dialogPanel.SetActive(false);
                
                //다음 씬으로 넘어가기
                GameObject.Find("GameUI").GetComponent<FadeINOUT>().LoadFadeOut("Set_Activity_3March");
                return;
            }
            dialogText.text = failTalkList[index];
            portraitImg.sprite = portraitArr[1];
            scheduleImg.sprite = scheduleArr[1];

            dialogPanel.SetActive(true);
            index++;

            if(index == 2) {
                portraitImg.sprite = portraitArr[3];
            }
            else if (index == 3 || index == 4) {
                portraitImg.sprite = portraitArr[4];
            }
            else if (index == 5) {
                portraitImg.sprite = portraitArr[5];
            }
        }
    }
}
