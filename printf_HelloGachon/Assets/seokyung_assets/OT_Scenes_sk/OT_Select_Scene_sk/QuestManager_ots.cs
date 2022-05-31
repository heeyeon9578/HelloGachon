using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager_ots : MonoBehaviour
{
    Dictionary<int, QuestData_ots> questList;
    public TalkManager_ots tManager;
    public GameObject[] questObject;
    public GameObject dialogPanel;
    public GameObject controlSet;
    public AudioSource phoneAlarm;
    public Text dialogName;
    public Text dialogText;
    public bool isInteract;
    private bool isTouched = false;
    public int questId;
    public int questActionIndex;
    public int nameIndex;
    public int talkIndex;
    public float getHealth;
    public float getPopular;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_ots>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
        questObject[0].SetActive(true);
        
        getPopular=GameData.gamedata.popular;
        getHealth=GameData.gamedata.health;
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_ots("카톡을 확인하자", new int[] { 2000 }));
        questList.Add(20, new QuestData_ots("신입생 오티?", new int[] { 0 }));
    }

    public int getQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string checkQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    public string checkQuest(int id)
    {
        //Next Talk Target
        if (id == questList[questId].storyObjId[questActionIndex]) {
            questActionIndex++;
        }

        //Control Quest Object
        controlQuestObject();

        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].storyObjId.Length) {
            nextQuest();
        }
        
        //Quest Name
        return questList[questId].questName;
    }

    void nextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void controlQuestObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 1 && isTouched == false) {
                    phoneAlarm.Stop();
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                    isInteract = true;                 
                }
                break;
            case 20:
                break;
            default:
                break;
        }
    }

    public void touchPhone()
    {
        questObject[1].SetActive(false);
        isTouched = true;
        questObject[2].SetActive(true);
    }

    public void onApplyBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;

        //능력치 부여 및 저장
        getHealth-=2;
        getPopular+=8;

        GameData.gamedata.health=getHealth;
        GameData.gamedata.popular=getPopular;

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

        //참가하면 오티에 가기 위해 가천대 맵으로 이동
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Going_OT_sk");
    }

    public void onNoBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        
        //참가하지 않으면 수강신청 게임 진행
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("BeforeMiniGame1");
    }
}
