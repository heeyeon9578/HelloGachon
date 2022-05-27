using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FEQuestManager : MonoBehaviour
{
    Dictionary<int, QuestData_ots> questList;
    public FETalkManager tManager;
    public GameObject[] questObject;
    public GameObject dialogPanel;
    public Text dialogName;
    public Text dialogText;
    public bool isInteract;
    private bool isTouched = false;
    public int questId;
    public int questActionIndex;
    public int nameIndex;
    public int talkIndex;
    public AudioSource phoneAlarm;
    
    void Awake()
    {
        questList = new Dictionary<int, QuestData_ots>();
        generateData();
    }

    void Start()
    {
        isInteract = false;
        questObject[0].SetActive(true);
    }
    
    void generateData()
    {
        questList.Add(10, new QuestData_ots("카톡을 확인하자", new int[] { 2000 }));
        questList.Add(20, new QuestData_ots("한마음 페스티벌?", new int[] { 0 }));
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
        //Next Talk Target
        if (id == questList[questId].storyObjId[questActionIndex]) {
            questActionIndex++;
        }

        //Control Quest Object
        controlQuestObject();

        //Talk Complete & Next Quest
        if (questActionIndex == questList[questId].storyObjId.Length) {
            nextQuest();
        }
        
        //Quest Name
        return questList[questId].questName;
    }
    void nextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }

    void controlQuestObject()
    {
        switch(questId)
        {
            case 10:
                if(questActionIndex == 1 && isTouched == false) {
                    phoneAlarm.Stop();
                    questObject[0].SetActive(false);
                    questObject[1].SetActive(true);
                    isInteract = true;                 
                }
                break;
            case 20:
                break;
            default:
                break;
        }
    }

    public void touchPhone()
    {
        questObject[1].SetActive(false);
        isTouched = true;
        questObject[2].SetActive(true);
    }

    public void onApplyBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;

       
        GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("SYGFestival");
    }

    public void onNoBtnClick()
    {
        questObject[2].SetActive(false);
        isInteract = false;
        
       
        GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("heeRoom5");
    }
}
