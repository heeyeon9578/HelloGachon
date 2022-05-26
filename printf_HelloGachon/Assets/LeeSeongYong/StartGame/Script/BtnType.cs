using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BtnType : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nicknamepanel;
    public GameObject Optionpanel;
    public GameObject LoadPanel;
    public GameObject SFX;
    private AudioSource sfxSource;
    public AudioPlay bgm;
    public InputField playerInputnickname;
    private string playernickname;
    public bool end=false;
    public int exitCount=0;

    private void Awake() {
        sfxSource=SFX.GetComponent<AudioSource>();
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            nicknamepanel.SetActive(false);
            Optionpanel.SetActive(false);
            LoadPanel.SetActive(false);
            if(nicknamepanel.activeSelf==false&&Optionpanel.activeSelf==false&&LoadPanel.activeSelf==false)
            {
                exitCount++;
                if(exitCount==2)
                   Application.Quit();
            }
        }
    }

    void exitgame()
    {
        exitCount++;
    }

    void sfxButton()
    {
        sfxSource.loop=false;
        sfxSource.Play();
    }

    public void MakeNickName(){
        sfxButton();
        exitCount--;
        nicknamepanel.SetActive(true);
    }

    public void StopNickName(){
        exitCount=0;
        nicknamepanel.SetActive(false);
        playerInputnickname.text=null;
    }

    public void StartGame(){
        playernickname=playerInputnickname.text;
        
        if(playernickname.Length>0){
            GameData.gamedata.playerName=playernickname;
            GameData.gamedata.health=100;
            GameData.gamedata.popular=0;
            GameData.gamedata.alchol=0;
            GameData.gamedata.stress=0;
            GameData.gamedata.major=0;
            GameData.gamedata.month="3월";
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("MTStart"); 
           

        }
    }

    public void OptionGame(){
        exitCount--;
        Optionpanel.SetActive(true);
    }

    public void StopOption(){
        exitCount=0;
        Optionpanel.SetActive(false);
    }

    public void SetLoad()
    { 
        exitCount--;
        LoadPanel.SetActive(true);
    }

    public void StopLoad()
    {
        exitCount=0;
        LoadPanel.SetActive(false);
    }
}
