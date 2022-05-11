using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GRQuestData 
{
   public string questName;
   public int[] npcId;

   public GRQuestData(string name, int[] npc)
   {
       questName = name;
       npcId = npc;
   } 
}
