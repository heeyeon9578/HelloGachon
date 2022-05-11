using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager_otl_sk : MonoBehaviour
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
        //bigclassroom Obj name
        //bigclassroom_door:100
        talkName.Add(100, new string[] { "" });        

        //bigclassroom storyObj name
        //bigclassroom_playerSeat:200, sunabe:2000, player:7000
        talkName.Add(200, new string[] { "" });
        talkName.Add(2000, new string[] { "선배" });
        talkName.Add(7000, new string[] { "[플레이어 이름]" });

        //bigclassroom Obj talk
        talkData.Add(100, new string[] { "오티를 그만 듣고 집에 갈까?" });

        //bigclassroom Story Obj talk
        talkData.Add(200, new string[] { "여긴 내 자리이다.:4" });
        talkData.Add(2000, new string[] { "...:3" });

        //bigclassroom Story Obj Portrait
        //7000:me - 0:default 1:talk
        portraitData.Add(7000 + 0, portraitArr[0]);
        portraitData.Add(7000 + 1, portraitArr[1]);
        
        //2000:sunabe - 0:smile 1:default 2:talk 3:angry
        portraitData.Add(2000 + 0, portraitArr[2]);
        portraitData.Add(2000 + 1, portraitArr[3]);
        portraitData.Add(2000 + 2, portraitArr[4]);
        portraitData.Add(2000 + 3, portraitArr[5]);

        //200:sunabe - 0:smile 1:default 2:talk 3:angry 4:no portrait
        portraitData.Add(200 + 0, portraitArr[6]);
        portraitData.Add(200 + 1, portraitArr[7]);
        portraitData.Add(200 + 2, portraitArr[8]);
        portraitData.Add(200 + 3, portraitArr[9]);
        portraitData.Add(200 + 4, portraitArr[10]);


        //quest 시작 전 플레이어 독백
        talkData.Add(7000, new string[] {"여기가 오티장소인가?:0", "엇 저기 선배님이 계신다!:1", "가서 말걸어보자.:0"});

        //Quest Talk
        //Quest1: 선배님께 말걸자! (questId: 10)
        talkData.Add(10 + 2000, new string[] { "안녕!:0", "오티 들으러 왔구나! 환영해~:0", "저기 자리에 앉으면 오티가 시작될거야!:2" });

        //Quest2: 오티 시작! (questId: 20)
        talkData.Add(20 + 200, new string[] { "신입생 여러분~ 가천대학교 컴퓨터공학과에 입학한 걸 진심으로 축하드려요!:0",
                                                "지금부터 신입생 오리엔테이션을 시작하겠습니다!:2",
                                                "오늘은 여러분들께 학번 및 홈페이지, 수강신청, 사이버캠퍼스, 학사행정, 비교과신청(WIND), 등록금에 대해 설명 드릴 거예요~:0",
                                                "설명 듣고 싶은 항목을 골라 터치하세요!:2"
                                            });
    }

    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }

    public string getTalk(int id, int talkIndex)
    {
        if (!talkData.ContainsKey(id)) {
            if (!talkData.ContainsKey(id - (id % 10))) {
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
