using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut_sk : MonoBehaviour
{
    public Image fadePanel;
    float time = 0f;
    float fTime = 1f;

    void Start()
    {
        //fadeOut();
        fadeIn();
    }

    public void fadeIn()
    {
        StartCoroutine(fadeInFlow());
    }

    public void fadeOut()
    {
        StartCoroutine(fadeOutFlow());
    }

    IEnumerator fadeInFlow()
    {
        fadePanel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = fadePanel.color;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        fadePanel.gameObject.SetActive(false);
        yield return null;
    }

    IEnumerator fadeOutFlow()
    {
        fadePanel.gameObject.SetActive(true);
        time = 0f;
        Color alpha = fadePanel.color;

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        fadePanel.gameObject.SetActive(false);
        yield return null;
    }
}
