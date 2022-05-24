using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
  
    public AudioMixer mixer;
    public AudioMixer sfxMixer;
    public Slider sliderA;
    public Slider sliderB; 
    public float sound;
    public float sfxSound;

    void Start(){
        sliderA.value=GameData.gamedata.bgmSlider;
        sound=GameData.gamedata.bgmSound;
        sfxSound=GameData.gamedata.SFXsound;
        sliderB.value=GameData.gamedata.sfxSlider;
        SetStart();
    }

    void Update() {
        sliderB.value=GameData.gamedata.sfxSlider;
        sfxSound=GameData.gamedata.SFXsound;
        sliderA.value=GameData.gamedata.bgmSlider;
        sound=GameData.gamedata.bgmSound;
    }
    
    public void SetLever(float sliderValue){
        GameData.gamedata.bgmSlider=sliderA.value;
        GameData.gamedata.bgmSound=Mathf.Log10(sliderValue)*20;
        mixer.SetFloat("BGM",Mathf.Log10(sliderValue)*20);
        
    }
    public void SfxLever(float sliderValue){
        GameData.gamedata.sfxSlider=sliderB.value;
        GameData.gamedata.SFXsound=Mathf.Log10(sliderValue)*20;
        sfxMixer.SetFloat("SFX",Mathf.Log10(sliderValue)*20);
    }
    public void SetStart(){
        mixer.SetFloat("BGM",sound);
    }
}
