using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending_Credit_Manager_sk : MonoBehaviour
{
    public Image fadePanel;
    public GameObject title;
    public GameObject devs;
    public GameObject advisor;
    public GameObject notes;
    public GameObject team;
    public GameObject thx;
    float time = 0f;
    float fTime = 1.5f;

    void Start()
    {
        fade();
    }

    public void fade()
    {
        StartCoroutine(fadeFlow());
    }

    IEnumerator fadeFlow()
    {
        Color alpha = fadePanel.color;

        //**title 페이드 인 앤 아웃
        title.SetActive(true);
        fadePanel.gameObject.SetActive(true);
        time = 0f;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(1f);

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        title.SetActive(false);
        fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);
        

        //**devs 페이드 인 앤 아웃
        devs.SetActive(true);
        fadePanel.gameObject.SetActive(true);
        time = 0f;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(2f);

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        devs.SetActive(false);
        fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);


        //**advisor 페이드 인 앤 아웃
        advisor.SetActive(true);
        fadePanel.gameObject.SetActive(true);
        time = 0f;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(2f);

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        advisor.SetActive(false);
        fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);


        //**note 페이드 인 앤 아웃
        notes.SetActive(true);
        fadePanel.gameObject.SetActive(true);
        time = 0f;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(3f);

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        notes.SetActive(false);
        fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);


        //**team 페이드 인 앤 아웃
        team.SetActive(true);
        fadePanel.gameObject.SetActive(true);
        time = 0f;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(2f);

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        team.SetActive(false);
        fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);


        //**thx 페이드 인 앤 아웃
        thx.SetActive(true);
        fadePanel.gameObject.SetActive(true);
        time = 0f;

        //페이드 인
        while (alpha.a > 0f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadePanel.color = alpha;
            yield return null;
        }

        time = 0f;
        yield return new WaitForSeconds(2f);

        //페이드아웃
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / fTime;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadePanel.color = alpha;
            yield return null;
        }

        thx.SetActive(false);
        fadePanel.gameObject.SetActive(false);
        yield return new WaitForSeconds(1f);

        //시작화면으로 전환
        Debug.Log("goto StartScene");
        GameObject.Find("UI_Canvas").GetComponent<FadeINOUT>().LoadFadeOut("StartScene");
    }
}
