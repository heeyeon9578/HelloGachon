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
    public InputField playerInputnickname;
    private string playernickname;
    public bool end=false;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            StopNickName();
            StopOption();
        }
    }
    public void MakeNickName(){
        nicknamepanel.SetActive(true);
    }
    public void StopNickName(){
        nicknamepanel.SetActive(false);
        playerInputnickname.text=null;
    }
    public void StartGame(){
        
        playernickname=playerInputnickname.text;
        
        if(playernickname.Length>0){
            GameData.gamedata.name=playernickname;
            GameData.gamedata.health=50;
            GameData.gamedata.popular=0;
            GameData.gamedata.alchol=0;
            GameData.gamedata.stress=0;
            GameData.gamedata.major=0;
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().startFadeOut();
            
                //SceneManager.LoadScene("MiniGame2");
            
            
        }
    }
    public void ContinueGame(){
        Debug.Log("이어하기");
    }
    public void OptionGame(){
        Optionpanel.SetActive(true);
    }
    public void StopOption(){
        Optionpanel.SetActive(false);
    }
}
