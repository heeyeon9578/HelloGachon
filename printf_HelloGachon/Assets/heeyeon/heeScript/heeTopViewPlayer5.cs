using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class heeTopViewPlayer5 : MonoBehaviour
{
    
    float h;
    float v;

    Rigidbody2D rigid;
    public float speed;
    public heegameManager5 manager;
    bool isHorizonMove;
    private Animator anim;
    Vector3 dirVec;
    GameObject scanObject;

    //방향키나 스페이스가 아닌, 버튼으로 조종하기 위해 추가해주어야 하는 변수들
    int upValue=0;
    int downValue=0;
    int rightValue=0;
    int leftValue=0;
    bool upDown=false;
    bool upUp=false;
    bool leftDown=false;
    bool leftUp=false;
    bool rightDown=false;
    bool rightUp=false;
    bool downDown=false;
    bool downUp=false;
    

    public GameObject friend; //friend 오브젝트
    public GameObject newStu;
    public heeQuestManager5 questManager;
    public heeTalkManager5 talkManager;

    

    void Awake(){
        rigid=GetComponent<Rigidbody2D>();       
        anim=GetComponent<Animator>();
    }
    void Update(){

        //Move Value
        h=manager.isAction ? 0:rightValue+leftValue;
        v=manager.isAction ? 0:upValue+downValue;

        //Check Button Down & up 오브젝트랑 소통할때 플레이어가 못 움직이게 한다.
        bool hDown=manager.isAction ? false:rightDown||leftDown;
        bool vDown=manager.isAction ? false:upDown||downDown;
        bool hUp=manager.isAction   ? false:rightUp||leftUp;
        bool vUp=manager.isAction   ? false:upUp||downUp;
        //Check Horizontal Move
        if(hDown)
            isHorizonMove=true;
        else if(vDown)
            isHorizonMove=false;
        else if(hUp||vUp)
            isHorizonMove=h !=0;

        //Animation
        if(anim.GetInteger("hAxisRaw")!=h){
            anim.SetBool("isChange",true);
            anim.SetInteger("hAxisRaw",(int)h);
        }
        else if(anim.GetInteger("vAxisRaw")!=v){
            anim.SetBool("isChange",true);
            anim.SetInteger("vAxisRaw",(int)v);
        }
        else
            anim.SetBool("isChange",false);

        //Direction
        if(vDown && v==1)
            dirVec=Vector3.up;
        else if(vDown && v==-1)
            dirVec=Vector3.down;
        else if(hDown && h==-1)
            dirVec=Vector3.left;
        else if(hDown && h==1)
            dirVec=Vector3.right;
        
        
        
        //ScanObject - 방향키나 스페이스가 아닌, 버튼으로 조종하기 위해 추가
        upDown=false;
        upUp=false;
        leftDown=false;
        leftUp=false;
        rightDown=false;
        rightUp=false;
        downDown=false;
        downUp=false;
        //퀘스트번호가 1010일 때, 친구의 포지션을 주인공 옆으로 계속 업데이트

        if(talkManager.heeid==1010){
            Vector3 pos2= newStu.transform.position;
            var heeFriendAction5 = friend.GetComponent<heeFriendAction5>();

            Debug.Log("퀘스트번호가 1010일 때, 친구의 포지션을 주인공 옆으로 계속 업데이트");
            // friend.transform.Translate(Vector3(pos2.x+1,pos2.y+1, 0));
            friend.transform.position = new Vector3(pos2.x+1,pos2.y+1, 0);
            heeFriendAction5.enabled = true;
        }


        
    }
    void FixedUpdate() {
        Vector2 moveVec=isHorizonMove?new Vector2(h,0):new Vector2(0,v);
        rigid.velocity=moveVec*speed;

        Debug.DrawRay(rigid.position,dirVec*0.7f,new Color(0,1,0));
        RaycastHit2D rayHit=Physics2D.Raycast(rigid.position,dirVec,0.7f,LayerMask.GetMask("Object"));

        if(rayHit.collider!=null){
            scanObject=rayHit.collider.gameObject;
        }
        else
            scanObject=null;
        
    }

    //방향키나 스페이스가 아닌, 버튼으로 조종하기 위해 추가해 준 함수들
    public void ButtonDown2(string type)
    {
        switch (type)
        {
            case "U":
                upValue=1;
                upDown=true;
                break;
            case "D":
                downDown=true;
                downValue=-1;
                break;
            case "L":
                leftDown=true;
                leftValue=-1;
                break;
            case "R":
                rightDown=true;
                rightValue=1;
                break;
            case "A":
                if(scanObject != null){
                manager.Action(scanObject);
            }else if(manager.objectDetect){
                manager.TestSub();
            }    
                break;
        }
    }
    public void ButtonUp2(string type)
    {
        switch (type)
        {
            case "U":
                upValue=0;
                upUp=true;
                break;
            case "D":
                downValue=0;
                downUp=true;
                break;
            case "L":
                leftValue=0;
                leftUp=true;
                break;
            case "R":
                rightValue=0;
                rightUp=true;
                break;
            case "A":
                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.tag=="Freedom")
        {
            Debug.Log("free");
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().startFadeOut2();
        }
    }
}
