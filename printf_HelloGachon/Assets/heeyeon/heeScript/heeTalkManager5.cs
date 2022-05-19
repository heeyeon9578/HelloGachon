using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heeTalkManager5 : MonoBehaviour
{
    Dictionary<int, string[]> talkName;
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    //초상화 스프라이트를 저장할 배열 생성
    public Sprite[] portraitArr;

    public GameObject talkPanel3; // 무당이 예/ 아니오 판넬
    public GameObject talkPanel4;
    public GameObject talkPanel5;
    public Text talkText3;
    public GameObject newStu; //newStu 오브젝트
    public GameObject mudang; //mudang 오브젝트
    public GameObject friend; //friend 오브젝트
    public GameObject gilyae; //gilyae 오브젝트
    private AudioSource audioSource;
    public AudioClip audioClip;
    public GameObject mudangQuest; // 무당이 내릴때 누르는 버튼


    public heeQuestManager5 questManager;
    public heegameManager5 gameManager;

    public int heeid;
    public int heeid2;

    private Rigidbody2D rb;
    private Rigidbody2D rb2;
    Vector3 pos2;

    void Awake()
    {        
        talkName = new Dictionary<int, string[]>();
        rb = mudang.GetComponent<Rigidbody2D>();
        rb2 = friend.GetComponent<Rigidbody2D>();
        audioSource = this.GetComponent<AudioSource>();

        talkData = new Dictionary<int, string[]>(); //대화에 문장이 여러개 존재
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    //대화 생성하기
   void GenerateData(){

           //npcs
       //시작할 때 대사
       talkData.Add(7000, new string[] {"기말고사 공부하느라 많이 힘들지? 간식 받고 힘내~:4","AI공학관 앞으로 나를 찾아오면 던킨도너츠랑 커피를 받을 수 있어~:4", 
                                        "무당이를 타고 와도 돼!:4", "나랑 같이 가자! AI공학관에 가기 전에 나를 먼저 찾아와~!:5"});

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

       //talkname
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
       talkName.Add(30000, new string[] {"기숙사"});
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

  
       
       talkName.Add(2000, new string[] { "선배" });
       talkName.Add(7000, new string[] { ""});
       talkName.Add(1000, new string[] { "친구" });
       talkName.Add(3000, new string[] { "무당이" });
       talkName.Add(8000, new string[] { "교수님" });
       talkName.Add(6000, new string[] { "이길여 총장님" });
       //친구 default 대사
       talkData.Add(1000, new string[] {"안녕? 나도 컴공 신입생이야!:0", 
                                        "만나서 반가워~ 친하게 지내자!:2",
                                        "가천관 쪽에 이길여 총장님께서 가끔 계신다던데..:0"});
       //선배 default 대사
       talkData.Add(2000, new string[] {"안녕?:0", 
                                        "인피니티동상 쪽에 이길여 총장님께서 가끔 계신다던데..:2"});
       //무당이 default 대사
       talkData.Add(3000, new string[] {"탑승하시겠습니까?"});

       //교수님 default 대사
       talkData.Add(8000, new string[] {"허허 밤낮으로 코딩만 해도 시간이 모자라요~:1",
                                        "이길여 총장님께서 학교에 가끔 방문하십니다..:0"});
       //이길여 총장님 대사
       talkData.Add(6000, new string[] {"박애 봉사 애국^^:0"});
       //Quest Talk(퀘스트 넘버 + npc 넘버)

       //Quest_5 5월 간식행사 
       talkData.Add(10+ 1000, new string[] {"잘 찾아왔어!!:0","AI공학관까지 나랑 같이 걸어가거나 무당이를 타고 가자!:1"});
       talkData.Add(11+2000, new string[] {"오느라 고생했어!!:0", "여기 던킨도너츠랑 커피를 줄게!!:4", "기말고사 공부 화이팅!!:2","아 곧 이길여 총장님 오시나보네..:0"});
       talkData.Add(20+6000 , new string[] {"어서오십시오~^^:0", " 저는 가천대 지킴이 이길여 총장입니다~:0", "스가이에 드는 명문 가천에 오신걸 진심으로 축하드려요~^^ :0"
                                           });

       //portrait Data
       portraitData.Add(7000+0,portraitArr[0]); //플레이어 및 인트로에 쓰일 선배와 친구
       portraitData.Add(7000+1,portraitArr[1]);
       portraitData.Add(7000+2,portraitArr[2]);
       portraitData.Add(7000+3,portraitArr[3]);
       portraitData.Add(7000+4,portraitArr[17]); //선배
       portraitData.Add(7000+5,portraitArr[18]); //친구
       


       portraitData.Add(1000+0,portraitArr[4]);//친구
       portraitData.Add(1000+1,portraitArr[5]); 
       portraitData.Add(1000+2,portraitArr[6]);
       portraitData.Add(1000+3,portraitArr[7]);


       portraitData.Add(2000+0,portraitArr[8]); //선배
       portraitData.Add(2000+1,portraitArr[9]);
       portraitData.Add(2000+2,portraitArr[10]);
       portraitData.Add(2000+3,portraitArr[11]);
       portraitData.Add(2000+4,portraitArr[19]); //선배 + 던킨도너츠 + 커피

       portraitData.Add(8000+0,portraitArr[12]); //교수
       portraitData.Add(8000+1,portraitArr[13]);
       portraitData.Add(8000+2,portraitArr[14]);
       portraitData.Add(8000+3,portraitArr[15]);


       portraitData.Add(6000+0,portraitArr[16]); //이길여 총장님



   }

   public string getName(int id, int nameIndex)
    {
        return talkName[id][nameIndex];
    }

   public string GetTalk(int id, int talkIndex)
   {   
       heeid2=id;    

       Debug.Log(id);

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
                 
           }}else if((id-questManager.GetQuestTalkIndex(id))==500){
               if(!talkData.ContainsKey(id-id%10)){
               //퀘스트 맨 처음 대사 마저 없을 때,
               //기본 대사를 가져오기      
               if(talkIndex == talkData[id-id%100].Length){
                  
                  talkPanel5.SetActive(true);
                  return null;
               }                 
               else{
                    return talkData[id - id%100][talkIndex];

               }
           }}
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
                 
           }else{
          
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

          

          //퀘스트 1000일때, 실행할 것
          if((id-questManager.GetQuestTalkIndex(id))==1000){

                heeid = id;
                rb2.constraints = RigidbodyConstraints2D.None;
                rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
                pos2 = newStu.transform.position;
                friend.transform.position = new Vector3(pos2.x+1,pos2.y+1, 0);

           }

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

       var heemudangAction5 = mudang.GetComponent<heeMudangAction5>();
       var heeobjectdata =   mudang.GetComponent<heeObjectData>();
       Vector3 pos;
       pos = this.mudang.transform.position;
       switch(type){
           case "y": 
                audioSource.clip = audioClip;
                audioSource.loop = false;               
                audioSource.Play();
                talkPanel3.SetActive(false);
                mudangQuest.SetActive(true);

                newStu.SetActive(false);
                friend.SetActive(false);

                gameManager.SetCameraTarget(mudang);
                
                heemudangAction5.enabled = true;

                heeobjectdata.id = 12345;
                heeobjectdata.enabled= false;

                rb.constraints = RigidbodyConstraints2D.None;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
                talkText3.text += "\n무당이에서 내리고 싶을 때 상단 초록색 버튼을 클릭하면 됩니다.";
               
                break;
           case "n":  
                talkPanel3.SetActive(false);
                break;    
       }
   }
  //다음 씬으로 넘어갈 수 있도록 하기
   public void SelectTalk2(string type){

       switch(type){
           case "y":
                GameData.gamedata.health += 5;
                Debug.Log("5월 간식 이벤트로 체력+5 ");
                talkPanel4.SetActive(false);
                //성재님의 6월수업씬으로 이동
                SceneManager.LoadScene("MiniGame3");
                break;

       }

   }
}
