using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupQuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int,GroupQuestData> questList;
    // Start is called before the first frame update
    private void Awake() {
        questList=new Dictionary<int,GroupQuestData>();
        GenerateData();
        
    }
    

    // Update is called once per frame
    void GenerateData()
    {
        questList.Add(10,new GroupQuestData("시작",new int[]{2000,3000,4000,5000,6000,7000}));
    }
    public int GetQuestTalkIndex(int id)
    {
        return questId+questActionIndex;
    }
    public void CheckQuest(int id)
    {
        if(id==questList[questId].npcId[questActionIndex])
            questActionIndex=1;
    }
}
