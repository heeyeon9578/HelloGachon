using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FadeINOUT : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(0.01f,10f)]
    private float fadeTime;
    
    public Image Panel;
    public float percent=0.0f;
    public bool FadeEnd=false;
    private IEnumerator Fade(float start, float end){
        float currentTime=0.0f;
       
        Panel.gameObject.SetActive(true);
        Color color=Panel.color;
        while(percent<1)
        {
            currentTime+=Time.deltaTime;
            percent=currentTime/fadeTime;

           
            color.a=Mathf.Lerp(start,end,percent);
            Panel.color=color;
            yield return FadeEnd;
        }
        SceneManager.LoadScene("SYGAbility");
    }
    private IEnumerator Fade2(float start, float end){
        float currentTime=0.0f;
       
        Panel.gameObject.SetActive(true);
        Color color=Panel.color;
        while(percent<1)
        {
            currentTime+=Time.deltaTime;
            percent=currentTime/fadeTime;

           
            color.a=Mathf.Lerp(start,end,percent);
            Panel.color=color;
            yield return FadeEnd;
        }
        SceneManager.LoadScene("Freedom");
    }
     private IEnumerator MTFade(float start, float end){
        float currentTime=0.0f;
       
        Panel.gameObject.SetActive(true);
        Color color=Panel.color;
        while(percent<1)
        {
            currentTime+=Time.deltaTime;
            percent=currentTime/fadeTime;

           
            color.a=Mathf.Lerp(start,end,percent);
            Panel.color=color;
            yield return FadeEnd;
        }
        SceneManager.LoadScene("MiniGame2");
    }
    private IEnumerator ComeBack(float start, float end){
        float currentTime=0.0f;
       
        Panel.gameObject.SetActive(true);
        Color color=Panel.color;
        while(percent<1)
        {
            currentTime+=Time.deltaTime;
            percent=currentTime/fadeTime;

           
            color.a=Mathf.Lerp(start,end,percent);
            Panel.color=color;
            yield return FadeEnd;
        }
        SceneManager.LoadScene("SYGAbility");
    }
    private IEnumerator HanMaum(float start, float end){
        float currentTime=0.0f;
       
        Panel.gameObject.SetActive(true);
        Color color=Panel.color;
        while(percent<1)
        {
            currentTime+=Time.deltaTime;
            percent=currentTime/fadeTime;

           
            color.a=Mathf.Lerp(start,end,percent);
            Panel.color=color;
            yield return FadeEnd;
        }
        SceneManager.LoadScene("SYGAbility");
    }
    public void startFadeOut(){
        
        StartCoroutine(Fade(0,1));
    }
    public void startFadeOut2(){
        
        StartCoroutine(Fade2(0,1));
    }
    public void MTstartFadeOut(){
        
        StartCoroutine(MTFade(0,1));
    }
    public void ComeBackFadeOut(){
        StartCoroutine(ComeBack(0,1));
    }
     public void HanmaumFadeOut(){
        StartCoroutine(HanMaum(0,1));
    }

    // Update is called once per frame
    
}
