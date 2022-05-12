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
        h = (dManager.isInteract || qManager.isInteract) ? 0 : Input.GetAxisRaw("Horizontal");
        v = (dManager.isInteract || qManager.isInteract) ? 0 : Input.GetAxisRaw("Vertical");

        bool hDown = (dManager.isInteract || qManager.isInteract) ? false : Input.GetButtonDown("Horizontal");
        bool vDown = (dManager.isInteract || qManager.isInteract) ? false : Input.GetButtonDown("Vertical");
        bool hUp = (dManager.isInteract || qManager.isInteract) ? false : Input.GetButtonUp("Horizontal");
        bool vUp = (dManager.isInteract || qManager.isInteract) ? false : Input.GetButtonUp("Vertical");

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

        //오브젝트 스캔
        if(Input.GetMouseButtonDown(0) && scanObject != null) {
            dManager.interactDialog(scanObject);
        }
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
}