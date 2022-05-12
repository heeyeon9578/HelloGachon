using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameData gamedata;
    public string name;
    public float major;
    public float alchol;
    public float health;
    public float stress;
    public float popular;
    public string groupname="";

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
