using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYGTalkManager : MonoBehaviour
{
    // Start is called before the first frame update
    Dictionary<int,string[]> talkData;
   
    string[] data1={"지금 프리덤 광장에서 동아리 홍보를 하고 있어.","보러갈래?"};
    string[] data2={"프리덤 광장으로 가자."};
    string[] data3={"아쉽지만 어쩔 수 없지."};
    string[] data4={"굉장히 많은 동아리가 있는 걸?","어떤 동아리가 있는지 한번 볼까?"};
    string[] MTGO={"안녕? 이번에 MT를 가는데 혹시 참여할 생각 있니?"};
    string[] MTGOY={"좋은 생각이야!","9시까지 대운동장으로 와!"};
    string[] MTGON={"아쉽지만 어쩔 수 없지."};
    string[] yesi={"탑승하시겠습니까?"};
    public string[] MTEND={"어서 와! 정말 기대되는 걸!","즐겁게 놀면서 많은 동기들과 친해지자!","술은 적당히 마시고!"};
    public GameObject Select;
    public GameObject[] mtNPC;
    public bool isEnd=false;
    public SYGTopViewManager topviewmanager;
    public int selectid=0;
    public int count=0;
    public bool selectnpc=false;
    public GameObject Pan;
    public GameObject GroupGoing;
    void Awake(){
        talkData=new Dictionary<int,string[]>();
        
        StartTalking(1000,data1);
        StartTalking(100,MTGO);
        StartTalking(300,yesi);
       
        
    }
    public void StartTalking(int id,string[] data)
    {
        talkData.Add(id,data);
        //topviewmanager.Talk(1000,true);
        //Pan.SetActive(true);  
    }
  
    public void SelectTalk(string type)
    {
        selectid=topviewmanager.selid;
       
        switch(type)
        {
            
            case "Y":
            if(selectid==1000)
            {
                isEnd=true;
                Select.SetActive(false);
                GroupGoing.SetActive(true);
                talkData[selectid]=data2;
                topviewmanager.startTopView();
                Pan.SetActive(true);
                
            }
            else if(selectid==100)
            {
                isEnd=true;
                Select.SetActive(false);
                for(int i=0;i<mtNPC.Length;i++)
                {
                    mtNPC[i].SetActive(true);
                }
                talkData[selectid]=MTGOY;
                topviewmanager.startTopView();
                Pan.SetActive(true);
            }
            break;
            case "N":
            if(selectid==1000)
            {
                isEnd=true;
                Select.SetActive(false);
                talkData[selectid]=data3;
                topviewmanager.startTopView();
                Pan.SetActive(true);
            }
            else if(selectid==100)
            {
                isEnd=true;
                Select.SetActive(false);
                talkData[selectid]=MTGON;
                topviewmanager.startTopView();
                Pan.SetActive(true);
            }
            break;
        }

    }
    public string GetTalk(int id,int talkIndex)
    {
        if(id==1000){  
            if(talkIndex==talkData[id].Length){
                if(!isEnd){
                    Select.SetActive(true);
                }
                return null;
            }
            else
                return talkData[id][talkIndex];
        }
        if(id==300){  
            if(talkIndex==talkData[id].Length){
                if(!isEnd){
                    Select.SetActive(true);
                }
                return null;
            }
            else
                return talkData[id][talkIndex];
        }
        if(id==100)
        {
           
            if(talkIndex==talkData[id].Length){
                if(!isEnd){
                    Select.SetActive(true);
                }
                if(talkData[id]==MTGOY){
                    talkData[id]=MTEND;
                    selectnpc=true;
                }
                    //GameObject.Find("Canvas").GetComponent<FadeINOUT>().MTstartFadeOut();
                return null;
            }
            else
                return talkData[id][talkIndex];               
        }       
        if(talkIndex==talkData[id].Length){
            return null;
        }
        else
            return talkData[id][talkIndex];
    

    }
}
