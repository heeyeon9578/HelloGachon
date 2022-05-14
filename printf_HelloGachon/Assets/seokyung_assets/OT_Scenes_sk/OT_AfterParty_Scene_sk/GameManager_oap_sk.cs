using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager_oap_sk : MonoBehaviour
{
    public string[] talkNameList;
    public string[] talkTextList;
    public Sprite[] portraitArr;
    public GameObject dialogPanel;
    public Text dialogName;
    public Text dialogText;
    public Image portraitImg;
    public AudioSource glassCling;
    private int index = 0;

    void Start()
    {
        toastTalk();
    }

    public void toastTalk()
    {
        //End Talk
        if(index == talkTextList.Length){
            dialogPanel.SetActive(false);
            SceneManager.LoadScene("BeforeMiniGame1");
            return;
        }        
        
        dialogName.text = talkNameList[index];
        dialogText.text = talkTextList[index];
        portraitImg.sprite = portraitArr[index];

        dialogPanel.SetActive(true);
        index++;

        if (index == 3) {
            glassCling.Play();
        }
    }
}
