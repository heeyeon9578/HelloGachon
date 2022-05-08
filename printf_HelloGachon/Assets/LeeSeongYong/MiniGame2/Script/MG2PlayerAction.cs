using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable CS0108
public class MG2PlayerAction : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody;
    private float speed=3;
    private float horizontal;
    private Animator animator;
    private SpriteRenderer renderer;
    public bool isDie=false;
    public int life;
    public Image[] lifeIcon=null;
    public Sprite changelife;
    private float WinTime;
    public bool LeftMove=false;
    public bool RightMove=false;
    Vector3 moveVelocity=Vector3.zero;
  
    
    
    // Start is called before the first frame update
    void Start()
    {
       rigidbody=GetComponent<Rigidbody2D>();
       animator=GetComponent<Animator>();
       renderer=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxis("Horizontal");
       if(!isDie)
       PlayerMoveMobile();
       //PlayerMove();
       if(isDie)
       {
           animator.SetTrigger("dead");
       }
       ScreenRange();
    }
    public void PlayerMoveMobile(){
        animator.SetFloat("speed",Mathf.Abs(horizontal));
        if(!LeftMove&&!RightMove){
            animator.SetBool("rightgo",false);
        }
        else if(LeftMove){
            animator.SetBool("rightgo",true);
            transform.localScale=new Vector3(-1,1,1);
            rigidbody.velocity=new Vector2(-0.6f*speed,rigidbody.velocity.y);
        }
        else if(RightMove){
            animator.SetBool("rightgo",true);
            transform.localScale=new Vector3(1,1,1);
            rigidbody.velocity=new Vector2(0.6f*speed,rigidbody.velocity.y);
        }

    }
    public void PlayerMove()
    {
        animator.SetFloat("speed",Mathf.Abs(horizontal));
        if(horizontal<0)
        {
            renderer.flipX=true;
        }
        else
        {
            renderer.flipX=false;
        }
        rigidbody.velocity=new Vector2(horizontal*speed,rigidbody.velocity.y);
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
            life--;
            UpdateIcon(life);
            
            if(life<=0){
                
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
                RightMove=true;
                break;
            case "L":
                LeftMove=true;
                break;
        }
    }
    public void ButtonUp(string type){
        switch (type)
        {
            case "R":
                RightMove=false;
                break;
            case "L":
                
                LeftMove=false;
                break;
        }

    }

   
}
