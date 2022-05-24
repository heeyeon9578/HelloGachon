using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SYMG2Timer : MonoBehaviour
{
    public Text timerTxt;
    public float LimitTime;
    public bool isStart=false;
    public int stopTime;
    public float EndTime;
    public GameObject player;
    // Start is called before the first frame update
    void Start(){
    }
    // Update is called once per frame
    void Update()
    {
        if(isStart){
            if(LimitTime>0)
            {
                LimitTime-=Time.deltaTime;
                timerTxt.text="시간 : "+Mathf.Round(LimitTime);
                EndTime=Mathf.Round(LimitTime);
                if(EndTime==0){
                    GameObject.Find("MG2Manager").GetComponent<MG2Manager>().isWin=true;    
                    GameObject.Find("MG2Manager").GetComponent<MG2Manager>().GameOver();
                }
            } 
        }
        stopTime=GameObject.Find("SYMG2Player").GetComponent<MG2PlayerAction>().life;
        if(stopTime==0){
            isStart=false;
        }
    }
    public void TimerStart(){
       isStart=true;
    }
}
