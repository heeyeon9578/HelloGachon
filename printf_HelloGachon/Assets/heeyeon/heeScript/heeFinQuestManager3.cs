using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class heeFinQuestManager3 : MonoBehaviour
{
    Dictionary<int, heeFinQuestData3> questList;
    public heeFinManager3 oManager;
    public heeFinTalkManager3 tManager;
    public GameObject[] questObject;
    public GameObject dialogPanel;
    public Text dialogName;
    public Text dialogText;
    public Image portraitImg;
    public bool isInteract;
    public bool isTalking;
    public bool isChoosing;
    public int btnId;
    public int questId;
    public int questActionIndex;
    public int nameIndex;
    public int talkIndex;

    public Text questText;
    
    void Awake()
    {
        questText.text ="선배에게 말걸기";
        questList = new Dictionary<int, heeFinQuestData3>();
        generateData();
        
    }

    void Start()
    {
        isInteract = false;
        isTalking = false;
        isChoosing = false;
    }
    
    void generateData()
    {
        // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
        questList.Add(10, new heeFinQuestData3("선배님께 말걸자!", new int[] { 2000 }));
        questList.Add(20, new heeFinQuestData3("입학식 시작!", new int[] { 200, 2000 }));
        questList.Add(30, new heeFinQuestData3("수업에 갈까?", new int[] { 2000 }));
        questList.Add(40, new heeFinQuestData3("입학식 씬 종료!", new int[] { 0 }));
    }

    public int getQuestTalkIndex(int id)
    {
        return questId + questActionIndex;
    }

    public string checkQuest()
    {
        //Quest Name
        return questList[questId].questName;
    }

    public string checkQuest(int id)
    {
        //Control Quest Object
        controlQuestObject();

        //Next Talk Target
        if (id == questList[questId].storyObjId[questActionIndex]) {
            questActionIndex++;
        }

        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].storyObjId.Length) {
            nextQuest();
        }
        
        //Quest Name
        return questList[questId].questName;
    }

    void nextQuest()
    {
        questActionIndex = 0;
        questId += 10;
    }

    public void controlQuestObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 0) {
                    questObject[1].SetActive(true);    
                    questText.text ="지정석에 앉기";                        
                }
                break;
            case 20:
                if(questActionIndex == 0 && oManager.objDataId == 200) {
                    isTalking = true;
                    oManager.isInteract = true;
                    questObject[0].SetActive(true);  
                                                    
                }
                if(questActionIndex == 1) {
                    questObject[1].SetActive(false);
                    questText.text ="선배에게 말 걸기";
                }
                break;
            case 30:
                if(questActionIndex == 0) {
                    isChoosing = true;
                    questObject[2].SetActive(true);
                }
                break;
            default:
                break;
        }
    }

    //선택지 버튼 눌렀을 때 실행되는 함수들
    // 1.학번 및 홈페이지 2.수강신청 3.사이버캠퍼스 4.학사행정 5.비교과신청(WIND) 6.등록금 7.건너뛰기
    public void on1BtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 3000;
        introduceTalk();

        //1번 누르면 학번 및 홈페이지 설명
        Debug.Log("1번 누르면 MT 설명");
    }
    public void on2BtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 4000;
        introduceTalk();

        //2번 누르면 수강신청 설명
        Debug.Log("2번 누르면 동아리홍보전 설명");
    }
    public void on3BtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 5000;
        introduceTalk();

        //3번 누르면 사이버캠퍼스 설명
        Debug.Log("3번 누르면 학생회가입 설명");
    }
    public void on4BtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 6000;
        introduceTalk();

        //4번 누르면 학사행정 설명
        Debug.Log("4번 누르면 간식행사 설명");
    }
    public void on5BtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 7000;
        introduceTalk();

        //5번 누르면 비교과신청(WIND) 설명
        Debug.Log("5번 누르면 한마음 페스티벌 설명");
    }
    public void on6BtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 8000;
        introduceTalk();

        //6번 누르면 등록금 설명
        Debug.Log("6번 누르면 중간고사, 기말고사 설명");
    }
    public void onSkipBtnClick()
    {
        questObject[0].SetActive(false);
        btnId = 9000;
        isTalking = false;
        introduceTalk();

        //건너뛰기 누르면 오티 씬 종료
        Debug.Log("건너뛰기");
    }

    public void introduceTalk(){
        string talkName = tManager.getName(btnId, nameIndex);
        string talkData = tManager.getTalk(btnId, talkIndex);

        //End Talk
        if(talkData == null){
            isInteract = false;        
            oManager.isInteract = false;
            talkIndex = 0;
            oManager.talkIndex = 0;
            dialogPanel.SetActive(false);
            if(isTalking) {
                questActionIndex = 0;
                controlQuestObject();
            }
            else {                
                questActionIndex = 1;
                controlQuestObject();             
            }            
            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됨
        }
        
        dialogName.text = talkName;
        dialogText.text = talkData.Split(':')[0];
        portraitImg.sprite = tManager.getPortrait(btnId, int.Parse(talkData.Split(':')[1]));
        portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정

        isInteract = true;
        talkIndex++;

        dialogPanel.SetActive(true);
    }

    public void onApplyBtnClick()
    {
        questObject[2].SetActive(false);
        isChoosing = false;

        //3월 수업 씬으로 전환
        Debug.Log("수업 들으러 가기");
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("MiniGame3");
    }


}
