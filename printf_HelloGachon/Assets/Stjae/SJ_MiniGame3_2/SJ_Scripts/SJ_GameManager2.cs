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

        var output = GameObject.Find("Output").GetComponent<UnityEngine.UI.Text>();

        int size = dialManager.GetSize();

        if (count > size - 1)
        {
            // ExitGame();
        } else if (count <= size - 1)
        {
            dialText.text = dialManager.GetDial(count);
        }

        Debug.Log(count);

        switch(count)
        {
            case 2:
            funcType.text = "int";
            funcType.interactable = false;
            funcName.text = "main";
            funcName.interactable = false;
            returnStat.gameObject.SetActive(true);
            break;

            case 8:
            tilemapConsole.gameObject.SetActive(true);
            break;

            case 9:
            tilemapConsole.gameObject.SetActive(false);
            break;

            case 11:
            if (output.text != "")
            {
                break;
            } else
            {
                repeatBtn.gameObject.SetActive(true);
                dialText.text = "흠.. 코드를 다시 한 번 살펴볼까?";
                count -= 2;
            }
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

    public void BtnRunOnClick()
    {
        tilemapConsole.gameObject.SetActive(true);
        funcBody.interactable = false;
    }

    public void BtnStopOnClick()
    {
        tilemapConsole.gameObject.SetActive(false);
        funcBody.interactable = true;
    }
}
