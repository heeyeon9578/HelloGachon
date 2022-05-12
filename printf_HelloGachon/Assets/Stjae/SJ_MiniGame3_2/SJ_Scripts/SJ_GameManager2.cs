using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJ_GameManager2 : MonoBehaviour
{
    public SJ_DialManager2 dialManager;
    public Button dialBtn;
    public Image repeatBtn;
    public Text dialText;
    public InputField funcType;
    public InputField funcName;
    public InputField paramType;
    public InputField paramName;
    public InputField funcBody;
    public GameObject returnStat;
    public GameObject tilemapConsole;
    public Color white;
    public Color orange;
    public Color yellow;
    int count = 0;

    public void BtnOnClick()
    {
        white = new Color (1.0f, 1.0f, 1.0f, 1.0f);
        orange = new Color (1.0f, 0.64f, 0.0f, 1.0f);
        yellow = new Color (0.95f, 0.95f, 0.1f, 1.0f);

        int size = dialManager.GetSize();

        if (count > size - 1)
        {
            ExitGame();
        } else if (count <= size - 1)
        {
            dialText.text = dialManager.GetDial(count);
        }

        Debug.Log(count);

        switch(count)
        {
            case 2:
            funcType.text = "int";
            funcName.text = "main";
            returnStat.gameObject.SetActive(true);
            break;

            case 8:
            tilemapConsole.gameObject.SetActive(true);
            break;
        }
        count++;
    }

    void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void RepeatBtnOnClick()
    {
        repeatBtn.gameObject.SetActive(false);
        count = 2;
        BtnOnClick();
    }
}
