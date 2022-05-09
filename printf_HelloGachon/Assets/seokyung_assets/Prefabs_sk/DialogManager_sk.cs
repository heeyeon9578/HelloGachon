using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager_sk : MonoBehaviour
{
    public TalkManager_ots tManager;
    public QuestManager_ots qManager;
    public GameObject dialogPanel;
    public GameObject scanObject;
    public AudioSource playerRoomBGM;
    public AudioSource phoneAlarm;
    public Text dialogName;
    public Text dialogText;
    public bool isInteract;
    public int nameIndex;
    public int talkIndex;
    
    void Start()
    {
        playerRoomBGM.Play();
        phoneAlarm.Play();
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
            dialogText.text = talkData;
        }
        else {
            dialogName.text = talkName;
            dialogText.text = talkData;
        }

        isInteract = true;
        talkIndex++;
    }
}
