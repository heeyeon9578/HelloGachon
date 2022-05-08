using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameData gamedata;
    public int Day=0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(gamedata==null)
        {
            gamedata=this;
        }
    }


}
