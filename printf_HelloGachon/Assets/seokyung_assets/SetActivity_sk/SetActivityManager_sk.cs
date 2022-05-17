using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SetActivityManager_sk : MonoBehaviour
{
    public int Count=10;
    public string getGroup;
    public GameObject clubBtn;
    public Text majortext;
    public Text stresstext;
    public Text healthtext;
    public Text populartext;
    public Text alcholtext;
    public Text infoTxt;
    public GameObject w1Panel;
    public Text w1Txt;
    public GameObject w2Panel;
    public Text w2Txt;
    public GameObject w3Panel;
    public Text w3Txt;
    public GameObject w4Panel;
    public Text w4Txt;
    public GameObject w5Panel;
    public Text w5Txt;
    public float getHealth;
    public float getPopular;
    public float getStress;
    public float getMajor;
    public float getAlchol;
    
    void Start()
    {
        majortext.text="전공 : "+GameData.gamedata.major;
        stresstext.text="스트레스 : "+GameData.gamedata.stress;
        healthtext.text="체력 : "+GameData.gamedata.health;
        populartext.text="인기도 : "+GameData.gamedata.popular;
        alcholtext.text="알코올 분해력 : "+GameData.gamedata.alchol;
        infoTxt.text = " ";

        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;
        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        getGroup=GameData.gamedata.groupname;

        if(GameData.gamedata.groupname!="")
            clubBtn.SetActive(true);
    }

    private void Update() {
        majortext.text="전공 : "+getMajor;
        stresstext.text="스트레스 : "+getStress;
        healthtext.text="체력 : "+getHealth;
        populartext.text="인기도 : "+getPopular;
        alcholtext.text="알코올 분해력 : "+getAlchol;
    }

    public void abilityChange(string type)
    {
        switch(type)
        {
            case "Drink":
                if(Count>0&&getHealth>4)
                {
                    Count--;
                    getHealth-=5;
                    getAlchol+=5;
                    getPopular+=3;

                    w1Panel.GetComponent<Image>().color = new Color(138, 255, 143, 255);
                    w1Txt.text = "술약속";
                    infoTxt.text = "적셔!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
                }
                break;
            case "Health":
                if(Count>0)
                {
                    Count--;
                    getHealth+=5;
                    getStress-=5;

                    w2Panel.GetComponent<Image>().color = new Color32(255, 99, 88, 225);
                    w2Txt.text = "운동";
                    infoTxt.text = "앉아만 있지 말고 운동 좀 해";
                }
                break;
            case "Study":
                if(Count>0&&getHealth>4)
                {
                    Count--;
                    getHealth-=5;
                    getStress+=2;
                    getMajor+=5;

                    w3Panel.GetComponent<Image>().color = new Color32(104, 142, 225, 225);
                    w3Txt.text = "스터디";
                    infoTxt.text = "알고리즘 스터디";
                }
                break;
            case "Interest":
                if(Count>0&&getHealth>4)
                {
                    Count--;
                    getHealth-=5;
                    getStress-=3;
                    getPopular+=2;

                    w4Panel.GetComponent<Image>().color = new Color32(255, 227, 88, 225);
                    w4Txt.text = "취미\n활동";
                    infoTxt.text = "누워서 기타치기";
                }
                break;
            case "Club":
                if(Count>0&&getHealth>4)
                {
                    if(getGroup=="Music")
                    {
                        Count--;
                        getHealth-=5;
                        getPopular+=5;
                        getStress-=5;

                    }else if(getGroup=="Religion")
                    {
                        Count--;
                        getHealth-=5;
                        getStress-=5;
                    }else if(getGroup=="Major")
                    {
                        Count--;
                        getHealth-=5;
                        getMajor+=5;
                        getStress+=3;
                    }else if(getGroup=="Health")
                    {
                        Count--;
                        getHealth+=10;
                        getStress-=5;
                    }else if(getGroup=="Perpormance")
                    {
                        Count--;
                        getHealth-=5;
                        getStress-=5;
                        getPopular+=5;
                    }else if(getGroup=="Hobby")
                    {
                        Count--;
                        getHealth-=5;
                        getStress-=5;
                    }

                    w5Panel.GetComponent<Image>().color = new Color32(255, 167, 236, 225);
                    w5Txt.text = "동아리";
                    infoTxt.text = "동방가고싶다";
                }
                break;

            
        }          //Counttext.text="남은 활동 수 : "+Count;}
    }

    public void resetChange()
    {
        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;
        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        Count=5;
    }

    public void Complete()
    {
        GameData.gamedata.health=getHealth;
        GameData.gamedata.alchol=getAlchol;
        GameData.gamedata.major=getMajor;
        GameData.gamedata.popular=getPopular;
        GameData.gamedata.stress=getStress;
        SceneManager.LoadScene("Group");
    }
}
