using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager_hee1 : MonoBehaviour
{
    public TalkManager_heeots1 tManager;
    public QuestManager_heeots1 qManager;
    public GameObject dialogPanel;
    public GameObject scanObject;
    public Text dialogName;
    public Text dialogText;    
    public bool isInteract;
    public int nameIndex;
    public int talkIndex;
    

    public Image portraitImg;
    public bool objectDetect = false; 

    void Start()
    {
        TestSub();
        // Debug.Log(qManager.checkQuest());
    }

    public void TestSub(){
        string talkData2 = tManager.getTalk(3000, talkIndex); //처음에 게임 시작 전에 인트로가 나올 수 있도록 구성

        //End Talk
        if(talkData2 ==null){
            objectDetect = false;
            talkIndex = 0;
            dialogPanel.SetActive(false);

            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됌

        }
        
        dialogText.text = talkData2.Split(':')[0];
        portraitImg.sprite = tManager.GetPortrait(3000,int.Parse(talkData2.Split(':')[1]));
        portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정

        objectDetect = true;

        dialogPanel.SetActive(true);
        talkIndex++;
        
    }

    public void interactDialog(GameObject scanObj)
    {
        //Exit Dialog
        scanObject = scanObj;
        ObjData_sk objData = scanObject.GetComponent<ObjData_sk>();
        talk(objData.id, objData.isStoryObj);

        dialogPanel.SetActive(isInteract);
    }

    void talk(int id, bool isStoryObj)
    {
        //Set Talk name, data
        int questTalkIndex = qManager.getQuestTalkIndex(id);
        string talkName = tManager.getName(id, nameIndex);
        string talkData =  tManager.getTalk(id + questTalkIndex, talkIndex);

        //End Talk
        if(talkData ==null){
            isInteract = false;
            talkIndex = 0;
            // Debug.Log(qManager.CheckQuest(id));
            // dialogPanel.SetActive(false);

            return; //void 에서 return 가능(강제 종료 기능)-> return 뒤에 아무것도 안쓰면 됌

        }
        
        //Continue Talk
        if (isStoryObj) {
            dialogText.text = talkData.Split(':')[0];
            portraitImg.sprite = tManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정
        }
        else {
            dialogText.text = talkData;
            portraitImg.color = new Color(1,1,1,0);
        }

        isInteract = true;
        talkIndex++;
    }

}
