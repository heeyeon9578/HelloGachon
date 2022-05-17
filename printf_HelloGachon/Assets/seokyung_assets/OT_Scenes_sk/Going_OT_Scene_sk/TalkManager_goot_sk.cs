using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager_goot_sk : MonoBehaviour
{
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
    public QuestManager_goot_sk questManager;
    public GoingOTManager_sk gameManager;
    private Rigidbody2D rb;
        

    void Awake()
    {        
        rb = mudang.GetComponent<Rigidbody2D>();
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

       //npcs
       //시작할때 intro 대사 , 튜토리얼, npc들 익히기
       talkData.Add(7000, new string[] {"오티 장소가 AI공학관이었지?:0", "무당이를 타고 이동하자!:1"});

       //무당이 default 대사
       talkData.Add(3000, new string[] {"탑승하시겠습니까?"});

       //Quest Talk(퀘스트 넘버 + npc 넘버)
       //Quest_1 AI공학관까지 이동하자!      
       talkData.Add(10 + 500, new string[] {"안으로 들어가자"});

       //portrait Data
       portraitData.Add(7000+0,portraitArr[0]);
       portraitData.Add(7000+1,portraitArr[1]);
   }

   public string GetTalk(int id, int talkIndex)
   {       
       Debug.Log(id);
       if(!talkData.ContainsKey(id)){
           Debug.Log(id);
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
