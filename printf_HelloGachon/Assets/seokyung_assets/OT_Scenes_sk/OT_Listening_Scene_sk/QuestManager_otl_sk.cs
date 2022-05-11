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
    private bool isTouched = false;
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
        questList.Add(20, new QuestData_otl_sk("오티 듣기 씬 종료!", new int[] { 0 }));
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
                /*
                if(questActionIndex == 1 && isTouched == false) {
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                    isInteract = true;                 
                }
                */
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

        //참가하면 오티에 가기 위해 가천대 맵으로 이동
        SceneManager.LoadScene("Going_OT_Scene_sk");
    }

    public void onNoBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        
        //참가하지 않으면 수강신청 게임 진행
        SceneManager.LoadScene("MiniGame1");
    }
}
