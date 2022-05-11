using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager_otl_sk : MonoBehaviour
{
    Dictionary<int, QuestData_otl_sk> questList;
    public TalkManager_otl_sk tManager;
    public GameObject[] questObject;
    public GameObject dialogPanel;
    public Text dialogName;
    public Text dialogText;
    public bool isInteract;
    public int questId;
    public int questActionIndex;
    public int nameIndex;
    public int talkIndex;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_otl_sk>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_otl_sk("선배님께 말걸자!", new int[] { 2000 }));
        questList.Add(20, new QuestData_otl_sk("오티 시작!", new int[] { 200 }));
        questList.Add(30, new QuestData_otl_sk("오티 듣기 씬 종료!", new int[] { 0 }));
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
        questActionIndex = 0;
        questId += 10;
    }

    public void controlQuestObject()
    {
        switch(questId)
        {
            case 10:
                break;
            case 20:
                if(questActionIndex == 1) {
                    questObject[0].SetActive(true);
                    isInteract = true;                 
                }
                break;
            default:
                break;
        }
    }

    //선택지 버튼 눌렀을 때 실행되는 함수들
    // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
    public void on1BtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //1번 누르면 학번 및 홈페이지 설명
        Debug.Log("1번 누르면 학번 및 홈페이지 설명");
    }
    public void on2BtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //2번 누르면 수강신청 설명
        Debug.Log("2번 누르면 수강신청 설명");
    }
    public void on3BtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //3번 누르면 사이버캠퍼스 설명
        Debug.Log("3번 누르면 사이버캠퍼스 설명");
    }
    public void on4BtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //4번 누르면 학사행정 설명
        Debug.Log("4번 누르면 학사행정 설명");
    }
    public void on5BtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //5번 누르면 비교과신청(WIND) 설명
        Debug.Log("5번 누르면 비교과신청(WIND) 설명");
    }
    public void on6BtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //6번 누르면 등록금 설명
        Debug.Log("6번 누르면 등록금 설명");
    }
    public void onSkipBtnClick()
    {
        questObject[0].SetActive(false);
        isInteract = false;

        //건너뛰기 누르면 오티 씬 종료
        Debug.Log("건너뛰기");
    }

}
