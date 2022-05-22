using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestManager_bmg1_sk : MonoBehaviour
{
    Dictionary<int, QuestData_bmg1_sk> questList;
    public TalkManager_bmg1_sk tManager;
    public GameObject[] questObject;
    public bool isInteract;
    public int questId;
    public int questActionIndex;
    public int nameIndex;
    public int talkIndex;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_bmg1_sk>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_bmg1_sk("컴퓨터를 확인하자!", new int[] { 1000 }));
        questList.Add(20, new QuestData_bmg1_sk("수강신청 시작!", new int[] { 0 }));
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
                if(questActionIndex == 1) {
                    isInteract = false;
                    GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("MiniGame1");     
                }
                break;
            default:
                break;
        }
    }
}
