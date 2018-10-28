using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour {

    public GameObject objective;
    public GameObject inv;
    public GameObject pause;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.H))
        {
            if (objective.activeSelf == false)
            {
                objective.SetActive(true);
            }
            else
            {
                objective.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inv.activeSelf == false)
            {
                inv.SetActive(true);
            }
            else
            {
                inv.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (pause.activeSelf == false)
            {
                pause.SetActive(true);
                StartCoroutine(PauseGame());
            }
            else
            {
                pause.SetActive(false);
                Time.timeScale = 1f;
            }
        }

    }

    public void PressHelp()
    {
        if (objective.activeSelf == false)
        {
            objective.SetActive(true);
        }
        else
        {
            objective.SetActive(false);
        }
    }

    public void OpenInv()
    {
        if (inv.activeSelf == false)
        {
            inv.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void CloseInv()
    {
        if (inv.activeSelf == true)
        {
            inv.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void OpenPause()
    {
        if (pause.activeSelf == false)
        {
            pause.SetActive(true);
            StartCoroutine(PauseGame());
        } else
        {
            return;
        }
    }

    public void ClosePause()
    {
        if (pause.activeSelf == true)
        {
            pause.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            return;
        }
    }

    public IEnumerator PauseGame()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0f;
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuNEW");
    }
}
