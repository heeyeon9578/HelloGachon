using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GroupManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    string[] exam={"확인중.","예시","야호"};
    public Text dialogName;
    public Text groupTalking;
    public GroupTalkManager grouptalkmanager;
    public GameObject NPC;
    public GameObject grouptalkPanel;
    public Image Img;
    public int nameIndex;
    public int groupIndex=0;
    public GroupQuestManager questmanager;
    public bool isGroup=false;
    public bool giveSel=false;
    public bool startTalk=false;
    public AudioPlay bgm;
    private void Start() {
        
        
    }
    public void StartAction()
    {
        string examdata=grouptalkmanager.GetTalk(1000,groupIndex);
        if(examdata==null){
            startTalk=false;
            grouptalkPanel.SetActive(false);
            groupIndex=0;
            return;
        }
        
        startTalk=true;
       
        groupTalking.text=examdata.Split(':')[0];
        Img.sprite=grouptalkmanager.GetPort(3000,int.Parse(examdata.Split(':')[1]));
        Img.color=new Color(1,1,1,1);
        grouptalkPanel.SetActive(true);

        groupIndex++;
        
    }
    public void GroupAction(GameObject obj)
    {
        
        NPC=obj;
        NpcData groupnpc=NPC.GetComponent<NpcData>();
        giveSel=groupnpc.isNpc;
        GroupTalking(groupnpc.id,groupnpc.isNpc);

        grouptalkPanel.SetActive(isGroup);


    }
  
    public void GroupTalking(int id, bool isNpc)
    {
        int questTalkIndex=questmanager.GetQuestTalkIndex(id);
        string groupData=grouptalkmanager.GetTalk(id+ questTalkIndex,groupIndex);
        string talkName = grouptalkmanager.getName(id, nameIndex);
        if(groupData==null){
            isGroup=false;
            groupIndex=0;
            questmanager.CheckQuest(id);
            return;
        }
        if(isNpc){
            dialogName.text=talkName;
            groupTalking.text=groupData.Split(':')[0];
            Img.sprite=grouptalkmanager.GetPort(id,int.Parse(groupData.Split(':')[1]));
            Img.color=new Color(1,1,1,1);
        }
        else{
            dialogName.text=talkName;
            Img.color=new Color(1,1,1,0);
        }
        isGroup=true;
        groupIndex++;
    }
}
