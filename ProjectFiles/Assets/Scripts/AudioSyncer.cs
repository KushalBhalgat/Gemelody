using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour {
	public float bias;
	public float timeStep;
	public float timeToBeat;
	public float restSmoothTime;
	private float preAudioValue;
	private float audioVal;
	private float audioTimer;
	public bool isBeat;

	public virtual void OnBeat()
	{
		audioTimer = 0;
		isBeat = true;
	}

	public virtual void OnUpdate()
	{ 
		preAudioValue = m_audioValue;
		audioVal = AudioSpectrum.spectrumValue;

		if (preAudioValue > bias && audioVal <= bias){
			if (audioTimer > timeStep){OnBeat();}
		}

		if (preAudioValue <= bias && audioVal > bias){
			if (audioTimer > timeStep){OnBeat();}
		}
		audioTimer += Time.deltaTime;
	}

	private void Update(){
		OnUpdate();
	}

}
