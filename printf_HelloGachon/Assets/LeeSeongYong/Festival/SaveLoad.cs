using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
[System.Serializable]
public class Data
{
    public string svname=GameData.gamedata.playerName;
    public string svmonth=GameData.gamedata.month;
    public float svmajor=GameData.gamedata.major;
    public float svalchol=GameData.gamedata.alchol;
    public float svhealth=GameData.gamedata.health;
    public float svstress=GameData.gamedata.stress;
    public float svpopular=GameData.gamedata.popular;
    public string svgroupname=GameData.gamedata.groupname;
    public int svExam1;
    public int svExam2;
    public string savescene;
    public Vector3 PlayerPos;
    public Vector3 MudangPos;
    public Vector3 FriendPos;
    public bool Endtalk;
    public float svbgmSound;
    public float svbgmSlider;
    public float svsfxSound;
    public float svsfxSlider;
}
[System.Serializable]
public class SaveLoad : MonoBehaviour
{
    string filePath;
    private void Start() {
        filePath=Application.persistentDataPath+"/LocalDB.json";
        Debug.Log(filePath);
    }
    private void Update() {
        
    }
    public void Save()
    {
        Data loaddata=new Data();
        Scene scenename=SceneManager.GetActiveScene();
        loaddata.PlayerPos=GameData.gamedata.playerpos;
        loaddata.MudangPos=GameData.gamedata.mudangpos;
        loaddata.FriendPos=GameData.gamedata.friendpos;
        loaddata.savescene=scenename.name;
        loaddata.Endtalk=GameData.gamedata.talkend;
        loaddata.svbgmSlider=GameData.gamedata.bgmSlider;
        loaddata.svbgmSound=GameData.gamedata.bgmSound;
        loaddata.svsfxSlider=GameData.gamedata.sfxSlider;
        loaddata.svsfxSound=GameData.gamedata.SFXsound;
        loaddata.svExam1=GameData.gamedata.scoreExam1;
        loaddata.svExam2=GameData.gamedata.scoreExam2;
        string json=JsonUtility.ToJson(loaddata);
        byte[] bytes=System.Text.Encoding.UTF8.GetBytes(json);
        string code=System.Convert.ToBase64String(bytes);
        File.WriteAllText(filePath,code);

    }
    public void Load()
    {
        if(!File.Exists(filePath))
        {
            GameObject.Find("MenuManager").GetComponent<BtnType>().SetLoad();
        }
        else{
                string str2=File.ReadAllText(filePath);
                byte[] bytes=System.Convert.FromBase64String(str2);
                string jdata=System.Text.Encoding.UTF8.GetString(bytes);
                Data data4=JsonUtility.FromJson<Data>(jdata);
                GameData.gamedata.playerName=data4.svname;
                GameData.gamedata.month=data4.svmonth;
                GameData.gamedata.major=data4.svmajor;
                GameData.gamedata.alchol=data4.svalchol;
                GameData.gamedata.health=data4.svhealth;
                GameData.gamedata.stress=data4.svstress;
                GameData.gamedata.popular=data4.svpopular;
                GameData.gamedata.groupname=data4.svgroupname;
                GameData.gamedata.playerpos=data4.PlayerPos;
                GameData.gamedata.mudangpos=data4.MudangPos;
                GameData.gamedata.friendpos=data4.FriendPos;
                GameData.gamedata.talkend=data4.Endtalk;
                GameData.gamedata.loadscenename=data4.savescene;
                GameData.gamedata.bgmSlider=data4.svbgmSlider;
                GameData.gamedata.bgmSound=data4.svbgmSound;
                GameData.gamedata.sfxSlider=data4.svsfxSlider;
                GameData.gamedata.SFXsound=data4.svsfxSound;
                GameData.gamedata.scoreExam1=data4.svExam1;
                GameData.gamedata.scoreExam2=data4.svExam2;
                GameObject.Find("Canvas").GetComponent<FadeINOUT>().LoadFadeOut(data4.savescene);
            }
           
        
       
    }
    

}
