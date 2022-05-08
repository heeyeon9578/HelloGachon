using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioPlay : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer mixer;
    public void SetLever(float sliderValue){
        mixer.SetFloat("BGM",Mathf.Log10(sliderValue)*20);
    }
    
    
}
