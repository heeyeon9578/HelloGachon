using System.Collections;
using System.Collections.Generic;


public class GroupQuestData
{
    public string questName;
    public int[] npcId;
    
    public GroupQuestData(string name, int[] npc)
    {   
        questName=name;
        npcId=npc;
    }

}
