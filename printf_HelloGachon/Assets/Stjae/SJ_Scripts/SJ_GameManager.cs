using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJ_GameManager : MonoBehaviour
{
    public SJ_DialManager dialManager;
    public Button dialBtn;
    public Image repeatBtn;
    public Text dialText;
    public InputField funcType;
    public InputField funcName;
    public InputField paramType;
    public InputField paramName;
    public InputField funcBody;
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
            funcName.GetComponent<Image>().color = orange;
            funcType.text = "int";
            funcName.text = "addValue";
            paramType.text = "int";
            paramName.text = "value";
            funcBody.text = "return value + 1;";
            break;

            case 3:
            break;

            case 4:
            funcName.GetComponent<Image>().color = white;
            paramType.GetComponent<Image>().color = orange;
            paramName.GetComponent<Image>().color = orange;
            break;

            case 6:
            paramType.GetComponent<Image>().color = white;
            paramName.GetComponent<Image>().color = white;
            funcBody.GetComponent<Image>().color = orange;
            break;

            case 9:
            funcBody.GetComponent<Image>().color = white;
            funcType.GetComponent<Image>().color = orange;
            break;

            case 10:
            funcType.GetComponent<Image>().color = white;
            funcType.text = "";
            funcName.text = "";
            paramType.text = "";
            paramName.text = "";
            funcBody.text = "";
            break;

            case 11:
            repeatBtn.gameObject.SetActive(false);
            break;

            case 12:
            string funcBodySpaceRemove = funcBody.text.Replace(" ","");
            string[] returnStatSplit = funcBody.text.Split('-');

            if (funcType.text.Trim() == "float" && funcName.text.Trim() == "subValue" && paramType.text.Trim() == "float"
            && paramName.text.Trim() == "fValue" && returnStatSplit[0].Trim() == "return fValue"
            && funcBodySpaceRemove.Trim() == "returnfValue-1;")
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
}
