using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SJ_DialManager : MonoBehaviour
{
    public Dialogue Dial_Class_1 = new Dialogue();
    public Dialogue Dial_Class_2 = new Dialogue();
    public Dialogue Dial_Class_3 = new Dialogue();

    public class Dialogue
    {
        public int dialNum = 0;

        private Dictionary<int, string> dialDict = new Dictionary<int, string>();

        public void AddDial(int key, string value)
        {
            dialDict.Add(key, value);
        }

        public string GetDial(int index)
        {
            return dialDict[index];
        }

        public int GetDialDictSize()
        {
            return dialDict.Count;
        }
    }

    void Awake()
    {
        Dial_Class_1.AddDial(Dial_Class_1.dialNum, "첫 프로그래밍 수업에 온 걸 환영한다");
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "이 수업에서는 프로그램을 작성하기 위해 알아야할 요소들을 배울거야");
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "그럼 가장 첫번째로 \"변수\"라는 것에 대해 배워보자");
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "변수는 값을 저장할 수 있는 저장소라고 생각하면 돼");
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "변수의 이름은 마음대로 설정할 수 있어, 다만 숫자만 아니면 돼");
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "\"변수이름 = 값\" 이라고 입력하면 변수에 값을 저장할 수 있어");   
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "원하는 변수 이름을 짓고 값을 넣어보자");  // event
        Dial_Class_1.AddDial(++Dial_Class_1.dialNum, "아주 훌륭해! 오늘 수업은 여기까지다");

        Dial_Class_2.AddDial(Dial_Class_2.dialNum, "두번째 프로그래밍 수업에 온 걸 환영한다");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "이번 수업에서는 \"함수\"라는 것에 대해 배워보자");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "함수는 입력한 값을 처리해서 되돌려주는, 프로그램을 구성하는 가장 작은 단위이며...");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "설명이 너무 어렵지? 그냥 사용하면서 이해해보자");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "\"Print\"라는 함수를 사용해볼거야");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "이름에서 알 수 있듯이 입력한 값을 화면에 보여주는 아주 간단한 함수야");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "함수를 사용하려면 함수 이름 뒤에 소괄호\"()\"를 붙이고 그 안에 원하는 값을 넣으면 돼");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "그럼 Print() 함수를 사용해서 아무 값이나 화면에 출력해보자");
        Dial_Class_2.AddDial(++Dial_Class_2.dialNum, "아주 훌륭해! 오늘 수업은 여기까지다");

        Dial_Class_3.AddDial(Dial_Class_3.dialNum, "세번째 프로그래밍 수업에 온 걸 환영한다");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "이번 수업에서는 \"반복문\"이라는 것에 대해 배워보자");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "반복문은 정해진 횟수만큼 원하는 작업을 반복해주는 아주 편리한 명령문");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "그럼 바로 사용법을 알려주도록 하마");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "저번 시간에 함수 사용했던거 기억하지?");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "같은 형태로 Loop()를 입력하고 이번에는 그 뒤에 중괄호\"{}\"를 붙이고 중괄호 안에 반복하고 싶은 걸 입력하면 돼");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "그럼 저번에 사용했던 Print 함수와 이번에 배운 Loop 반복문을 이용해서 원하는 값을 \"10번\" 출력해보자");
        Dial_Class_3.AddDial(++Dial_Class_3.dialNum, "아주 훌륭해! 오늘 수업은 여기까지다");
    }
}