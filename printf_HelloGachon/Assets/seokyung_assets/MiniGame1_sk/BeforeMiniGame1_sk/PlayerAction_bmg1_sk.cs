using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction_bmg1_sk : MonoBehaviour
{
    public GameManager_bmg1_sk gManager;
    public QuestManager_bmg1_sk qManager;
    Rigidbody2D rigid;
    Animator anim;
    GameObject scanObject;
    float h; //수평(Horizontal), 플레이어의 x 좌표
    float v; //수직(Vertical), 플레이어의 y 좌표
    public float playerSpeed; //플레이어의 이동속도
    bool isHorizonMove;
    Vector3 dirVec;
    int upValue;
    int downValue;
    int rightValue;
    int leftValue;
    bool upDown;
    bool upUp;
    bool leftDown;
    bool leftUp;
    bool rightDown;
    bool rightUp;
    bool downDown;
    bool downUp;

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
        h = (gManager.isInteract || gManager.objectDetect || qManager.isInteract) ? 0 : rightValue + leftValue;
        v = (gManager.isInteract || gManager.objectDetect || qManager.isInteract) ? 0 : upValue + downValue;

        bool hDown = (gManager.isInteract || gManager.objectDetect || qManager.isInteract) ? false : rightDown || leftDown;
        bool vDown = (gManager.isInteract || gManager.objectDetect || qManager.isInteract) ? false : upDown || downDown;
        bool hUp = (gManager.isInteract || gManager.objectDetect || qManager.isInteract) ? false : rightUp || leftUp;
        bool vUp = (gManager.isInteract || gManager.objectDetect || qManager.isInteract) ? false : upUp || downUp;

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

        upDown=false;
        upUp=false;
        leftDown=false;
        leftUp=false;
        rightDown=false;
        rightUp=false;
        downDown=false;
        downUp=false;

        /*
        //오브젝트 스캔
        if(Input.GetMouseButtonDown(0)) {
            if(scanObject != null) {
                gManager.interactDialog(scanObject);
            }
            else if(gManager.objectDetect){
                gManager.playerMonologue();
            }
        }
        */
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

    public void ButtonDown(string type)
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
                if(scanObject != null) {
                    gManager.interactDialog(scanObject);
                }
                break;
            case "T":
                if(scanObject != null) {
                    gManager.interactDialog(scanObject);
                }
                else if(gManager.objectDetect){
                    gManager.playerMonologue();
                }
                break;
        }
    }

    public void ButtonUp(string type)
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
        }
    }
}
