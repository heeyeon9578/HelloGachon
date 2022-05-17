using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Data
{
    public string svname=GameData.gamedata.name;
    public float svmajor=GameData.gamedata.major;
    public float svalchol=GameData.gamedata.alchol;
    public float svhealth=GameData.gamedata.health;
    public float svstress=GameData.gamedata.stress;
    public float svpopular=GameData.gamedata.popular;
    public string svgroupname=GameData.gamedata.groupname;
    public string savescene;
    public float PlayerX;
    public float PlayerY;
    public float MudangX;
    public float MudangY;
    public Vector3 PlayerPos;
    public Vector3 MudangPos;
    public Vector3 FriendPos;
    public bool Endtalk;
    public float svbgmSound;
    public float svbgmSlider;
    public void printData()
    {
        Debug.Log(svname);
        Debug.Log(svmajor);
    }
}
[System.Serializable]
public class SaveLoad : MonoBehaviour
{
    public GameObject player;
    string filePath;

    private void Start() {
        filePath=Application.persistentDataPath+"/LocalDB.json";
        Debug.Log(filePath);
    }
    public void Save()
    {
        Data loaddata=new Data();
        Scene scenename=SceneManager.GetActiveScene();
        loaddata.PlayerX=GameData.gamedata.h;
        loaddata.PlayerY=GameData.gamedata.v;
        loaddata.MudangX=GameData.gamedata.mudangh;
        loaddata.MudangY=GameData.gamedata.mudangv;
        loaddata.PlayerPos=GameData.gamedata.playerpos;
        loaddata.MudangPos=GameData.gamedata.mudangpos;
        loaddata.FriendPos=GameData.gamedata.friendpos;
        loaddata.savescene=scenename.name;
        loaddata.Endtalk=GameData.gamedata.talkend;
        loaddata.svbgmSlider=GameData.gamedata.bgmSlider;
        loaddata.svbgmSound=GameData.gamedata.bgmSound;
        string json=JsonUtility.ToJson(loaddata);
        byte[] bytes=System.Text.Encoding.UTF8.GetBytes(json);
        string code=System.Convert.ToBase64String(bytes);
        File.WriteAllText(filePath,code);

        SceneManager.LoadScene("StartScene");
        // string str2=File.ReadAllText(Application.dataPath+"/Testjosn.json");

        // Data data4=JsonUtility.FromJson<Data>(str2);
        // data4.printData();
       
    }
    public void Load()
    {
        if(!File.Exists(filePath))
        {
            Debug.Log("데이터 없음");
            GameObject.Find("MenuManager").GetComponent<BtnType>().SetLoad();
        }
        else{
            string str2=File.ReadAllText(filePath);
            byte[] bytes=System.Convert.FromBase64String(str2);
            string jdata=System.Text.Encoding.UTF8.GetString(bytes);
            Data data4=JsonUtility.FromJson<Data>(jdata);
            Debug.Log("From json: "+data4.svname);
            GameData.gamedata.name=data4.svname;
            GameData.gamedata.major=data4.svmajor;
            GameData.gamedata.alchol=data4.svalchol;
            GameData.gamedata.health=data4.svhealth;
            GameData.gamedata.stress=data4.svstress;
            GameData.gamedata.popular=data4.svpopular;
            GameData.gamedata.groupname=data4.svgroupname;
            GameData.gamedata.playerpos=data4.PlayerPos;
            GameData.gamedata.mudangpos=data4.MudangPos;
            GameData.gamedata.friendpos=data4.FriendPos;
            GameData.gamedata.h=data4.PlayerX;
            GameData.gamedata.v=data4.PlayerY;
            GameData.gamedata.mudangh=data4.MudangX;
            GameData.gamedata.mudangv=data4.MudangY;
            GameData.gamedata.talkend=data4.Endtalk;
            GameData.gamedata.loadscenename=data4.savescene;
            GameData.gamedata.bgmSlider=data4.svbgmSlider;
            GameData.gamedata.bgmSound=data4.svbgmSound;
            GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut(data4.savescene);
        }
    }

}
