using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupTalkManager : MonoBehaviour
{
    
    Dictionary<int,string[]> groupTalk;
    Dictionary<int,Sprite> traitData;
    string[] ezzz={"우리는 운동을 하면서 친목을 다지는 동아리야.:0","혹시 관심 있니?:2"};
    string[] firstTalk={"와 동아리 종류가 많은 걸? 무슨 동아리가 있는지 둘러보자!:1"};
    string[] endTalk={"어떤 동아리에 가입할거니?:0"};
    string[] selectBand={"재밌겠는걸? 나도 가입해봐야 겠다.:2"};
    string[] selectMajor={"학과 공부까지 같이 할 수 있으니 정말 좋겠는걸?:0","나도 가입해야 겠다.:2"};
    string[] selectEnglish={"영어공부를 할 수 있으니 좋을거야.:0","나도 가입해야 겠다.:2"};
    string[] selectVoluteer={"봉사활동을 하면 굉장히 보람찰거야.:0","나도 가입해야 겠다.:2"};
    string[] selectSports={"내가 좋아하는 운동을 하면서 건강과 재미를 챙기니 재밌을거야.:0","나도 가입해야 겠다.:2"};
    string[] aboutHealth={"우리는 운동을 하면서 친목을 다지는 동아리야.:0","혹시 관심 있니?:2"};
    string[] aboutBand={"혹시 노래부르는거나 기타나 드럼, 베이스 치는거에 관심 있니?:0","같이 악기도 배우고 공연도 해보면서 재밌게 놀지 않을래? 재밌을거야.:2"};
    string[] aboutMajor={"우리는 어플을 만드는 동아리야. 우리가 만든 어플이 잘 작동되는 걸 보면 뿌듯함도 느낄 수 있어.:0","혹시 어플만드는 거에 관심이 있니?:2","같이 공부하면서 실려도 늘려보지 않을래?:2"};
    string[] aboutVolunteer={"봉사활동을 하면서 뿌듯함을 느껴보지 않을래?.:2"};
    string[] aboutEnglish={"우리는 영어를 좀 더 잘해보고 싶어서 모인 동아리야.:0"};
    
    public bool EndStory=false;
    public GroupManager groupmanager;
    public GameObject selectPanel;
    public GameObject Panel;
    public Sprite[] imgarr;
    // Start is called before the first frame update
    void Awake()
    {
        groupTalk=new Dictionary<int, string[]>();
        traitData=new Dictionary<int,Sprite>();
        
        DataSet();

        
    }
    void DataSet()
    {
       
        groupTalk.Add(2000,firstTalk);
        groupTalk.Add(3000,aboutHealth);
        groupTalk.Add(4000,aboutEnglish);
        groupTalk.Add(5000,aboutBand);
        groupTalk.Add(6000,aboutVolunteer);
        groupTalk.Add(7000,aboutMajor);
        groupTalk.Add(10+2000,firstTalk);
        groupTalk.Add(11+3000,ezzz);
        traitData.Add(1000+0,imgarr[0]);
        traitData.Add(1000+1,imgarr[1]);
        traitData.Add(1000+2,imgarr[2]);
        traitData.Add(1000+3,imgarr[3]);
        traitData.Add(2000+0,imgarr[0]);
        traitData.Add(2000+1,imgarr[1]);
        traitData.Add(2000+2,imgarr[2]);
        traitData.Add(2000+3,imgarr[3]);
        traitData.Add(3000+0,imgarr[4]);
        traitData.Add(3000+1,imgarr[5]);
        traitData.Add(3000+2,imgarr[6]);
        traitData.Add(3000+3,imgarr[7]);
        traitData.Add(4000+0,imgarr[0]);
        traitData.Add(4000+1,imgarr[1]);
        traitData.Add(4000+2,imgarr[2]);
        traitData.Add(4000+3,imgarr[3]);
        traitData.Add(5000+0,imgarr[4]);
        traitData.Add(5000+1,imgarr[5]);
        traitData.Add(5000+2,imgarr[6]);
        traitData.Add(5000+3,imgarr[7]);
        traitData.Add(6000+0,imgarr[0]);
        traitData.Add(6000+1,imgarr[1]);
        traitData.Add(6000+2,imgarr[2]);
        traitData.Add(6000+3,imgarr[3]);
        traitData.Add(7000+0,imgarr[4]);
        traitData.Add(7000+1,imgarr[5]);
        traitData.Add(7000+2,imgarr[6]);
        traitData.Add(7000+3,imgarr[7]);
    }
   
    public void SelectClub(int i)
    {
        switch(i)
        {
            case 1:
                EndStory=true;
                selectPanel.SetActive(false);
                groupTalk[2010]=selectBand;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case 2:
                EndStory=true;
                selectPanel.SetActive(false);
                groupTalk[2010]=selectVoluteer;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case 3:
                EndStory=true;
                selectPanel.SetActive(false);
                groupTalk[2010]=selectEnglish;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case 4:
                EndStory=true;
                selectPanel.SetActive(false);
                groupTalk[2010]=selectSports;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
            case 5:
                EndStory=true;
                selectPanel.SetActive(false);
                groupTalk[2010]=selectMajor;
                groupmanager.GroupTalking(2000,true);
                Panel.SetActive(true);
                break;
        }
    }
    public string GetTalk(int id,int talkIndex)
    {
        if(id==2010)
        {
            if(groupTalk[id]==endTalk)
            {
                if(talkIndex==groupTalk[id].Length)
                {
                    if(!EndStory)
                    {
                        selectPanel.SetActive(true);
                    }
                    return null;
                }
                    else
                        return groupTalk[id][talkIndex];
            }
            else
            {
                if(talkIndex==groupTalk[id].Length)
                    {
                        return null;
                    }
                else
                    return groupTalk[id][talkIndex];
            }
        }
        if(!groupTalk.ContainsKey(id))
        {
            
            if(!groupTalk.ContainsKey(id-id%10))
            {
                if(talkIndex==groupTalk[id-id%100].Length)
                    return null;
                
                else
                    return groupTalk[id-id%100][talkIndex];
            }
            else{
                if(talkIndex==groupTalk[id-id%10].Length)
                {
                   
                    if(groupTalk[id-id%10]==endTalk)
                    {
                       selectPanel.SetActive(true);
                    }
                    if(EndStory){
                        GameData.gamedata.Day++;
                        GameObject.Find("Canvas").GetComponent<FadeINOUT>().ComeBackFadeOut();
                    }
                    return null;
                }
                else
                    return groupTalk[id-id%10][talkIndex];
            }
        }
        if(talkIndex==groupTalk[id].Length)
        {
            
            groupTalk[2010]=endTalk;
            return null;
        }
        else
            return groupTalk[id][talkIndex];
        
    }
    public Sprite GetPort(int id,int imgIndex)
    {
        return traitData[id+imgIndex];
    }
}
