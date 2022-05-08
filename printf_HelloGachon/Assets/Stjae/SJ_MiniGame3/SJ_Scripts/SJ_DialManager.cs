using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJ_DialManager : MonoBehaviour
{
    public Dictionary<int, string> dialDict;

    void Awake()
    {
        dialDict = new Dictionary<int, string>();
        CreateData();
    }

    void CreateData()
    {
        dialDict.Add(0, "오늘은 함수에 대해 배워볼거야");
        dialDict.Add(1, "함수는 입력한 값을 처리해서 되돌려주는, 프로그램을 구성하는 가장 작은 단위라고 할 수 있어");
        dialDict.Add(2, "지금 보이는 함수는 <color=blue>정수</color> 값을 입력받아 그 값에 <color=blue>1</color>을 더해 되돌려주는 <color=orange>addValue</color>라는 함수야");
        dialDict.Add(3, "함수 이름은 내가 임의로 지었어. 참고로 함수와 입력값의 이름은 맘대로 지어줄 수 있어");
        dialDict.Add(4, "정수로 입력 받은 값의 이름은 <color=orange>value</color>, 이름 앞에 붙은 <color=blue>int</color>는 이 값이 정수임을 뜻하지");
        dialDict.Add(5, "참고로 이렇게 함수가 입력받는 값을 인수 혹은 파라미터(parameter)라고 해");
        dialDict.Add(6, "<color=orange>{}</color> 안에 작성된 내용은 이 함수가 입력받은 값을 어떻게 처리할지를 보여줘");
        dialDict.Add(7, "함수에서 처리한 값을 되돌려줄 때는 <color=orange>return</color> 과 함께 뒤에 돌려주고 싶은 값을 입력해주면 돼");
        dialDict.Add(8, "아, 그리고 코드의 마지막에는 꼭 <color=orange>세미콜론</color>(;)을 붙이는 걸 잊지마");
        dialDict.Add(9, "함수의 이름 앞에 붙은 int 는 함수가 되돌려주는 값이 정수라는 뜻이야");
        dialDict.Add(10, "자, 설명을 들었으니 한 번 직접 함수를 작성해보자");
        dialDict.Add(11, "이름이 fValue인 실수(float)형 값을 입력 받아 1을 뺀 후 되돌려주는 subValue 라는 이름의 함수를 작성하고 대화창을 클릭하렴");
        dialDict.Add(12, "훌륭해! 오늘 수업은 여기까지다");
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
