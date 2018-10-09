using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneScript : MonoBehaviour {

	public MovieTexture movTexture;
	[SerializeField]
	private string sceneName;

	// Use this for initialization
	void Start () {
		//GetComponent<Renderer>().material.mainTexture = movTexture;
    movTexture.Play();
	}

	// Update is called once per frame
	void Update () {
		if (movTexture.isPlaying) {
			return;
		} else {
			SceneManager.LoadScene(sceneName);
		}
	}
}
