using System.Collections;
using System.Collections.Generic;

public class QuestData_ots
{
    public string questName;
    public int[] storyObjId;

    public QuestData_ots(string name, int[] storyObj)
    {
        questName = name;
        storyObjId = storyObj;
    }
}
