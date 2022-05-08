using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heeQuestData 
{
   public string questName;
   public int[] npcId;

   public heeQuestData(string name, int[] npc)
   {
       questName = name;
       npcId = npc;
   } 
}
