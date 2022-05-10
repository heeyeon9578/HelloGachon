using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager_goot_sk : MonoBehaviour
{
    public int questId;
    public int questActionIndex; //퀘스트 순서 정하기
    public GameObject[] questObject; 
    Dictionary<int, heeQuestData> questList;

    void Awake()
    {
        questList = new Dictionary<int, heeQuestData>();
        GenerateData();
    }

    // 퀘스트 생성 - 퀘스트 코드 공유하기!!
    void GenerateData()
    {
        questList.Add(10, new heeQuestData("AI공학관까지 이동하자!", new int[]{500}));
        questList.Add(20, new heeQuestData("오티가기 씬 종료", new int[]{0}));
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
        if(questId == 10 && questActionIndex == 1) {
            SceneManager.LoadScene("OT_Listening_sk");
        }
    }
}
