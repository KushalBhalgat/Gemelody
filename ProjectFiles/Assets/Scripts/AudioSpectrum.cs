using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour {
    private float[] spectrum;
    public static float spectrumValue {get; private set;}
    
    private void Start(){
        spectrum = new float[128];
    }
    private void Update(){
        AudioListener.GetSpectrumData(spectrum, 0, FFTWindow.Hamming);
        if (spectrum != null && spectrum.Length > 0){
            spectrumValue = spectrum[0] * 100;
        }
    }
}
