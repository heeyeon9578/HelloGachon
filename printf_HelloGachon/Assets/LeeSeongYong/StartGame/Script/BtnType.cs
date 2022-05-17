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
    private void Awake() {
        sfxSource=SFX.GetComponent<AudioSource>();
    }
    void Start()
    {
        bgm.sliderA.value=1;
        bgm.sound=Mathf.Log10(bgm.sliderA.value)*20;
        bgm.SetStart();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            StopNickName();
            StopOption();
            StopLoad();
        }
    }
    void sfxButton()
    {
        sfxSource.loop=false;
        sfxSource.Play();
    }
    public void MakeNickName(){
        sfxButton();
        nicknamepanel.SetActive(true);
    }
    public void StopNickName(){
        //sfxButton();
        nicknamepanel.SetActive(false);
        playerInputnickname.text=null;
    }
    public void StartGame(){
        sfxButton();
        playernickname=playerInputnickname.text;
        
        if(playernickname.Length>0){
            GameData.gamedata.name=playernickname;
            GameData.gamedata.health=50;
            GameData.gamedata.popular=0;
            GameData.gamedata.alchol=0;
            GameData.gamedata.stress=0;
            GameData.gamedata.major=0;
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut("SYGAbility");
           
            
                //SceneManager.LoadScene("MiniGame2");
            
            
        }
    }
    public void ContinueGame(){
        Debug.Log("이어하기");
    }
    public void OptionGame(){
        sfxButton();
        Optionpanel.SetActive(true);
    }
    public void StopOption(){
        //sfxButton();
        Optionpanel.SetActive(false);
    }
    public void SetLoad()
    { 
        sfxButton(); 
        LoadPanel.SetActive(true);
    }
    public void StopLoad()
    {
        //sfxButton();
        LoadPanel.SetActive(false);
    }
}
