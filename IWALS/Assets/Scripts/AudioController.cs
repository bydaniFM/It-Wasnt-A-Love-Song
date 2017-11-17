using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioSource audioSource;

	// Use this for initialization
	void Start ()
    {
        audioSource = this.GetComponent<AudioSource>();
	}
	
    public void changeAudioVolume(float knobValue)
    {
        audioSource.volume = knobValue; 
    }

    public void changeAudioPitch(float knobValue)
    {
        audioSource.pitch = (knobValue*3);
    }

    public void changeAudioSpread(float knobValue)
    {
        audioSource.spread = (knobValue*360);
    }

    public void changeAudioReverb(float knobValue)
    {
        audioSource.reverbZoneMix = knobValue;
    }

}
