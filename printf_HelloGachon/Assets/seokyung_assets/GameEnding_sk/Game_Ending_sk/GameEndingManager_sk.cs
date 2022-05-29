using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameEndingManager_sk : MonoBehaviour
{
    public GameObject skipBtn;
    public Text playerName;
    public Text totalscore;
    public Text majorscore;
    public Text healthscore;
    public Text stressscore;
    public Text popularscore;
    public Text alcholscore;
    public Text examscore;
    public Text majorgrade;
    public Text healthgrade;
    public Text stressgrade;
    public Text populargrade;
    public Text alcholgrade;
    public Text examgrade;
    public Text majortotal;
    public Text healthtotal;
    public Text stresstotal;
    public Text populartotal;
    public Text alcholtotal;
    public Text examtotal;
    private float total;
    private float endmajor;
    private float endhealth;
    private float endstress;
    private float endpopular;
    private float endalchol;
    private string endname;
    private int testScore;
    
    void Start()
    {
        if(GameData.gamedata.major >100){GameData.gamedata.major=100;}
        if(GameData.gamedata.health >100){GameData.gamedata.health=100;}
        if(GameData.gamedata.alchol >100){GameData.gamedata.alchol=100;}
        if(GameData.gamedata.popular >100){GameData.gamedata.popular=100;}
        if(GameData.gamedata.stress<0){GameData.gamedata.stress=0;}



        endname=GameData.gamedata.name;
        endmajor=GameData.gamedata.major;
        endhealth=GameData.gamedata.health;
        endstress=100-GameData.gamedata.stress;
        endpopular=GameData.gamedata.popular;
        endalchol=GameData.gamedata.alchol;

        

        playerName.text=""+GameData.gamedata.name;
        majorscore.text=""+GameData.gamedata.major;
        healthscore.text=""+GameData.gamedata.health;
        stressscore.text=""+endstress.ToString();
        popularscore.text=""+GameData.gamedata.popular;
        alcholscore.text=""+GameData.gamedata.alchol;

        testScore=(GameData.gamedata.scoreExam1+GameData.gamedata.scoreExam2)/2;
        examscore.text = testScore.ToString();
    }

    void Update()
    {
        EndingScore();
        SetPlayerName();
        SetTotal();
        SetMajor();
        SetPopular();
        SetAlchol();
        SetStress();
        SetHealth();
        SetTestScore();
    }
    void EndingScore()
    {
        total=endmajor*0.3f+endhealth*0.25f+endpopular*0.1f+endalchol*0.1f+endstress*0.25f;
        //Debug.Log(endmajor*0.3f+endhealth*0.25f+endpopular*0.1f+endalchol*0.1f);
    }
    void SetPlayerName()
    {
        playerName.text="* "+GameData.gamedata.playerName+"의 학기 종합 성적";
    }
    void SetTotal()
    {
        if(total>=90){
            totalscore.text="전체 학점 : A+";
            
        }else if(total>=80&&total<90)
        {
            totalscore.text="전체 학점 : A";
           
        }else if(total>=75&&total<80)
        {
            totalscore.text="전체 학점 : B+";
           
        }else if(total>=70&&total<75)
        {
            totalscore.text="전체 학점 : B";
           
        }else if(total>=65&&total<70)
        { 
            totalscore.text="전체 학점 : C+";
            
        }else if(total>=60&&total<65)
        {
            totalscore.text="전체 학점 : C";
            
        }else if(total>=55&&total<60)
        {
            totalscore.text="전체 학점 : D+";
            
        }else if(total>=50&&total<55)
        {
            totalscore.text="전체 학점 : D";
            
        }else
        {
            totalscore.text="전체 학점 : F";
            
        }
    }
    void SetMajor()
    {
         if(endmajor>=90){
            majorgrade.text="A+";
            majortotal.text="4.5";
        }else if(endmajor>=80&&endmajor<90)
        {
            majorgrade.text="A";
            majortotal.text="4.0";
        }else if(endmajor>=75&&endmajor<80)
        {
            majorgrade.text="B+";
            majortotal.text="3.5";
        }else if(endmajor>=70&&endmajor<75)
        {
            majorgrade.text="B";
            majortotal.text="3.0";
        }else if(endmajor>=65&&endmajor<70)
        { 
            majorgrade.text="C+";
            majortotal.text="2.5";
        }else if(endmajor>=60&&endmajor<65)
        {
            majorgrade.text="C";
            majortotal.text="2.0";
        }else if(endmajor>=55&&endmajor<60)
        {
            majorgrade.text="D+";
            majortotal.text="1.5";
        }else if(endmajor>=50&&endmajor<55)
        {
            majorgrade.text="D";
            majortotal.text="1.0";
        }else
        {
            majorgrade.text="F";
            majortotal.text="0.0";
        }
    }
    void SetHealth()
    {
        if(endhealth>=90){
            healthgrade.text="A+";
            healthtotal.text="4.5";
        }else if(endhealth>=80&&endhealth<90)
        {
            healthgrade.text="A";
            healthtotal.text="4.0";
        }else if(endhealth>=75&&endhealth<80)
        {
            healthgrade.text="B+";
            healthtotal.text="3.5";
        }else if(endhealth>=70&&endhealth<75)
        {
            healthgrade.text="B";
            healthtotal.text="3.0";
        }else if(endhealth>=65&&endhealth<70)
        { 
            healthgrade.text="C+";
            healthtotal.text="2.5";
        }else if(endhealth>=60&&endhealth<65)
        {
            healthgrade.text="C";
            healthtotal.text="2.0";
        }else if(endhealth>=55&&endhealth<60)
        {
            healthgrade.text="D+";
            healthtotal.text="1.5";
        }else if(endhealth>=50&&endhealth<55)
        {
            healthgrade.text="D";
            healthtotal.text="1.0";
        }else
        {
            healthgrade.text="F";
            healthtotal.text="0.0";
        }
    }
    void SetPopular()
    {
        if(endpopular>=90){
            populargrade.text="A+";
            populartotal.text="4.5";
        }else if(endpopular>=80&&endpopular<90)
        {
            populargrade.text="A";
            populartotal.text="4.0";
        }else if(endpopular>=75&&endpopular<80)
        {
            populargrade.text="B+";
            populartotal.text="3.5";
        }else if(endpopular>=70&&endpopular<75)
        {
            populargrade.text="B";
            populartotal.text="3.0";
        }else if(endpopular>=65&&endpopular<70)
        { 
            populargrade.text="C+";
            populartotal.text="2.5";
        }else if(endpopular>=60&&endpopular<65)
        {
            populargrade.text="C";
            populartotal.text="2.0";
        }else if(endpopular>=55&&endpopular<60)
        {
            populargrade.text="D+";
            populartotal.text="1.5";
        }else if(endpopular>=50&&endpopular<55)
        {
            populargrade.text="D";
            populartotal.text="1.0";
        }else
        {
            populargrade.text="F";
            populartotal.text="0.0";
        }
    }
    void SetAlchol()
    {
        if(endalchol>=90){
            alcholgrade.text="A+";
            alcholtotal.text="4.5";
        }else if(endalchol>=80&&endalchol<90)
        {
            alcholgrade.text="A";
            alcholtotal.text="4.0";
        }else if(endalchol>=75&&endalchol<80)
        {
            alcholgrade.text="B+";
            alcholtotal.text="3.5";
        }else if(endalchol>=70&&endalchol<75)
        {
            alcholgrade.text="B";
            alcholtotal.text="3.0";
        }else if(endalchol>=65&&endalchol<70)
        { 
            alcholgrade.text="C+";
            alcholtotal.text="2.5";
        }else if(endalchol>=60&&endalchol<65)
        {
            alcholgrade.text="C";
            alcholtotal.text="2.0";
        }else if(endalchol>=55&&endalchol<60)
        {
            alcholgrade.text="D+";
            alcholtotal.text="1.5";
        }else if(endalchol>=50&&endalchol<55)
        {
            alcholgrade.text="D";
            alcholtotal.text="1.0";
        }else
        {
            alcholgrade.text="F";
            alcholtotal.text="0.0";
        }
    }
    void SetStress()
    {
        if(endstress>=90){
            stressgrade.text="A+";
            stresstotal.text="4.5";
        }else if(endstress>=80&&endstress<90)
        {
            stressgrade.text="A";
            stresstotal.text="4.0";
        }else if(endstress>=75&&endstress<80)
        {
            stressgrade.text="B+";
            stresstotal.text="3.5";
        }else if(endstress>=70&&endstress<75)
        {
            stressgrade.text="B";
            stresstotal.text="3.0";
        }else if(endstress>=65&&endstress<70)
        { 
            stressgrade.text="C+";
            stresstotal.text="2.5";
        }else if(endstress>=60&&endstress<65)
        {
            stressgrade.text="C";
            stresstotal.text="2.0";
        }else if(endstress>=55&&endstress<60)
        {
            stressgrade.text="D+";
            stresstotal.text="1.5";
        }else if(endstress>=50&&endstress<55)
        {
            stressgrade.text="D";
            stresstotal.text="1.0";
        }else
        {
            stressgrade.text="F";
            stresstotal.text="0.0";
        }
    }
    void SetTestScore()
    {
        if(testScore>=90){
            examgrade.text="A+";
            examtotal.text="4.5";
            
        }else if(testScore>=80&&testScore<90)
        {
            examgrade.text="A";
            examtotal.text="4.0";
           
        }else if(testScore>=75&&testScore<80)
        {
            examgrade.text="B+";
            examtotal.text="3.5";
           
        }else if(testScore>=70&&testScore<75)
        {
            examgrade.text="B";
            examtotal.text="3.0";
           
        }else if(testScore>=65&&testScore<70)
        { 
            examgrade.text="C+";
            examtotal.text="2.5";
            
        }else if(testScore>=60&&testScore<65)
        {
            examgrade.text="C";
            examtotal.text="2.0";
            
        }else if(testScore>=55&&testScore<60)
        {
            examgrade.text="D+";
            examtotal.text="1.5";
            
        }else if(testScore>=50&&testScore<55)
        {
            examgrade.text="D";
            examtotal.text="1.0";
            
        }else
        {
            examgrade.text="F";
            examtotal.text="0.0";
        }
    }

    public void showSkipBtn() {
        skipBtn.SetActive(true);
    }

    public void gotoEndingCredit()
    {
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Ending_Credit_scene_sk");
    }
}
