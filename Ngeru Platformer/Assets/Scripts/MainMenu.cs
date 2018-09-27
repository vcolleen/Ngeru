using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void QuitGame () 
	{
		Debug.Log ("Game Quit");
		Application.Quit ();
	}

    public void Load()
    {
        PlayerPrefs.GetFloat("PlayerX");
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentscenesave"));
    }
}
