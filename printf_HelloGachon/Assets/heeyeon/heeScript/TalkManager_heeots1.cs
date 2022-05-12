using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager_heeots1 : MonoBehaviour
{
    Dictionary<int, string[]> talkName;
    // Dictionary<int, string[]> talkData;

    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public DialogManager_hee1 gameManager;
    public QuestManager_heeots1 questManager;

    //초상화 스프라이트를 저장할 배열 생성
    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>(); //대화에 문장이 여러개 존재
        portraitData = new Dictionary<int, Sprite>();
        generateData();
    }

    void generateData()
    {
        //room Obj name
        //boo:100, room_cat:200, room_guitar:300, room_mirror:400
        //room_bed:500, room_backpack:600, room_desk:700, room_door:800
        talkName.Add(100, new string[] { "곰인형" });
        talkName.Add(200, new string[] { "귤이" });
        talkName.Add(300, new string[] { "레오" });
        talkName.Add(400, new string[] { "전신거울" });
        talkName.Add(500, new string[] { "침대(장식)" });
        talkName.Add(600, new string[] { "책가방" });
        talkName.Add(700, new string[] { "책상" });
        talkName.Add(800, new string[] { "" });

        //room storyObj name
        //phone:1000, room_door:2000, player:3000
        talkName.Add(1000, new string[] { "" });
        talkName.Add(2000, new string[] { "[플레이어 이름]" });

        //room Obj talk
        talkData.Add(100, new string[] { "(말랑말랑)" });
        talkData.Add(200, new string[] { "골골골골..." });
        talkData.Add(300, new string[] { "너 때문에 흥이 다 깨져버렸으니 책임져.", "네, 알겠습니다.", "좌우징 좌우징" });
        talkData.Add(400, new string[] { "꼬질꼬질하다." });
        talkData.Add(500, new string[] { "개발자는 자지 않아" });
        talkData.Add(600, new string[] { "돌덩이같은 내 가방.." });
        talkData.Add(700, new string[] { "공부하기 싫다!" });
        talkData.Add(800, new string[] { "아직은 방에 있고 싶어." });


        //npcs
       //시작할때 intro 대사 , 튜토리얼, npc들 익히기
        talkData.Add(3000, new string[] {"와!!! 가천대학교 컴퓨터공학과에 합격했다!!! 아싸!!!!:1",
                                        "입학하기 전에 학과별로 단체톡방에 들어갈 수 있구나!!! 들어가봐야지!!!!:3"
                                            
                                        });
        //room Story Obj talk
        talkData.Add(1000, new string[] { "딱히 온 카톡은 없네.." });
        talkData.Add(2000, new string[] { "배고프다.." });

        


        //Quest Talk
        //Quest1: 3월_입학식(questId: 10)
        talkData.Add(10 + 1000, new string[] { "엇 컴공 공지방 카톡왔네.", "확인해보자." });
        // talkData.Add(11 + 400, new string[] { "입학식이 3월 2일에 있구나" });

        //Quest2: 오티를 가 말어~ (questId: 20)
        // talkData.Add(20 + 400, new string[] { "오티를 갈까 말까" });

        //portrait Data
       portraitData.Add(3000+0,portraitArr[0]); //플레이어 및 인트로에 쓰일 선배와 친구
       portraitData.Add(3000+1,portraitArr[1]);
       portraitData.Add(3000+2,portraitArr[2]);
       portraitData.Add(3000+3,portraitArr[3]);
    //    portraitData.Add(7000+4,portraitArr[17]); //선배
    //    portraitData.Add(7000+5,portraitArr[18]); //친구

    }

    public string getTalk(int id, int talkIndex)
   {       

        if(!talkData.ContainsKey(id)){

           Debug.Log("잘되는디요");
           Debug.Log(id);
           if((id-questManager.getQuestTalkIndex(id))==12312){
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
  
                //   Debug.Log("77777777777777777777777");
                  
                //   talkPanel3.SetActive(true);
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];
                    // Debug.Log("2222222");
               }
                 
           }}
           else{
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
                    
                  Debug.Log("333333");
                 
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];
                    Debug.Log("2222222");
               }
                 
              }else{
               //해당 퀘스트 진행 순서 중 대사가 없을 때
               //퀘스트 맨 처음 대사를 가져옴
               if(talkIndex == talkData[id-id%10].Length){                  
                  Debug.Log("44444444444");
                  return null;
                  }                 
               else{
                   return talkData[id - id%10][talkIndex];
                   Debug.Log("2222222");
                  }
                  
                  
              }
            }
            
       }

       if(talkIndex==talkData[id].Length){ 
            Debug.Log("555555555");
           return null;
       }
       else{
           return talkData[id][talkIndex];
           Debug.Log("2222222");
       }
   }

   public Sprite GetPortrait(int id, int portraitIndex)
   {
       return portraitData[id+portraitIndex];
   }

    

    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }

    // public string getTalk(int id, int talkIndex)
    // {
    //     if (!talkData.ContainsKey(id)) {
    //         if (!talkData.ContainsKey(id - id % 10)) {
    //             //퀘스트 맨 처음 대사마저 없을 때
    //             //기본 대사를 가져옴
    //             return getTalk(id - (id % 100), talkIndex); //Get First Talk
    //         }
    //         else {
    //             //해당 퀘스트 진행 순서 대사가 없을 때
    //             //퀘스트 맨 처음 대사로 돌아감
    //             return getTalk(id - (id % 10), talkIndex); //Get First Quest Talk
    //         }            
    //     }

    //     if (talkIndex == talkData[id].Length) {
    //         return null;
    //     }        
    //     else {
    //         return talkData[id][talkIndex];
    //     }
    // }
}