using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

	GameObject PauseMenu;
	bool paused;




	void Start () {
		paused = false;
		PauseMenu = GameObject.Find("PauseMenu");
	}
	

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			paused = !paused;
		}
		if (paused) {
			PauseMenu.SetActive (true);
			Time.timeScale = 0;
		} 
		else if (!paused) 
		{
			PauseMenu.SetActive (false);
			Time.timeScale = 1;
		}
	}

	public void Resume()
	{
		paused = false;
	}

	public void MainMenu() 
	{
        SceneManager.LoadScene (0);
	}

	public void Save() 
	{
        PlayerPrefs.SetFloat("PlayerX", transform.position.x);
        PlayerPrefs.SetInt ("currentscenesave", SceneManager.GetActiveScene().buildIndex);
	}

	public void Load() 
	{
        PlayerPrefs.GetFloat("PlayerX");
        SceneManager.LoadScene(PlayerPrefs.GetInt("currentscenesave"));
	}

    public void QuitGame()
    {
        Debug.Log("Game Quit");
        Application.Quit();
    }

}
