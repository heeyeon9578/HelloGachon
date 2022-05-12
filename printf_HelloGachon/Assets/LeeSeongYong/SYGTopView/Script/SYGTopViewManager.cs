using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SYGTopViewManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image fadeImage;
    public Sprite changeImage;
    public Text talking;
    public SYGTalkManager talkmanager;
    public GameObject Npc;
    public GameObject talkingPanel;
    public bool isTalk;
    public int talkIndex;
    public int selid;
    public bool isSel;
    public bool isStart=false;
    public int Month=0;
    
    private void Start() {
        if(Month==3)
            startTopView();
        else if(Month==4)
            startTopView();
        
    }
    public void startTopView()
    {
            if(Month==3)
                selid=1000;
            else if(Month==4)
                selid=100;
            
            string talkData2=talkmanager.GetTalk(selid,talkIndex);
            if(talkData2==null){
                isStart=false;
                talkingPanel.SetActive(false);
                talkIndex=0;
                return;
            }
            isStart=true;
            talking.text=talkData2;
            talkingPanel.SetActive(true);
            talkIndex++;
        
    }
    public void TalkingAction(GameObject obj)
    {
        Npc=obj;
        NpcData npcData=Npc.GetComponent<NpcData>();
        selid=npcData.id;
        isSel=npcData.isNpc;
        Talk(npcData.id,npcData.isNpc); 

         talkingPanel.SetActive(isTalk);
    }

    public void Talk(int id,bool isNpc)
    {
        string talkData=talkmanager.GetTalk(id, talkIndex);
        if(talkmanager.selectnpc)
        {
            if(talkData==null)
            {
                fadeImage.sprite=changeImage;
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().MTstartFadeOut();
                isTalk=false;
                talkIndex=0;
                return;
            }
        }
        if(talkData==null){
            isTalk=false;
            talkIndex=0;
            return;
        }
        if(isNpc){
            talking.text=talkData;
        }else{
            talking.text=talkData;
        }
        isTalk=true;
        talkIndex++;
      
    }
}
