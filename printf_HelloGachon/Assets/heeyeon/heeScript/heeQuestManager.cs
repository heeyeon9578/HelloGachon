using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heeQuestManager : MonoBehaviour
{
    public Text talkText3;
    public int questId;
    public int questActionIndex; //퀘스트 순서 정하기
    public GameObject[] questObject; 
    Dictionary<int, heeQuestData> questList;
    
    


    void Awake()
    {
        questList = new Dictionary<int, heeQuestData>();

        //처음 게임 시작할 때, questMark의 default 대사
        talkText3.text = "IT대학 앞에 서 있는 친구를 찾아가기";
        GenerateData();
    }

    // 퀘스트 생성
    void GenerateData()
    {
        questList.Add(10, new heeQuestData("1월: npc들과 대화하며 npc 위치익히기", new int[]{1000, 2000, 8000}));
        questList.Add(20, new heeQuestData("1월: npc들과 대화하며 npc 위치익히기끝", new int[]{0}));

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
        switch (questId)
        {
            case 10: 
                if(questActionIndex ==1 ){
                    talkText3.text = "AI공학관 앞에 가서 선배님이랑 인사하기";
                }else if(questActionIndex ==2){
                    talkText3.text = "선배님 옆에 계시는 교수님이랑 인사하기";                  
                }else if(questActionIndex ==3){
                    GameObject.Find("heeCanvas").GetComponent<FadeINOUT>().LoadFadeOut("OT_Select_sk");
                    
                }
                                   
                break;


        }
    }
}
