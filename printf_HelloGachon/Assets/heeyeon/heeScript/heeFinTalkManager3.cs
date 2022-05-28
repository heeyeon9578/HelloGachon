using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heeFinTalkManager3 : MonoBehaviour
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
        string playerName = GameData.gamedata.playerName;
        talkName.Add(200, new string[] { "컴공 회장" });
        talkName.Add(2000, new string[] { "선배" });
        talkName.Add(300, new string[] {  playerName});

        //bigclassroom Obj talk
        talkData.Add(100, new string[] { "아직은 나갈 수 없어. 선배한테 말을 걸자." });

        //bigclassroom Story Obj talk
        talkData.Add(200, new string[] { "여긴 내 자리이다.:4" });
        talkData.Add(2000, new string[] { "반가워!:3" });

        //bigclassroom Story Obj Portrait
        //7000:me - 0:default 1:talk
        portraitData.Add(300 + 0, portraitArr[0]);
        portraitData.Add(300 + 1, portraitArr[1]);
        
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

        portraitData.Add(3000 + 0, portraitArr[11]);
        portraitData.Add(4000 + 0, portraitArr[12]);
        portraitData.Add(5000 + 0, portraitArr[13]);
        portraitData.Add(6000 + 0, portraitArr[14]);
        portraitData.Add(7000 + 0, portraitArr[15]);
        portraitData.Add(8000 + 0, portraitArr[16]);
        portraitData.Add(9000 + 0, portraitArr[17]);


        //quest 시작 전 플레이어 독백
        talkData.Add(300, new string[] {"여기가 입학식 장소인가?:0", "엇 저기 선배님이 계신다!:1", "가서 말걸어보자.:0"});

        //Quest Talk
        //Quest1: 선배님께 말걸자! (questId: 10)
        talkData.Add(10 + 2000, new string[] { "안녕!:0", "입학식에 왔구나! 환영해~:0", "저기 자리에 앉으면 입학식이 시작될거야!:2" });

        //Quest2: 입학식 시작! (questId: 20)
        talkData.Add(20 + 200, new string[] { "신입생 여러분~ 가천대학교 컴퓨터공학과에 입학한 걸 진심으로 축하드립니다!:0",
                                                "지금부터 신입생 입학식을 시작하겠습니다!:2",
                                                "오늘은 여러분들께 MT, 동아리홍보전, 학생회가입, 간식행사, 한마음 페스티벌, 중간고사/기말고사에 대해 설명 드릴 예정입니다!:0",
                                                "설명 듣고 싶은 항목을 골라 터치하세요!:2"
                                            });
        talkData.Add(21 + 2000, new string[] { "모두 설명 듣느라 고생했어~:2" });

        //Quest3:수업들으러가기 (questId: 30)
        talkData.Add(30 + 2000, new string[] { "이제 수업 들으러 가야지~:0" });

        //Quest2.1~7: 설명듣기
        // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
        talkName.Add(3000, new string[] { "컴공 회장" });
        talkName.Add(4000, new string[] { "컴공 회장" });
        talkName.Add(5000, new string[] { "컴공 회장" });
        talkName.Add(6000, new string[] { "컴공 회장" });
        talkName.Add(7000, new string[] { "컴공 회장" });
        talkName.Add(8000, new string[] { "컴공 회장" });
        talkName.Add(9000, new string[] { "컴공 회장" });

        talkData.Add(3000, new string[] { "1. MT:0",
                                            "MT는 3월 말에 대성리 MT촌에서 1박2일로 진행합니다.:0",
                                            "선배 한 명이 약 10명정도의 신입생과 팀을 이루게 됩니다.:0",
                                            "팀은 랜덤으로 배정되며, 게임이나 식사 등을 같이 합니다.:0",
                                            "MT 진행 전에 각 팀원들끼리 사전에 만나서 미리 친해질 수도 있습니다. :0"
                                        });
        talkData.Add(4000, new string[] { "2. 동아리홍보전:0",
                                            "동아리 홍보전은 3월 말에 진행하며 가천대학교 중앙동아리별로 부스를 운영합니다.:0",
                                            "부스는 프리덤광장에 설치되며 3일정도 진행됩니다.:0",
                                            "각 동아리별로 설명, 행사, 게임 등을 진행합니다. :0"
                                        });
        talkData.Add(5000, new string[] { "3.학생회가입:0",
                                            "학생회 모집은 3월 중반에 합니다.:0",
                                            "지원서를 작성하고 면접을 진행하여 합격한 인원에 한하여 학생회가 됩니다.:0",
                                            "학생회가 되면 집부 별로 나뉘어 활동하게 됩니다.:0"
                                        });
        talkData.Add(6000, new string[] { "4. 간식행사:0",
                                            "간식행사는 중간고사 직전인 4월 말과 기말고사 직전인 5월말에 AI공학관에서 진행합니다.:0",
                                            "간식은 매번 다른 메뉴로 선정되며, 줄을 서서 배급받습니다.:0",
                                            "학생증을 꼭 소지해야 받을 수 있으며, 조기소진 시 행사가 종료됩니다.:0"
                                        });
        talkData.Add(7000, new string[] { "5.한마음 페스티벌:0",
                                            "한마음 페스티벌은 5월 초에 진행합니다.:0",
                                            "더워진 날씨에 시원하게 즐길 수 있도록 물총 이벤트를 합니다.:0",
                                            "사전 참가 예약시, 한정된 수량의 한마음 페스티벌 티셔츠를 배부받을 수 있습니다. :0",
                                            "가천대학교 글로벌캠퍼스 대운동장에서 진행하며, 가수 초정 공연도 있습니다.:0 "
                                        });
        talkData.Add(8000, new string[] { "6.중간고사/기말고사:0",
                                            "중간고사/기말고사를 치르기 1달전쯤부터 강의실을 24시간 개방합니다.:0",
                                            "학생들이 공부할 수 있는 공간을 제공하기 위해서입니다.:0",
                                            "학생들은 자유롭게 해당 강의실을 이용할 수 있습니다. :0"
                                        });
        talkData.Add(9000, new string[] { "이상으로 신입생 입학식을 마치겠습니다! 모두 수고하셨습니다.:0",
                                            "신입생 여러분, 앞으로 가천대학교에서 좋은 추억 많이 만들고 알찬 학교생활하길 바랄게요~!! 감사합니다!!!:0",
                                            "끝나고 수업들으러 가시면 됩니다!!!:0"
                                        });
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
