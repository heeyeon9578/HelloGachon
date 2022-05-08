using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    void Update(){
        if(Input.GetMouseButtonDown(0))
        {
            FadeToLevel();
        }
    }
    public void FadeToLevel(){
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete(){
        Debug.Log("111");
        //SceneManager.LoadScene("MiniGame2");

    }

}
