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
    string[] tutorial={"게임시작에서 이름을 입력하고 게임을 시작할 수 있습니다.","게임은 스토리를 따라 진행됩니다.", "가천대와 캐릭터 방에 있는 특정 오브젝트들과 상호작용 할 수 있습니다.", "가천대와 캐릭터 방에 있는 특정 오브젝트들과 상호작용 할 수 있습니다.", "플레이어가 선택한 선택지에 따라 능력치가 상승하거나 감소합니다.","플레이어가 직접 원하는 활동을 골라 캐릭터를 육성시킬 수 있습니다.","능력치는 게임의 엔딩점수에 영향을 줍니다.", "캐릭터를 잘 육성해서 좋은 성적을 얻어보세요!"};
    int tutoIndex=0;
    private void Start() {
        tutoText.text=tutorial[tutoIndex];
        tuto.sprite=tutoImage[tutoIndex];
    }
    public void NextTutorial()
    {
        if(tutoIndex==tutorial.Length-1) {
            tutoIndex=0;
            tuto.sprite=tutoImage[tutoIndex];
            tutoText.text=tutorial[tutoIndex];
        }
        else if(tutoIndex<tutorial.Length-1){
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
