using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heeQuestManager5 : MonoBehaviour
{
    public Text talkText3;
    public int questId;
    public int questActionIndex; //퀘스트 순서 정하기
    public GameObject[] questObject; 
    Dictionary<int, heeQuestData3> questList;
    
    void Awake()
    {
        questList = new Dictionary<int, heeQuestData3>();

        //처음 게임 시작할 때, questMark의 default 대사
        talkText3.text = "IT대학 앞에서 친구 만나기";
        GenerateData();
    }

    // 퀘스트 생성 - 퀘스트 코드 공유하기!!
    void GenerateData()
    {
        questList.Add(10, new heeQuestData3("5월: 간식행사", new int[]{1000, 2000}));
        questList.Add(20, new heeQuestData3("5월: 이길여 총장님 이벤트", new int[]{2000, 6000}));
        questList.Add(30, new heeQuestData3("끝", new int[]{0}));

    }

    public int GetQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string CheckQuest(int id)
    {
        
        //다음 npc 확인
        if(id == questList[questId].npcId[questActionIndex])
            questActionIndex++;

        //Control Quest Object
        ControlObject(); 

        //다음 퀘스트 확인
        if(questActionIndex == questList[questId].npcId.Length)
        {
            NextQuest();
        }
        //현재 퀘스트의 이름까지 같이 확인
        return questList[questId].questName;
    }

    public string CheckQuest()
    {       
        //현재 퀘스트의 이름까지 같이 확인
        return questList[questId].questName;
    }

    //다음 퀘스트로 넘어가기
    void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    //퀘스트에서 사용하는 오브젝트 관리!!
    public void ControlObject()
    {
        switch (questId)
        {
            case 10: 
                if(questActionIndex ==1){
                    talkText3.text = "AI공학관 앞에서 선배 만나기";
                }else if(questActionIndex==2){
                    talkText3.text = "선배에게 말걸기";
                }
                                   
                break;

            case 20: 
                if(questActionIndex ==0){
                    talkText3.text = "선배에게 말걸기";
                }else if(questActionIndex==1){
                    talkText3.text = "이길여 총장님 찾기";
                }else if(questActionIndex==2){
                    questObject[1].SetActive(true);
                }
                                   
                break;

        }
    }

    public void clickYes(){
        // 6월 수업씬으로 이동
        // SceneManager.LoadScene("");
    }
    
}
