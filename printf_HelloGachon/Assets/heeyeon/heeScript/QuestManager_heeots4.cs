using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager_heeots4 : MonoBehaviour
{
    Dictionary<int, QuestData_heeots3> questList;
    public GameObject[] questObject;
    public bool isInteract;
    private bool isTouched = false;
    public int questId;
    public int questActionIndex;

    //참여할지 말지 클릭하는 판넬
    public GameObject talkPanel;
    
    void Awake()
    {

        isInteract = false;
        
        questList = new Dictionary<int, QuestData_heeots3>();
        generateData();
    }

    void generateData()
    {
        questList.Add(10, new QuestData_heeots3("4월 수업 들으러 학교가자", new int[] {800}));
        questList.Add(20, new QuestData_heeots3("4월 방 이벤트 종료", new int[] {0}));

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
                if(questActionIndex == 1 ) {
                  
                    questObject[0].SetActive(true);             
                }

                break;
            
            default:
                break;
        }
    }

    //4월 수업 이벤트으로 넘어가기 위한 함수
    public void onApplyBtnClick4()
    {

        isInteract = false;
        Debug.Log("간다!");
        //참여한다고 하면 바로 4월 수업 이벤트 진행, 필수(성재님 수업이벤트)
        SceneManager.LoadScene("MiniGame3");
    }



}
