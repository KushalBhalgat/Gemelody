using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent (typeof(AudioSource))]
public class AudioPeer : MonoBehaviour
{

    private AudioSource audioSource;
    public event EventHandler OnBuildUpSpawn;
    public float[] samples=new float[512];
    private float timerSampleRecheck=0f;
    void Start()
    {
        timerSampleRecheck = 0f;
        audioSource =GetComponent<AudioSource>();
    }

    void Update()
    {
        timerSampleRecheck+=Time.deltaTime;
        GetSpectrumAudioSource();
        if ((Mathf.Max(samples) * 10000) > 1 /*&& timerSampleRecheck>=1.5f*/) { /*timerSampleRecheck = 0f;*/ OnBuildUpSpawn?.Invoke(this, EventArgs.Empty); };
    }

    private void GetSpectrumAudioSource() {
        audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }
}
