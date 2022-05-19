using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager_hee6 : MonoBehaviour
{
    public TalkManager_heeots3 tManager;
    public QuestManager_heeots6 qManager;
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
        Debug.Log(qManager.checkQuest());
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
        if(talkData == null) {
            isInteract = false;
            talkIndex = 0;
            Debug.Log(qManager.checkQuest(id));
            return;
        }
        
        //Continue Talk
        if (isStoryObj) {

            dialogName.text = talkName;
            dialogText.text = talkData.Split(':')[0];
            portraitImg.sprite = tManager.GetPortrait(id,int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1,1,1,1); //맨 끝이 투명도로, npc일때만 이미지가 나오도록 설정
        }
        else {
            dialogName.text = talkName;
            dialogText.text = talkData;
            portraitImg.color = new Color(1,1,1,0);
        }

        isInteract = true;
        talkIndex++;
    }
}
