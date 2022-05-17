using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_hee1 : MonoBehaviour
{
    public DialogManager_hee1 dManager;
    public QuestManager_heeots1 qManager;
    Rigidbody2D rigid;
    Animator anim;
    GameObject scanObject;
    float h; //수평(Horizontal), 플레이어의 x 좌표
    float v; //수직(Vertical), 플레이어의 y 좌표
    public float playerSpeed; //플레이어의 이동속도
    bool isHorizonMove;
    Vector3 dirVec;

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

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //수평, 수직 이동 변수
        h = (dManager.isInteract || qManager.isInteract) ? 0 : rightValue+leftValue;
        v = (dManager.isInteract || qManager.isInteract) ? 0 : upValue+downValue;

        bool hDown = (dManager.isInteract || qManager.isInteract) ? false:rightDown||leftDown;
        bool vDown = (dManager.isInteract || qManager.isInteract) ? false:upDown||downDown;
        bool hUp = (dManager.isInteract || qManager.isInteract) ? false:rightUp||leftUp;
        bool vUp = (dManager.isInteract || qManager.isInteract) ? false:upUp||downUp;

        //check horizontal move (수평이동인지 체크)
        if (hDown) {
            isHorizonMove = true;
        }
        else if (vDown) {
            isHorizonMove = false;
        }
        else if (hUp || vUp) {
            isHorizonMove = h != 0;
        }

        //플레이어가 움직이는 애니메이션
        if (anim.GetInteger("hAxisRaw") != h) {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v) {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else {
            anim.SetBool("isChange", false);
        }

        //플레이어의 방향
        if (vDown && v == 1) { //상
            dirVec = Vector3.up;
        }
        else if (vDown && v == -1) { //하
            dirVec = Vector3.down;
        }
        else if (hDown && h == -1) { //좌
            dirVec = Vector3.left;
        }
        else if (hDown && h == 1) { //우
            dirVec = Vector3.right;
        }

        //ScanObject - 방향키나 스페이스가 아닌, 버튼으로 조종하기 위해 추가
        upDown=false;
        upUp=false;
        leftDown=false;
        leftUp=false;
        rightDown=false;
        rightUp=false;
        downDown=false;
        downUp=false;
    }

    void FixedUpdate() {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * playerSpeed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 1.0f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 1.0f, LayerMask.GetMask("Object"));

        if(rayHit.collider != null) {
            scanObject = rayHit.collider.gameObject;
        }
        else {
            scanObject = null;
        }
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
                dManager.interactDialog(scanObject);
            }else if(dManager.objectDetect){
                dManager.TestSub();
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