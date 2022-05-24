using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using Cinemachine;

public class GRManager : MonoBehaviour
{
    public int Count=0;
    private CinemachineVirtualCamera cmCamera;    
    public GRTalkManager talkManager;
    public GameObject mudangborder;
    public GameObject ActBtn;
    public GRQuestManager questManager;
    public GameObject talkPanel;
    public GameObject talkPanel2;
    public GameObject mudangDown;
    public GameObject friend;
    public Text dialogName;
    public string[] talkNameList=new string[]{"선배","친구","선배","선배","선배","선배","선배","선배","친구","친구"};
    public string[] ts=new string[]{"clsrns"};
    public Text talkText;
    public Text talkText2;
    public GameObject scanObject;
    public bool isAction;
    public bool objectDetect = false; 
    public int nameIndex;
    public int talkIndex;
    public Image portraitImg;
    public GameObject cmVcam;   // cm카메라 오브젝트
    public GameObject heetalkPanel3; // 무당이 예/ 아니오 판넬
    public GameObject heenewStu; //newStu 오브젝트
    public GameObject heemudang; //mudang 오브젝트
    private Rigidbody2D rb2;
    public int IdData;
    public bool success=false;
    public AudioPlay bgm;

  
    void Awake() {
        cmCamera = cmVcam.GetComponent<CinemachineVirtualCamera>();
        rb2 = heemudang.GetComponent<Rigidbody2D>();
    }

    void Start(){
        success=GameData.gamedata.talkend;
        if(Count==0&&!success)
            TestSub();
        else if(Count==1)
            TestSub();

    }


    public void TestSub(){
        if(Count==0)
            IdData=30;
        else if(Count==1)
            IdData=40;
        else if(Count==3)
           IdData=50;
        //처음에 게임 시작 전에 인트로가 나올 수 있도록 구성
        string talkData2 = talkManager.GetTalk(IdData, talkIndex);
        string talkName2 = talkManager.getName(IdData, nameIndex);

        //End Talk
        if(talkData2 ==null){
            objectDetect = false;
            talkPanel.SetActive(false);
            talkIndex = 0;
            success=true;
            GameData.gamedata.talkend=success;
            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됌

        }
        dialogName.text = talkName2;
        talkText.text = talkData2.Split(':')[0];
        portraitImg.sprite = talkManager.GetPortrait(IdData,int.Parse(talkData2.Split(':')[1]));
        portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정

        objectDetect = true;

        talkPanel.SetActive(true);
        talkIndex++;
        
    }
    
    // 조사대상이 있을 때만 대화창 띄우기
    public void Action(GameObject scanObj)
    {
       
        scanObject = scanObj;
        heeObjectData objData =scanObject.GetComponent<heeObjectData>();
        Talk(objData.id, objData.isNpc);
        
        talkPanel.SetActive(isAction);
    }

    public void Talk(int id, bool isNpc)
    {
        //Set Talk Data
        int questTalkIndex = questManager.GetQuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id+questTalkIndex, talkIndex);
        string talkName = talkManager.getName(id, nameIndex);

        //End Talk
        if(talkData ==null){
            isAction = false;
            talkIndex = 0;
            questManager.CheckQuest(id);
            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됌
        }

        if(isNpc){
            if(Count==3&&id==2000)
                dialogName.text = talkNameList[talkIndex];
            else if(Count==4&&id==2000)
                dialogName.text=talkName;
            else
                dialogName.text = talkName;
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정
        }else{
            dialogName.text = talkName;
            talkText.text = talkData;
            portraitImg.color = new Color(1,1,1,0);
        }

        isAction = true;
        talkIndex++;
    }
 //마우스 클릭시 퀘스트 마크가 팝업
    public void questionMark1(){
        talkPanel2.SetActive(true);
        if(Count==0)
            talkText2.text="노란색 느낌표를 찾아 프리덤 광장으로 이동해보자!";
        if(Count==1)
            talkText2.text="종합운동장으로 이동하여 선배와 대화해보자!";
        if(Count==3)
            talkText2.text = "AI공학관으로 가서 선배님을 만나보자!";
       
    }
 //마우스 클릭 후 떼어낼때 퀘스트 마크가 팝다운
    public void questionMark2(){
        talkPanel2.SetActive(false);
       
       
    }
//마우스 클릭시 무당이를 내림
    public void noneMudang(){
        var heemudangAction = heemudang.GetComponent<GRMudangAction>();
        Vector3 pos2;
        pos2 = this.heemudang.transform.position;
        mudangDown.SetActive(false);
        heetalkPanel3.SetActive(false);
        ActBtn.SetActive(true);

        var heeobjectdata = heemudang.GetComponent<heeObjectData>();
        heeobjectdata.enabled= true;
        heeobjectdata.id=3000;

        heenewStu.SetActive(true);
        friend.SetActive(true);
        mudangborder.SetActive(false);
        SetCameraTarget(heenewStu);

        heemudangAction.enabled = false;

        rb2.constraints = RigidbodyConstraints2D.FreezeAll;
        heenewStu.transform.position = new Vector3(pos2.x+1,pos2.y+1, 0);
    }

    //카메라를 위한 스크립트
    public void SetCameraTarget(GameObject followTarget)
    {
        if(cmCamera == null)
        {
            Debug.Log("cmCamera is null");                        
        }

        if(followTarget == null) Debug.Log("followTarget is null");
        cmCamera.Follow = followTarget.transform;
        cmCamera.LookAt = followTarget.transform;        
    }    

}
