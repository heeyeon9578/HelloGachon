using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class heeFriendAction : MonoBehaviour
{    
    float h;
    float v;

    Rigidbody2D rigid;
    public float speed;
    public heegameManager4 manager;
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
        
        
    
}

//방향키나 스페이스가 아닌, 버튼으로 조종하기 위해 추가해 준 함수들
    public void ButtonDownF2(string type)
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
    public void ButtonUpF2(string type)
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
