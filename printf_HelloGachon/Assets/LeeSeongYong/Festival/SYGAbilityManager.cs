using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SYGAbilityManager : MonoBehaviour
{
    public int Count=5;
    public string getGroup;
    public GameObject grsel;
    public Text nametext;
    public Text majortext;
    public Text stresstext;
    public Text healthtext;
    public Text populartext;
    public Text alcholtext;
    public Text Counttext;
    public float getHealth;
    public float getPopular;
    public float getStress;
    public float getMajor;
    public float getAlchol;
    // Start is called before the first frame update
    void Start()
    {
        nametext.text=GameData.gamedata.name;
        majortext.text="전공 : "+GameData.gamedata.major;
        stresstext.text="스트레스 : "+GameData.gamedata.stress;
        //healthtext.text="체력 : "+GameData.gamedata.health;
        populartext.text="인기도 : "+GameData.gamedata.popular;
        alcholtext.text="알코올 분해력 : "+GameData.gamedata.alchol;
        getHealth=GameData.gamedata.health;
        getAlchol=GameData.gamedata.alchol;
        getPopular=GameData.gamedata.popular;
        getMajor=GameData.gamedata.major;
        getStress=GameData.gamedata.stress;
        getGroup=GameData.gamedata.groupname;

        if(GameData.gamedata.groupname!="")
            grsel.SetActive(true);

        
    }
    private void Update() {
        Counttext.text="남은 활동 수 : "+Count;
        healthtext.text="체력 : "+getHealth;
        populartext.text="인기도 : "+getPopular;
        alcholtext.text="알코올 분해력 : "+getAlchol;
        majortext.text="전공 : "+getMajor;
        stresstext.text="스트레스 : "+getStress;
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
                }
                break;
            case "Health":
                if(Count>0)
                {
                    Count--;
                    getHealth+=5;
                    getStress-=5;
                }
                break;
            case "Study":
                if(Count>0&&getHealth>4)
                {
                    Count--;
                    getHealth-=5;
                    getStress+=2;
                    getMajor+=5;
                }
                break;
            case "GroupSelect":
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
