using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager_heeots4 : MonoBehaviour
{
    Dictionary<int, string[]> talkName;
    // Dictionary<int, string[]> talkData;

    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public DialogManager_hee4 gameManager;
    public QuestManager_heeots4 questManager;

    //초상화 스프라이트를 저장할 배열 생성
    public Sprite[] portraitArr;

    void Awake()
    {
        talkName = new Dictionary<int, string[]>();
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
        talkName.Add(800, new string[] { "방 문" });

        //room storyObj name

        talkName.Add(3000, new string[] { "" });
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
        talkData.Add(3000, new string[] {"허허, MT에서 재밌게 놀다 오셨나요?:1",
                                        "이제 4월 수업 들으러 오세요~:1",
                                        "으아, 수업 들으러 가야겠네:2"                                      
                                        });
 

        


        //Quest Talk
        //Quest1: 3월_입학식(questId: 10)
        talkData.Add(10 + 800, new string[] { "수업 들으러 갈까" });


        //portrait Data
       portraitData.Add(3000+0,portraitArr[0]); 
       portraitData.Add(3000+1,portraitArr[1]); // 교수님
       portraitData.Add(3000+2,portraitArr[2]);
       portraitData.Add(3000+3,portraitArr[3]);


    }


   public Sprite GetPortrait(int id, int portraitIndex)
   {
       return portraitData[id+portraitIndex];
   }

    

    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }

    public string getTalk(int id, int talkIndex)
    {
        Debug.Log(id);
        if (!talkData.ContainsKey(id)) {
            if (!talkData.ContainsKey(id - id % 10)) {
                //퀘스트 맨 처음 대사마저 없을 때
                //기본 대사를 가져옴
                return getTalk(id - (id % 100), talkIndex); //Get First Talk
            }
            else {
                //해당 퀘스트 진행 순서 대사가 없을 때
                //퀘스트 맨 처음 대사로 돌아감
                return getTalk(id - (id % 10), talkIndex); //Get First Quest Talk
            }            
        }

        if (talkIndex == talkData[id].Length) {
            return null;
        }        
        else {
            return talkData[id][talkIndex];
        }
    }
}