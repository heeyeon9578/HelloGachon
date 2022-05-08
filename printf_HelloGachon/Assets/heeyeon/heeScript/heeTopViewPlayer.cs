using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class heeTopViewPlayer : MonoBehaviour
{
    
    float h;
    float v;

    Rigidbody2D rigid;
    public float speed;
    public heegameManager manager;
    bool isHorizonMove;
    private Animator anim;
    Vector3 dirVec;
    GameObject scanObject;

    void Awake(){
        rigid=GetComponent<Rigidbody2D>();       
        anim=GetComponent<Animator>();
    }
    void Update(){

        //Move Value
        h=manager.isAction ? 0:Input.GetAxisRaw("Horizontal");
        v=manager.isAction ? 0:Input.GetAxisRaw("Vertical");

        //Check Button Down & up 오브젝트랑 소통할때 플레이어가 못 움직이게 한다.
        bool hDown=manager.isAction ? false:Input.GetButtonDown("Horizontal");
        bool vDown=manager.isAction ? false:Input.GetButtonDown("Vertical");
        bool hUp=manager.isAction   ? false:Input.GetButtonUp("Horizontal");
        bool vUp=manager.isAction   ? false:Input.GetButtonUp("Vertical");
        
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
        
        
        
        //Scan Object
        if(Input.GetButtonDown("Jump"))
        {
            if(scanObject != null){
                manager.Action(scanObject);
            }else if(manager.objectDetect){
                manager.TestSub();
            }           
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
}
