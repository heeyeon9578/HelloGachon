using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapBuildingNameOpen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] buildingName;
    
    public void openName()
    {
        for(int i=0;i<buildingName.Length;i++)
            buildingName[i].SetActive(true);
    }
    public void closeName()
    {
        for(int i=0;i<buildingName.Length;i++)
            buildingName[i].SetActive(false);
    }
}
