using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameData gamedata;
    public string playerName;
    public float major;
    public float alchol;
    public float health;
    public float stress;
    public float popular;
    public string groupname="";
    public Vector3 playerpos;
    public Vector3 mudangpos;
    public Vector3 friendpos;
    public bool talkend;
    public string loadscenename;
    public float bgmSound=0;
    public float bgmSlider=-80;
    public string month;
    public int scoreExam1;
    public int scoreExam2;
    void Awake()
    {
      if(gamedata!=null)
      {
          Destroy(gameObject);
          return;
      }
      gamedata=this;
      DontDestroyOnLoad(gameObject);
    }


}
