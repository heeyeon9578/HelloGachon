using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0108
public class MG2PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    float h=0;
    float v=0;
    private Rigidbody2D rigidbody;
    private float speed=3;
    private float horizontal;
    private Animator animator;
    private SpriteRenderer renderer;
    public bool isDie=false;
    public int life;
    public Image[] lifeIcon=null;
    public Sprite changelife;
    public GameObject player;
    private float WinTime;
    public bool LeftMove=false;
    public bool RightMove=false;
    Vector3 moveVelocity=Vector3.zero;
    Vector3 dirVec;
    bool isHorizonMove;
    int rightValue=0;
    int leftValue=0;
    bool leftDown=false;
    bool leftUp=false;
    bool rightDown=false;
    bool rightUp=false;
    public GameObject SFX;
    private AudioSource sfxSource;
    
    // Start is called before the first frame update
    void Start()
    {
       rigidbody=GetComponent<Rigidbody2D>();
       animator=GetComponent<Animator>();
       renderer=GetComponent<SpriteRenderer>();
       sfxSource=SFX.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!isDie)
         PlayerMoveMobile();
       if(isDie)
       {
           animator.SetTrigger("dead");
       }
       ScreenRange();
    }
    void sfxButton()
    {
        sfxSource.loop=false;
        sfxSource.Play();
    }
    public void PlayerMoveMobile(){
        h=rightValue+leftValue;
        bool hDown=rightDown||leftDown;
        bool hUp=rightUp||leftUp;
         if(hDown)
            isHorizonMove=true;
        else if(hUp)
            isHorizonMove=h !=0;
         if(animator.GetInteger("hAxisRaw")!=h){
            animator.SetBool("isChange",true);
            animator.SetInteger("hAxisRaw",(int)h);
        } else
            animator.SetBool("isChange",false);
        if(hDown && h==-1)
            dirVec=Vector3.left;
        else if(hDown && h==1)
            dirVec=Vector3.right;

        leftDown=false;
        leftUp=false;
        rightDown=false;
        rightUp=false;
        

    }
    void FixedUpdate() {
        Vector2 moveVec=isHorizonMove?new Vector2(h,0):new Vector2(0,v);
        rigidbody.velocity=moveVec*speed;
    }
    
    private void ScreenRange()
    {
        Vector3 a=Camera.main.WorldToViewportPoint(this.transform.position);
        if(a.x<0.02f)a.x=0.02f;
        if(a.x>0.97f)a.x=0.97f;
        this.transform.position=Camera.main.ViewportToWorldPoint(a);
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag=="Soju")
        {
            sfxButton();
            if(life>0){
                life--;
                UpdateIcon(life);
            }  
            
            
            if(life<=0){
                sfxButton();
                GameObject.Find("MG2Manager").GetComponent<MG2Manager>().GameOver();
            }
            Destroy(collision.gameObject);
        }
    }
    private void UpdateIcon(int life)
    { 
        lifeIcon[life].sprite=changelife;   
            
    }
    public void ButtonDown(string type){
        switch (type)
        {
            case "R":
                rightDown=true;
                rightValue=1;
                break;
            case "L":
                leftDown=true;
                leftValue=-1;
                break;
        }
    }
    public void ButtonUp(string type){
        switch (type)
        {
            case "R":
                rightValue=0;
                rightUp=true;
                break;
            case "L":
                leftValue=0;
                leftUp=true;
                break;
        }

    }

   
}
