using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {

    private int health = 5;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;

    //public AudioSource deathSound;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
        {
            hp1.SetActive(false);
            //deathSound.Play();
            StartCoroutine(TransitionDelay());
        } else if (health == 4)
        {
            hp5.SetActive(false);
        }
        else if (health == 3)
        {
            hp4.SetActive(false);
        }
        else if (health == 2)
        {
            hp3.SetActive(false);
        }
        else if (health == 1)
        {
            hp2.SetActive(false);
        }
    }

    public void TakeDamage ()
    {
        if (health > 0)
        {
            health--;
        }
    }

    IEnumerator TransitionDelay ()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Lose3");
    }
}
