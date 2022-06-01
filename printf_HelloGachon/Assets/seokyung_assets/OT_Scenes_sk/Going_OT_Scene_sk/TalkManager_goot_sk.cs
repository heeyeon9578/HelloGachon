using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager_goot_sk : MonoBehaviour
{
    Dictionary<int, string[]> talkName;
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    //초상화 스프라이트를 저장할 배열 생성
    public Sprite[] portraitArr;
    public GameObject talkPanel3; // 무당이 예/ 아니오 판넬
    public GameObject newStu; //newStu 오브젝트
    public GameObject mudang; //mudang 오브젝트
    public GameObject mudangQuest; // 무당이 내릴때 누르는 버튼
    public GameObject mudangBorderline;
    public GameObject actionKey;
    public AudioSource mudangSound;
    public QuestManager_goot_sk questManager;
    public GoingOTManager_sk gameManager;
    private Rigidbody2D rb;
        

    void Awake()
    {        
        rb = mudang.GetComponent<Rigidbody2D>();

        talkName = new Dictionary<int, string[]>();
        talkData = new Dictionary<int, string[]>(); //대화에 문장이 여러개 존재
        portraitData = new Dictionary<int, Sprite>();

        GenerateData();
    }

    //대화 생성하기
   void GenerateData(){
       //buildings
       talkData.Add(100, new string[] {"이곳은 카페다. 카페이름은 파스쿠치이다."});
       talkData.Add(200, new string[] {"이곳은 IT대학이다. AI공학관이 지어지기 전에 컴퓨터공학과 학생들이 수업을 듣던 곳이다."});
       talkData.Add(300, new string[] {"이곳은 비전타워다. 가천컨벤션센터, 우편취급국, 은행, 강의실 등이 있다."});
       talkData.Add(400, new string[] {"이곳은 비전타워다. 비전타워는 두 개의 건물이 연결되어 있다."});
       talkData.Add(500, new string[] {"이곳은 AI공학관이다. 컴퓨터공학과 학생들이 주로 사용하는 곳이다."});
       talkData.Add(600, new string[] {"이곳은 바이오나노연구원이다."});
       talkData.Add(700, new string[] {"이곳은 한의과대학이다."});
       talkData.Add(800, new string[] {"이곳은 산학관이다."});
       talkData.Add(900, new string[] {"이곳은 바이오나노대학이다."});
       talkData.Add(10000, new string[] {"이곳은 체육대학2이다."});
       talkData.Add(20000, new string[] {"이곳은 학군단이다."});
       talkData.Add(30000, new string[] {"이곳은 기숙사다."});
       talkData.Add(40000, new string[] {"이곳은 편의점이다. 편의점은 세븐일레븐이다."});
       talkData.Add(50000, new string[] {"이곳은 학생회관이다."});
       talkData.Add(60000, new string[] {"이곳은 중앙도서관이다."});
       talkData.Add(70000, new string[] {"이곳은 교육대학원이다."});
       talkData.Add(80000, new string[] {"이곳은 전자정보도서관이다."});
       talkData.Add(90000, new string[] {"이곳은 글로벌센터다."});
       talkData.Add(100000, new string[] {"이곳은 체육대학1이다."});
       talkData.Add(200000, new string[] {"이곳은 대학원이다."});
       talkData.Add(300000, new string[] {"이곳은 공과대학2이다."});
       talkData.Add(400000, new string[] {"이곳은 프리덤광장이다."});
       talkData.Add(500000, new string[] {"이곳은 가천관이다."});
       talkData.Add(600000, new string[] {"이곳은 인피니티동상이다."});
       talkData.Add(700000, new string[] {"이곳은 대운동장이다."});

       //buildings name
       talkName.Add(100, new string[] {"카페"});
       talkName.Add(200, new string[] {"IT대학"});
       talkName.Add(300, new string[] {"비전타워"});
       talkName.Add(400, new string[] {"비전타워"});
       talkName.Add(500, new string[] {"AI공학관"});
       talkName.Add(600, new string[] {"바이오나노연구원"});
       talkName.Add(700, new string[] {"한의과대학"});
       talkName.Add(800, new string[] {"산학관"});
       talkName.Add(900, new string[] {"바이오나노대학"});
       talkName.Add(10000, new string[] {"체육대학2"});
       talkName.Add(20000, new string[] {"학군단"});
       talkName.Add(30000, new string[] {" 기숙사"});
       talkName.Add(40000, new string[] {"편의점"});
       talkName.Add(50000, new string[] {"학생회관"});
       talkName.Add(60000, new string[] {"중앙도서관"});
       talkName.Add(70000, new string[] {"교육대학원"});
       talkName.Add(80000, new string[] {"전자정보도서관"});
       talkName.Add(90000, new string[] {"글로벌센터"});
       talkName.Add(100000, new string[] {"체육대학1"});
       talkName.Add(200000, new string[] {"대학원"});
       talkName.Add(300000, new string[] {"공과대학2"});
       talkName.Add(400000, new string[] {"프리덤광장"});
       talkName.Add(500000, new string[] {"가천관"});
       talkName.Add(600000, new string[] {"인피니티동상"});
       talkName.Add(700000, new string[] {"대운동장"});


       string playerName = GameData.gamedata.playerName;
       talkName.Add(7000, new string[] {  playerName });
       talkName.Add(2000, new string[] { "선배" });
       talkName.Add(8000, new string[] { "교수님" });
       talkName.Add(3000, new string[] { "무당이" });
       

       //npcs
       //시작할때 intro 대사 , 튜토리얼, npc들 익히기
       talkData.Add(7000, new string[] {"오티 장소가 AI공학관이었지?:0", "무당이를 타고 이동하자!:1"});

       //선배 default 대사
       talkData.Add(2000, new string[] {"안녕?:0", 
                                        "나는 선배야:1"});
       //무당이 default 대사
       talkData.Add(3000, new string[] {"탑승하시겠습니까?"});

       //교수님 default 대사
       talkData.Add(8000, new string[] {"허허 밤낮으로 코딩만 해도 시간이 모자라요~:0"});

       //Quest Talk(퀘스트 넘버 + npc 넘버)
       //Quest_1 AI공학관까지 이동하자!      
       talkData.Add(10 + 500, new string[] {"안으로 들어가자"});

       //portrait Data
       portraitData.Add(7000+0,portraitArr[0]); //플레이어
       portraitData.Add(7000+1,portraitArr[1]);
       portraitData.Add(2000+0,portraitArr[2]); //선배
       portraitData.Add(2000+1,portraitArr[3]);
       portraitData.Add(8000+0,portraitArr[4]); //교수
   }

    public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }

   public string GetTalk(int id, int talkIndex)
   {
       if(!talkData.ContainsKey(id)){
           if((id-questManager.GetQuestTalkIndex(id))==3000){
               if(!talkData.ContainsKey(id-id%10)){
                    //퀘스트 맨 처음 대사 마저 없을 때,
                    //기본 대사를 가져오기      
                    if(talkIndex == talkData[id-id%100].Length){                  
                        talkPanel3.SetActive(true);
                        return null;
                    }                 
                    else{
                        return talkData[id - id%100][talkIndex];
                    }
               }
            }

           else{
               if(!talkData.ContainsKey(id-id%10)){
                    //퀘스트 맨 처음 대사 마저 없을 때,
                    //기본 대사를 가져오기      
                    if(talkIndex == talkData[id-id%100].Length){
                        return null;
                    }                 
                    else{
                        return talkData[id - id%100][talkIndex];
                    }
                        
                } else{
                    //해당 퀘스트 진행 순서 중 대사가 없을 때
                    //퀘스트 맨 처음 대사를 가져옴
                    if(talkIndex == talkData[id-id%10].Length){
                        return null;
                    }                 
                    else{
                        return talkData[id - id%10][talkIndex];
                    }                
                }
            }
            
       }

       if(talkIndex==talkData[id].Length){
           return null;
       }
       else{
           return talkData[id][talkIndex];
       }
      
   }

   public Sprite GetPortrait(int id, int portraitIndex)
   {
       return portraitData[id+portraitIndex];
   }

//무당이를 탈 것인지 안 탈 것인지 물어보는 함수
   public void SelectTalk(string type){

       var heemudangAction = mudang.GetComponent<MudangAction_goot_sk>();
       var heeobjectdata =   mudang.GetComponent<heeObjectData>();
       Vector3 pos;
       pos = this.mudang.transform.position;
       switch(type){
           case "y":
                mudangSound.Play();
                talkPanel3.SetActive(false);
                mudangQuest.SetActive(true);
                actionKey.SetActive(false);
                mudangBorderline.SetActive(true);

                newStu.SetActive(false);
                gameManager.SetCameraTarget(mudang);
                
                heemudangAction.enabled = true;

                heeobjectdata.id = 12345;
                heeobjectdata.enabled= false;

                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
               
                break;
           case "n":  
                talkPanel3.SetActive(false);
                break;    
       }
   }
}
