using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetActivityManager_sk : MonoBehaviour
{
    public int Count = 5;
    public GameObject clubBtn;
    public Text majortext;
    public Text stresstext;
    public Text healthtext;
    public Text populartext;
    public Text alcholtext;
    public Text infoTxt;
    public GameObject w1Panel;
    public Text w1Txt;
    public GameObject w2Panel;
    public Text w2Txt;
    public GameObject w3Panel;
    public Text w3Txt;
    public GameObject w4Panel;
    public Text w4Txt;
    public GameObject w5Panel;
    public Text w5Txt;
    public float getHealth;
    public float getPopular;
    public float getStress;
    public float getMajor;
    public float getAlchol;
    public string getGroup; 
    private Color32 activityColor;
    private string activityName;
    public GameObject schedulePanel;
    public GameObject activityPanel;
    public GameObject player;
    public GameObject healthTalk;
    public GameObject touchTalk;
    public AudioSource touchSound;
    public AudioSource resetSound;
    public AudioSource decideSound;
    
    void Start()
    {
        //GameData 사용 시 코드
        majortext.text="전공 : "+GameData.gamedata.major;
        stresstext.text="스트레스 : "+GameData.gamedata.stress;
        healthtext.text="체력 : "+GameData.gamedata.health;
        populartext.text="인기도 : "+GameData.gamedata.popular;
        alcholtext.text="알코올 분해력 : "+GameData.gamedata.alchol;
        infoTxt.text = "버튼을 클릭해 이번 달의 계획들을 정해보세요!\n- 활동에 따라 다른 능력치를 얻을 수 있습니다.\n- 체력이 0이 되면 더 이상 활동을 할 수 없습니다.\n- 리셋버튼으로 활동을 초기화 할 수 있습니다.";

        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;

        if(GameData.gamedata.groupname!="")
            clubBtn.SetActive(true);
            getGroup=GameData.gamedata.groupname;

        schedulePanel.SetActive(true);
        activityPanel.SetActive(true);
        player.SetActive(true);
    }

    private void Update() {

        majortext.text="전공 : "+getMajor;
        stresstext.text="스트레스 : "+getStress;
        healthtext.text="체력 : "+getHealth;
        populartext.text="인기도 : "+getPopular;
        alcholtext.text="알코올 분해력 : "+getAlchol;
        if(getMajor<0)
            getMajor=0;
        if(getStress<0)
            getStress=0;
        if(getHealth<0)
            getHealth=0;
        if(getPopular<0)
            getPopular=0;
        if(getAlchol<0)
            getAlchol=0;

        if(getHealth < 5) {
            healthTalk.SetActive(true);
            touchTalk.SetActive(false);
        }
        else {
            healthTalk.SetActive(false);
            touchTalk.SetActive(true);
        }
    }
    public void abilityChange(string type)
    {
        switch(type)
        {
            case "Drink":
                if(Count>0&&getHealth>4)
                {
                    touchSound.Play();
                    Count--;
                    getHealth-=3;
                    getAlchol+=10;
                    getPopular+=8;
                    getMajor-=3;

                    activityColor = new Color32(138, 255, 143, 255);
                    activityName = "술약속";
                    infoTxt.text = "술약속\n오늘 먹고 죽는거야~~~\n전공 -3, 인기도 +8,\n체력 -3, 알코올 분해력 +10";
                }
                break;
            case "Health":
                if(Count>0)
                {
                    touchSound.Play();
                    Count--;
                    getHealth+=10;
                    getStress-=5;

                    activityColor = new Color32(255, 99, 88, 225);
                    activityName = "운동";
                    infoTxt.text = "운동\n코딩하려면 일단 살아는 있어야겠지\n체력 +10, 스트레스 -5,";
                }
                break;
            case "Study":
                if(Count>0&&getHealth>4)
                {
                    touchSound.Play();
                    Count--;
                    getHealth-=2;
                    getStress+=4;
                    getMajor+=8;

                    activityColor = new Color32(104, 142, 225, 225);
                    activityName = "스터디";
                    infoTxt.text = "스터디\n공부에는 왕도가 없다!\n전공 +8, 체력 -2,\n스트레스 +4";
                }
                break;
            case "Interest":
                if(Count>0&&getHealth>4)
                {
                    touchSound.Play();
                    Count--;
                    getHealth-=2;
                    getStress-=6;
                    getPopular+=6;

                    activityColor = new Color32(255, 227, 88, 255);
                    activityName = "취미\n활동";
                    infoTxt.text = "취미 활동\n하고 싶었던거 다 해볼거야!!\n인기도 +6, 체력 -2,\n스트레스 -6";
                }
                break;
            case "Club":
                if(Count>0)
                {
                    if(getGroup=="Music"&&getHealth>2)
                    {
                        Count--;
                        getStress-=5;
                        getHealth-=2;
                        getPopular+=5;
                        getAlchol+=6;
                        infoTxt.text = "음악 동아리\n동방가서 누워서 기타쳐야지~\n인기도 +5, 체력 -2,\n스트레스 -5, 알코올 분해력 +6";
                    }
                    else if(getGroup=="Religion"&&getHealth>2)
                    {
                        Count--;
                        getStress-=7;
                        getHealth-=2;
                        getAlchol-=5;
                        infoTxt.text = "종교 동아리\n비나이다 비나이다 오류없이 실행되게 해주세요\n체력 -2, 스트레스 -7,\n알코올 분해력 -5";
                    }
                    else if(getGroup=="Major"&&getHealth>2)
                    {
                        Count--;
                        getHealth-=2;
                        getMajor+=8;
                        getStress+=4;
                        getAlchol+=7;
                        infoTxt.text = "학술 동아리\n동아리 친구들이랑 공부하다 술마시러 가야지~\n전공 +8, 체력 -2,\n스트레스 -4, 알코올 분해력 +7";
                    }
                    else if(getGroup=="Health")
                    {
                        Count--;
                        getStress-=5;
                        getHealth+=8;
                        getAlchol-=3;
                        infoTxt.text = "운동 동아리\n아 근손실은 못참지 ㅋㅋ\n체력 +8, 스트레스 -5,\n알코올 분해력 -3";
                    }
                    else if(getGroup=="Performance"&&getHealth>4)
                    {
                        Count--;
                        getStress-=5;
                        getHealth-=4;
                        getPopular+=8;
                        getAlchol+=6;
                        infoTxt.text = "공연 동아리\n동아리 공연 준비해야지~\n인기도 +8, 체력 -4,\n스트레스 -5, 알코올 분해력 +6";
                    }
                    else if(getGroup=="Hobby"&&getHealth>2)
                    {
                        Count--;
                        getStress-=4;
                        getHealth-=2;
                        getAlchol+=8;
                        infoTxt.text = "취미 동아리\n오늘은 동아리 친구들이랑 뭘 해볼까나~?\n체력 -2, 스트레스 -7,\n알코올 분해력 +8";
                    }

                    touchSound.Play();
                    activityColor = new Color32(255, 167, 236, 225);
                    activityName = "동아리";
                }
                break;
            default: break;
        }

        if(Count == 4) {
            w1Panel.GetComponent<Image>().color = activityColor;
            w1Txt.text = activityName;
        }
        else if(Count == 3) {
            w2Panel.GetComponent<Image>().color = activityColor;
            w2Txt.text = activityName;
        }
        else if(Count == 2) {
            w3Panel.GetComponent<Image>().color = activityColor;
            w3Txt.text = activityName;
        }
        else if(Count == 1) {
            w4Panel.GetComponent<Image>().color = activityColor;
            w4Txt.text = activityName;
        }
        else if(Count == 0) {
            w5Panel.GetComponent<Image>().color = activityColor;
            w5Txt.text = activityName;
        }
    }

    public void resetChange()
    {
        resetSound.Play();
        Count = 5;

        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;
        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        
        /*
        getMajor = 0;
        getStress = 0;
        getHealth = 100;
        getAlchol = 0;
        getPopular = 0;
        */
        
        w1Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w1Txt.text = "";
        w2Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w2Txt.text = "";
        w3Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w3Txt.text = "";
        w4Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w4Txt.text = "";
        w5Panel.GetComponent<Image>().color = new Color32(255, 255, 255, 225);
        w5Txt.text = "";
    }

    public void doActivity()
    {
        schedulePanel.SetActive(false);
        activityPanel.SetActive(false);
        player.SetActive(false);
        Debug.Log("do Activities");
    }

    public void Complete()
    {
        decideSound.Play();
        GameData.gamedata.health=getHealth;
        GameData.gamedata.alchol=getAlchol;
        GameData.gamedata.major=getMajor;
        GameData.gamedata.popular=getPopular;
        GameData.gamedata.stress=getStress;
        if(GameData.gamedata.month=="3월"){
            // GameData.gamedata.month="4월";
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom3");
        }
        else if(GameData.gamedata.month=="4월")
        {
            // GameData.gamedata.month="5월";
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom4");
            
        }else if(GameData.gamedata.month=="5월")
        {
            // GameData.gamedata.month="6월";
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("SYGFestivalStart");
        }else if(GameData.gamedata.month=="6월")
        {
            GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeMonth5");
        }
    }
}
