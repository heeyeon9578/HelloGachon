using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Map Scene만을 위한 플레이어 움직이는 스크립트
public class PlayerAction_inMap_sk : MonoBehaviour
{
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
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        bool hDown = Input.GetButtonDown("Horizontal");
        bool vDown = Input.GetButtonDown("Vertical");
        bool hUp = Input.GetButtonUp("Horizontal");
        bool vUp = Input.GetButtonUp("Vertical");

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
