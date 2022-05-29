using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text tutoText;
    public Image tuto;
    public Sprite[] tutoImage;
    string[] tutorial={"게임시작에서 이름을 입력하고 게임을 시작할 수 있습니다.","스토리 진행방식으로 게임이 진행됩니다.","플레이어에게 능력치가 부여됩니다.","플레이어가 선택한 선택지에 따라서 능력치가 다르게 상승하거나 감소합니다.","플레이어가 직접 원하는 능력치를 상승시킬 수 있습니다.","능력치는 게임의 엔딩점수에 영향을 줍니다."};
    int tutoIndex=0;
    private void Start() {
        tutoText.text=tutorial[tutoIndex];
        tuto.sprite=tutoImage[tutoIndex];
    }
    public void NextTutorial()
    {
        if(tutoIndex<tutorial.Length-1){
            tutoIndex++;
            tuto.sprite=tutoImage[tutoIndex];
            tutoText.text=tutorial[tutoIndex];
            
        }
        
    }
    public void BeforeTutorial()
    {
        if(tutoIndex>0){
            tutoIndex--;
            tuto.sprite=tutoImage[tutoIndex];
            tutoText.text=tutorial[tutoIndex];  
        }
    }
}
