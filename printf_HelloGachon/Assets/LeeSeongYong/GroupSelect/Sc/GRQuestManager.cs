using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRQuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex; //퀘스트 순서 정하기
    public GameObject[] questObject; 
    Dictionary<int, GRQuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, GRQuestData>();
        GenerateData();
    }

    // 퀘스트 생성 - 퀘스트 코드 공유하기!!
    void GenerateData()
    {
        questList.Add(10, new GRQuestData("npc들과 대화하기.", new int[]{1000, 2000,2000}));
        questList.Add(20, new GRQuestData("오리엔테이션 하러가기", new int[]{2000, 5000, 500}));
        questList.Add(30, new GRQuestData("오리엔테이션 끝나고 뒷풀이 참석하기", new int[]{2000, 1000}));
        questList.Add(40, new GRQuestData("간식행사 하러가기", new int[]{2000, 5000, 500}));
        questList.Add(50, new GRQuestData("종강파티 하러가기", new int[]{2000, 5000, 500}));
        questList.Add(120, new GRQuestData("한마음페스티벌",new int[]{70,5}));
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
    void ControlObject()
    {
        // switch (questId)
        // {
        //     case 10: 
        //         if(questActionIndex ==1 ){
        //             questObject[0].SetActive(true);
        //         }else if(questActionIndex ==2){
        //             questObject[0].SetActive(false);
        //         }
                                   
        //         break;
        //     case 20:
        //         if(questActionIndex ==1)
        //             questObject[0].SetActive(false);
        //         break;

        // }
    }
}
