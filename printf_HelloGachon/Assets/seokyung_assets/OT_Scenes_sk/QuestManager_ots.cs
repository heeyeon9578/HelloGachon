using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager_ots : MonoBehaviour
{
    Dictionary<int, QuestData_ots> questList;
    public GameObject[] questObject;
    public bool isInteract;
    private bool isTouched = false;
    public int questId;
    public int questActionIndex;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_ots>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
        questObject[0].SetActive(true);
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_ots("카톡을 확인하자", new int[] {1000, 400}));
        questList.Add(20, new QuestData_ots("신입생 오티?", new int[] {400}));
        questList.Add(30, new QuestData_ots("오티 씬 종료!", new int[] { 0 }));
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
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                    isInteract = true;                 
                }
                break;
            case 20:
                if(questActionIndex == 1) {
                    questObject[2].SetActive(true);
                    isInteract = true;
                }
                break;
            default:
                break;
        }
    }

    public void touchPhone()
    {
        questObject[1].SetActive(false);
        isInteract = false;
        isTouched = true;
    }

    public void onApplyBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("간다!");
    }

    public void onNoBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("안가!");
        
        //참여하지 않으면 수강신청 게임 진행
        SceneManager.LoadScene("MiniGame1");
    }
}
