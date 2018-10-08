using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour {

    public MovieTexture movie;

    RawImage rawImageComp;
    AudioSource audioS;

	// Use this for initialization
	void Start () {
        rawImageComp = GetComponent<RawImage>();
        audioS = GetComponent<AudioSource>();

        PlayClip();
	}
	
	void PlayClip() {
        rawImageComp.texture = movie;
        movie.Play();
        audioS.clip = movie.audioClip;
        audioS.Play();
    }
}
