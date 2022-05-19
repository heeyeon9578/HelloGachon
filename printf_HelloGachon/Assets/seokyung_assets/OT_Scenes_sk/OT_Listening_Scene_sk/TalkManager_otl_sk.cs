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
        string playerName = GameData.gamedata.playerName;

        //bigclassroom Obj name
        //bigclassroom_door:100
        talkName.Add(100, new string[] { playerName });        

        //bigclassroom storyObj name
        //bigclassroom_playerSeat:200, sunabe:2000, player:7000;
        talkName.Add(200, new string[] { "컴공 회장" });
        talkName.Add(2000, new string[] { "선배" });
        talkName.Add(300, new string[] { playerName });

        //bigclassroom Obj talk
        talkData.Add(100, new string[] { "아직은 나갈 수 없어. 선배에게 말을 걸어보자." });

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
        talkData.Add(300, new string[] {"여기가 오티장소인가?:0", "엇 저기 선배님이 계신다!:1", "가서 말 걸어보자.:0"});

        //Quest Talk
        //Quest1: 선배님께 말걸자! (questId: 10)
        talkData.Add(10 + 2000, new string[] { "안녕!:0", "오티 들으러 왔구나! 환영해~:0", "저기 자리에 앉으면 오티가 시작될거야!:2" });

        //Quest2: 오티 시작! (questId: 20)
        talkData.Add(20 + 200, new string[] { "신입생 여러분~ 가천대학교 컴퓨터공학과에 입학한 걸 진심으로 축하드립니다!:0",
                                                "지금부터 신입생 오리엔테이션을 시작하겠습니다!:2",
                                                "오늘은 여러분들께 학번 및 홈페이지, 수강신청, 사이버캠퍼스, 학사행정, 비교과신청(WIND), 등록금에 대해 설명 드릴 예정입니다!:0",
                                                "설명 듣고 싶은 항목을 골라 터치하세요!:2"
                                            });
        talkData.Add(21 + 2000, new string[] { "모두 오티 듣느라 고생했어~:2" });

        //Quest3: 뒷풀이에 갈까? (questId: 30)
        talkData.Add(30 + 2000, new string[] { "뒷풀이 갈거지?:0" });

        //Quest2.1~7: 설명듣기
        // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
        talkName.Add(3000, new string[] { "컴공 회장" });
        talkName.Add(4000, new string[] { "컴공 회장" });
        talkName.Add(5000, new string[] { "컴공 회장" });
        talkName.Add(6000, new string[] { "컴공 회장" });
        talkName.Add(7000, new string[] { "컴공 회장" });
        talkName.Add(8000, new string[] { "컴공 회장" });
        talkName.Add(9000, new string[] { "컴공 회장" });

        talkData.Add(3000, new string[] { "1. 학번 및 학교 홈페이지:0",
                                            "우선, 개개인의 학번을 알려드리겠습니다.:0",
                                            "가천대학교 홈페이지에서 처음 로그인할 때, 아이디는 학번이고 비밀번호는 생년월일입니다! 로그인 후, 원하는 아이디와 비밀번호로 바꿀 수 있습니다.:0",
                                            "상단메뉴바의 ‘대학, 대학원’ 메뉴를 클릭하면 ‘IT융합대학’이 있습니다. 해당 메뉴에서 컴퓨터공학전공을 클릭하면, 컴퓨터공학과 홈페이지가 나옵니다.:0",
                                            "홈페이지에서 학과소개, 교과과정, 공모전, 취업정보 등을 알 수 있습니다!:0",
                                            "메인 홈페이지의 오른쪽 메뉴바의 USER SERVICE를 통해 학사행정, 수강신청, 강의시간표, 사이버캠퍼스, 등록금수납 등의 서비스를 이용할 수 있습니다.:0"
                                        });
        talkData.Add(4000, new string[] { "2. 수강신청:0",
                                            "수강신청은 메인 홈페이지의 오른쪽 메뉴바의 USER SERVICE를 통해 진행할 수 있습니다.:0",
                                            "수강신청 날짜가 되면 10시 정각부터 수강신청 페이지가 열립니다. 이때, 조금만 늦어도 원하는 수업을 신청하지 못할 수 있습니다.:0",
                                            "‘네이비즘’ 사이트를 이용하면 가천대학교 수강신청 홈페이지의 시간을 정확히 파악할 수 있습니다!:0",
                                            "신입생의 수강신청은 재학생과 다르게 진행됩니다. 재학생은 예비수강 신청기간에 수업 목록을 장바구니에 미리 담아두고 본 수강시청 기간에 신청하기 버튼을 빠르게 눌러 진행합니다.:0",
                                            "그렇지만 신입생의 경우 장바구니 시스템을 이용할 수 없어, 듣고 싶은 수업들의 학수번호를 하나하나 입력하여 신청해야 합니다.:0",
                                            "그렇기 때문에 듣고 싶은 수업들의 학수번호를 미리 적어두거나 외워서 빠르게 입력하는 것이 중요합니다. 이때, 복사-붙여넣기는 사용할 수 없습니다.:0",
                                            "만약 수강신청에 실패했을 경우, 수강정정기간인 3월 초에 학과에서 수강실패한 인원을 조사하여 수업을 들을 수 있는 최대인원을 늘려주거나 수업을 추가로 개설해줍니다.:0",
                                            "이 기간에 다른 수업과 겹치지 않게 조정하여 다시 신청하면 됩니다. 만약 다른 수업과 겹치거나 또 신청에 실패하면 다음에 듣거나 계절학기로 들어야 합니다.:0"
                                        });
        talkData.Add(5000, new string[] { "3. 사이버캠퍼스:0",
                                            "사이버캠퍼스는 메인 홈페이지의 오른쪽 메뉴바의 USER SERVICE를 통해 이용할 수 있습니다. 아이디와 비밀번호는 학교 홈페이지와 동일합니다.:0",
                                            "사이버캠퍼스는 교수님께서 수업의 자료, 과제나 시험문제 등을 올리는 곳입니다. 해당 학기의 수업뿐만 아니라, 지난 학기의 수업도 이전 강좌 보기를 통해 볼 수 있습니다.:0"
                                        });
        talkData.Add(6000, new string[] { "4. 학사행정:0",
                                            "학사행정은 메인 홈페이지의 오른쪽 메뉴바의 USER SERVICE를 통해 이용할 수 있습니다.:0",
                                            "학사행정에서는 학점취득현황, 학사일정, 졸업이수기준취득현황, 강의시간표, 수강신청내역, 등록금납부현황, 출결현황, 장학내역, 성적조회, 교직이수현황 등을 확인할 수 있습니다.:0"
                                        });
        talkData.Add(7000, new string[] { "5. 비교과신청(WIND):0",
                                            "비교과신청(WIND)은 메인 홈페이지의 오른쪽 메뉴바의 USER SERVICE를 통해 진행할 수 있습니다.:0",
                                            "WIND는 우리대학에 개설된 비교과 프로그램을 관리하고 운영하기 위한 통합 시스템이며, 본인이 원하는 다양한 비교과 프로그램에 참여할 수 있습니다.:0",
                                            "교내 대회, 설명회, 특강, 봉사 등을 신청할 수 있습니다. 프로그램을 수료하면 마일리지를 받을 수 있으며 마일리지가 많이 모으면 상도 받을 수 있습니다.:0"
                                        });
        talkData.Add(8000, new string[] { "6. 등록금:0",
                                            "등록금은 메인 홈페이지의 오른쪽 메뉴바의 USER SERVICE를 통해 진행할 수 있습니다.:0",
                                            "등록금 납부는 2월 말에 합니다. 2월 말에 못했을 시, 2차 납부가 3월에 있습니다.:0",
                                            "장학금 내역을 꼼꼼히 확인한 후, 등록금을 납부합니다. 학생회비는 선택사항으로, 납부하지 않아도 큰 불이익은 없습니다.:0"
                                        });
        talkData.Add(9000, new string[] { "이상으로 오리엔테이션을 마치겠습니다! 모두 수고하셨습니다.:0",
                                            "신입생 여러분, 앞으로 가천대학교에서 좋은 추억 많이 만들고 알찬 학교생활하길 바랄게요~!! 감사합니다!!!:0",
                                            "끝나고 뒷풀이가 있으니 참석하실 분들은 저에게 와주시면 됩니다!!:0"
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
