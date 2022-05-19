using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
public class GRPlayerAction : MonoBehaviour
{
    
    float h;
    float v;
    public Scene curscene;
    public GameObject friend;
    public GameObject play;
    public GameObject mudang;
    public GRQuestManager quset;
    public GRTalkManager talk;
    //public GameObject option;
    Rigidbody2D rigid;
    public float speed;
    public GRManager manager;
    bool isHorizonMove;
    private Animator anim;
    Vector3 dirVec;
    GameObject scanObject;
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

    void Awake(){
        rigid=GetComponent<Rigidbody2D>();       
        anim=GetComponent<Animator>();
        curscene=SceneManager.GetActiveScene();
    }
    private void Start() {
        if(GameData.gamedata.loadscenename==curscene.name)
        {
            Going();
        }
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
        
        
        if(talk.frId==1000){
            Vector3 pos2= play.transform.position;
            var heeFriendAction = friend.GetComponent<FEFriendAction>();

            //Debug.Log("퀘스트번호가 1010일 때, 친구의 포지션을 주인공 옆으로 계속 업데이트");
            // friend.transform.Translate(Vector3(pos2.x+1,pos2.y+1, 0));
            friend.transform.position = new Vector3(pos2.x+1,pos2.y+1, 0);
            heeFriendAction.enabled = true;
        }
        //  if(Input.GetKey(KeyCode.Escape))
        // {
        //     option.SetActive(true);
        //     //Debug.Log(player.transform.position.x);
        //    // Debug.Log(player.transform.position.y);
        // }
        // GameData.gamedata.h=play.transform.position.x;
        // GameData.gamedata.v=play.transform.position.y;
        // GameData.gamedata.mudangh=mudang.transform.position.x;
        // GameData.gamedata.mudangv=mudang.transform.position.y;
        GameData.gamedata.playerpos=play.transform.position;
        GameData.gamedata.mudangpos=mudang.transform.position;
        upDown=false;
        upUp=false;
        leftDown=false;
        leftUp=false;
        rightDown=false;
        rightUp=false;
        downDown=false;
        downUp=false;
        
        // Scan Object
        // if(Input.GetButtonDown("Jump"))
        // {
        //     if(scanObject != null){
        //         manager.Action(scanObject);
        //     }else if(manager.objectDetect){
        //         manager.TestSub();
        //     }           
        // }
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
    void Going()
    {
        play.transform.position=new Vector3(GameData.gamedata.playerpos.x,GameData.gamedata.playerpos.y,0);
        mudang.transform.position=new Vector3(GameData.gamedata.mudangpos.x,GameData.gamedata.mudangpos.y,0);
       
    }
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
