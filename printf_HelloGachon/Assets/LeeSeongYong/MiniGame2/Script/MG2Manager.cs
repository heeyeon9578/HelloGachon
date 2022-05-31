using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MG2Manager : MonoBehaviour
{
    private static MG2Manager _instance;
    public static MG2Manager Instance{
        get{
            if(_instance==null)
            {
                _instance=FindObjectOfType<MG2Manager>();
            }
            return _instance;
        }
    }
    public IEnumerator coroutine;
    [SerializeField]
    private GameObject soju;
    [SerializeField]
    private GameObject beer;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private GameObject panelbutton;
    [SerializeField]
    private GameObject panelbutton2;
    [SerializeField]
    private GameObject[] listsoju;
    private int num;
    private int playerlife;
    private float GameTime;
    public Text Endtext;
    public bool isWin=false;
    
    // Start is called before the first frame update
    void Start()
    {
        coroutine=CreateSojuRoutine();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameStart()
    {
        
        StartCoroutine(coroutine);
        panel.SetActive(false);

    }
    public void GameOver()
    {
        playerlife=GameObject.Find("SYMG2Player").GetComponent<MG2PlayerAction>().life;
        GameTime=GameObject.Find("SYMG2Timer").GetComponent<SYMG2Timer>().EndTime;
        
       if(playerlife==0){
        
        StopCoroutine(coroutine);
        panel.SetActive(true);
        panelbutton.SetActive(false);
        panelbutton2.SetActive(true);
        Endtext.text="게임 오버\n(알코올 분해력 +10,\n인기도 -5, 체력 -5)";
       }
       if(isWin){
            StopCoroutine(coroutine);
            panel.SetActive(true);
            panelbutton.SetActive(false);
            panelbutton2.SetActive(true);
            Endtext.text="게임 승리\n(인기도 +10,\n알코올 분해력 +15)";
       }

    }
    IEnumerator CreateSojuRoutine()
    {
        while(true)
        {
            num=Random.Range(0,2);
            CreateSoju(num);
            yield return new WaitForSeconds(0.3f);

        }
        
    }
    
    
    private void CreateSoju(int num)
    {
        
        Vector3 pos=Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f,1.0f),1.1f,0));
        pos.z=0.0f;
        Instantiate(listsoju[num],pos,Quaternion.identity);
    }
    public void NextStory(){
        if(playerlife==0)
        {
            GameData.gamedata.alchol+=10;
            GameData.gamedata.health-=5;
            GameData.gamedata.popular-=5;
        }
        if(isWin)
        {
            GameData.gamedata.alchol+=15;
            GameData.gamedata.popular+=10;
        }

        //능력치 보정
        //전공
        if(GameData.gamedata.major>100){GameData.gamedata.major=100;}
        else if(GameData.gamedata.major<0){GameData.gamedata.major=0;}
        //체력
        if(GameData.gamedata.health>100){GameData.gamedata.health=100;}
        else if(GameData.gamedata.health<0){GameData.gamedata.health=0;}
        //알코올 분해력
        if(GameData.gamedata.alchol>100){GameData.gamedata.alchol=100;}
        else if(GameData.gamedata.alchol<0){GameData.gamedata.alchol=0;}
        //인기도
        if(GameData.gamedata.popular>100){GameData.gamedata.popular=100;}
        else if(GameData.gamedata.popular<0){GameData.gamedata.popular=0;}
        //스트레스
        if(GameData.gamedata.stress<0){GameData.gamedata.stress=0;}
        else if(GameData.gamedata.stress>100){GameData.gamedata.stress=100;}
        
        GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("Set_Activity_4April");
    }
   
}
