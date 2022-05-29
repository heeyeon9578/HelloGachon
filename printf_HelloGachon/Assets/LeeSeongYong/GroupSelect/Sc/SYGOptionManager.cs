using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYGOptionManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Option;
    public GameObject savepanel;
    public GameObject Map;
    public GameObject camera2;
    public GameObject canvas1;
    public GameObject canvas2;
    
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
    public void ExitPanel()
    {
        savepanel.SetActive(false);
    }

    //맵 버튼 눌러서 맵화면 여는 함수
    public void OpenMap(){
        canvas2.SetActive(true);
        camera2.SetActive(true);
        canvas1.SetActive(false);
    }
    //맵 화면 닫는 함수
    public void CloseMap(){
        canvas2.SetActive(false);
        camera2.SetActive(false);
        canvas1.SetActive(true);
    }

}
