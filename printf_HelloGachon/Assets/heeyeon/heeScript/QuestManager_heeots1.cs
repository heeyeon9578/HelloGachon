using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager_heeots1 : MonoBehaviour
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
        questObject[0].SetActive(true);
        questList = new Dictionary<int, QuestData_heeots3>();
        generateData();
    }

    // void Start()
    // {
    //     isInteract = false;
    //     questObject[0].SetActive(true);
    // }
    
    void generateData()
    {
        questList.Add(10, new QuestData_heeots3("카톡을 확인하자", new int[] {1000}));
        questList.Add(20, new QuestData_heeots3("인트로 종료", new int[] {0}));

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

                   
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                    isInteract = true;                 
                }
                break;

            default:
                break;
        }
    }
    //phonePanel에서 phonePanel2로 넘어가기 위한 함수
    public void touchPhone()
    {
        

        questObject[3].SetActive(true);
        questObject[4].SetActive(false);

    }

    //phonePanel2를 끄기 위한 함수
    public void touchPhone2()
    {
        questObject[1].SetActive(false);

        isInteract = false;
        isTouched = true;
        talkPanel.SetActive(true);
    }

    //1월 맵 씬으로 넘어가기 위한 함수
    public void onApplyBtnClick1()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("간다!");
        //참여한다고 하면 바로 메인맵으로 이동 후, 튜토리얼 진행
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeMonth1");

    }

    public void onNoBtnClick1()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("안가!");
        
        //참여하지 않으면 2월 오티가기 전으로 넘어감
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("OT_Select_sk");
        
    }

}
