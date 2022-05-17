using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
  
    public AudioMixer mixer;
    public Slider sliderA; 
    public float sound;
    
    public void SetLever(float sliderValue){
        //Debug.Log(sliderA.value);
        Debug.Log(sound);
        GameData.gamedata.bgmSlider=sliderA.value;
        GameData.gamedata.bgmSound=Mathf.Log10(sliderValue)*20;
        Debug.Log(GameData.gamedata.bgmSlider);
        //Debug.Log(GameData.gamedata.bgmSound);
        mixer.SetFloat("BGM",Mathf.Log10(sliderValue)*20);
        Debug.Log(Mathf.Log10(sliderValue)*20);
        
    }
    public void SetStart(){
    //Debug.Log(sound);
    mixer.SetFloat("BGM",sound);
    //Debug.Log(Mathf.Log10(sliderValue)*20);
    
    }
    
    
}
