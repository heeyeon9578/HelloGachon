using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager_heeots6 : MonoBehaviour
{
    Dictionary<int, QuestData_heeots3> questList;
    public GameObject[] questObject;
    public bool isInteract;
    private bool isTouched = false;
    public int questId;
    public int questActionIndex;

    //참여할지 말지 클릭하는 판넬
    public GameObject talkPanel;

    //종강파티 이미지 넣을 것
    public GameObject FinishImage;

    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_heeots3>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
        questObject[0].SetActive(true);
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_heeots3("카톡을 확인하자", new int[] {1000, 400}));
        questList.Add(20, new QuestData_heeots3("신입생 오티?", new int[] {400}));
        questList.Add(30, new QuestData_heeots3("오티 씬 종료!", new int[] { 0 }));
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
            // case 20:
            //     if(questActionIndex == 1) {
            //         questObject[2].SetActive(true);
            //         isInteract = true;
            //     }
            //     break;
            default:
                break;
        }
    }
    //폰 화면 나오고 꺼질때 쓰이는 함수
    public void touchPhone()
    {
        questObject[1].SetActive(false);
        isInteract = false;
        isTouched = true;
        talkPanel.SetActive(true);
    }

    //3월 맵 씬으로 넘어가기 위한 함수
    public void onApplyBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("간다!");
        //참여한다고 하면 바로 메인맵으로 이동 후, 입학식 진행
        SceneManager.LoadScene("heeMonth3");
    }

    //4월 맵 씬으로 넘어가기 위한 함수
        public void onApplyBtnClick4()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("간다!");
        //참여한다고 하면 바로 메인맵으로 이동 후, 4월 간식행사 진행
        SceneManager.LoadScene("heeMonth4");
    }

    //5월 맵 씬으로 넘어가기 위한 함수
        public void onApplyBtnClick5()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("간다!");
        //참여한다고 하면 바로 메인맵으로 이동 후, 5월 간식행사 진행
        SceneManager.LoadScene("heeMonth5");
    }

    //6월 맵 씬으로 넘어가기 위한 함수
        public void onApplyBtnClick6()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("간다!");
        //참여한다고 하면 바로 메인맵으로 이동 후, 5월 간식행사 진행
        FinishImage.SetActive(true);
    }

    public void onNoBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("안가!");
        
        //참여하지 않으면 3월 수업 퀘스트 진행
        // SceneManager.LoadScene("MiniGame1");
    }

    public void onNoBtnClick4()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("안가!");
        
        //참여하지 않으면 4월 수업 퀘스트 진행
        // SceneManager.LoadScene("MiniGame1");
    }

    public void onNoBtnClick5()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("안가!");
        
        //참여하지 않으면 5월 퀘스트 진행
        // SceneManager.LoadScene("MiniGame1");
    }

        public void onNoBtnClick6()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        Debug.Log("안가!");
        
        //참여하지 않으면 5월 퀘스트 진행
        // SceneManager.LoadScene("MiniGame1");
    }
}
