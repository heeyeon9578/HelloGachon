using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJ_DialManager2 : MonoBehaviour
{
    public Dictionary<int, string> dialDict;

    void Awake()
    {
        dialDict = new Dictionary<int, string>();
        CreateData();
    }

    void CreateData()
    {
        dialDict.Add(0, "지난 수업 때 함수를 만들어봤었지?");
        dialDict.Add(1, "오늘은 함수를 사용하는 법을 배워볼거야");
        dialDict.Add(2, "화면에 main 이라는 이름의 함수 보이지?");
        dialDict.Add(3, "지난번엔 설명하지 않았지만 이 main 함수는 매우 중요한 함수야");
        dialDict.Add(4, "우리가 사용하는 어떤 함수든지 이 main 함수 안에서 실행되야하고, main 함수가 종료되면 프로그램도 종료되게 돼");
        dialDict.Add(5, "어떤 것도 반환하지 않는 함수처럼 보이지만 main 함수는 종료할 때 0을 컴퓨터에게 반환하기 때문에 main 함수 이름 앞에는 int 값을 써줘야해");
        dialDict.Add(6, "오늘 배워볼 또 다른 함수는 printf라는 함수야. 이 함수는 숫자 또는 문자를 받아 그 값을 그대로 출력해줘");
        dialDict.Add(7, "이 함수는 미리 만들어져있는 함수고 화면에 값을 출력할 때 꼭 써야하는 함수야");
        dialDict.Add(8, "값을 출력할 공간이 있어야겠지? 화면 오른쪽에 검은 창이 보일꺼야. 우린 이 창을 콘솔이라고 해");
        dialDict.Add(9, "그럼 printf() 함수를 사용해보자. 자유롭게 인자 값을 넣어봐");
        // dialDict.Add(5, "");
        // dialDict.Add(5, "");
        // dialDict.Add(5, "");
        // dialDict.Add(5, "");
    }

    public string GetDial(int index)
    {
        return dialDict[index];
    }

    public int GetSize()
    {
        return dialDict.Count;
    }
}
