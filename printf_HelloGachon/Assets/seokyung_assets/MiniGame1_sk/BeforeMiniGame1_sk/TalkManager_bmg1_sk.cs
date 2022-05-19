using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager_bmg1_sk : MonoBehaviour
{
    Dictionary<int, string[]> talkName;
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;

    void Awake()
    {
        talkName = new Dictionary<int, string[]>();
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        generateData();
    }

    void generateData()
    {
        //room Obj name
        //boo:100, room_cat:200, room_guitar:300, room_mirror:400
        //room_bed:500, room_backpack:600, room_door:800
        talkName.Add(100, new string[] { "곰인형" });
        talkName.Add(200, new string[] { "귤이" });
        talkName.Add(300, new string[] { "레오" });
        talkName.Add(400, new string[] { "전신거울" });
        talkName.Add(500, new string[] { "침대(장식)" });
        talkName.Add(600, new string[] { "책가방" });        
        talkName.Add(800, new string[] { "방 문" });

        //room storyObj name
        //room_desk:1000, player:7000
        talkName.Add(1000, new string[] { "[플레이어 이름]" });
        talkName.Add(7000, new string[] { "[플레이어 이름]" });

        //room Obj talk
        talkData.Add(100, new string[] { "(말랑말랑)" });
        talkData.Add(200, new string[] { "골골골골..." });
        talkData.Add(300, new string[] { "너 때문에 흥이 다 깨져버렸으니 책임져.", "네, 알겠습니다.", "좌우징 좌우징" });
        talkData.Add(400, new string[] { "꼬질꼬질하다." });
        talkData.Add(500, new string[] { "개발자는 자지 않아" });
        talkData.Add(600, new string[] { "돌덩이같은 내 가방.." });        
        talkData.Add(800, new string[] { "아직은 방에 있고 싶어." });

        //room Story Obj talk
        talkData.Add(1000, new string[] { "공부하기 싫다!:1" });        

        //portrait Data
        //7000:me - 0:smile 1:talk
        portraitData.Add(7000 + 0, portraitArr[0]);
        portraitData.Add(7000 + 1, portraitArr[1]);

        portraitData.Add(1000 + 0, portraitArr[2]);
        portraitData.Add(1000 + 1, portraitArr[3]);
        portraitData.Add(1000 + 2, portraitArr[4]);

        //quest 시작 전 플레이어 독백
        talkData.Add(7000, new string[] { "오늘은 첫 수강신청하는 날!:0", "책상에 있는 노트북으로 해보자.:1" });

        //Quest Talk
        //Quest1: 컴퓨터를 확인하자! (questId: 10)
        talkData.Add(10 + 1000, new string[] { "네이비즘 준비해뒀고.. 긴장하지 말구...:0", "헉 10시다!!!:1", "가즈아아아아아아아!:2", "(바로 수강신청이 진행되니 준비가 된 후에 터치하세요!):2" });
    }

    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }

    public string getTalk(int id, int talkIndex)
    {
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

    public Sprite getPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
