using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//please,
public class StepAudio
    //please, stoooooop
{


    public void StartAudio()
    {
        AudioSource[] stepSources = Camera.main.GetComponentsInChildren<AudioSource>();
        stepSources[0].Play();
        stepSources[1].Play((ulong)stepSources[0].clip.length * 44100);
    
    
    }
    public void StopAudio()
    {
        AudioSource[] stepSources = Camera.main.GetComponentsInChildren<AudioSource>();
        stepSources[0].Stop();
        stepSources[1].Stop();
    }
}
