using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYGOptionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Option;

    public void OpenOption()
    {
        Option.SetActive(true);
    }
    public void CloseOption()
    {
        Option.SetActive(false);
    }
    public void EndGame()
    {
        Application.Quit();
    }
}
