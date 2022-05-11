using System.Collections;
using System.Collections.Generic;

public class QuestData_otl_sk
{
    public string questName;
    public int[] storyObjId;

    public QuestData_otl_sk(string name, int[] storyObj)
    {
        questName = name;
        storyObjId = storyObj;
    }
}
