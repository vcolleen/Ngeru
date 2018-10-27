using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreeSchtuff : MonoBehaviour {

    public GameObject pressE;
    public GameObject ngeru;
    public Animator bossTree;
    private int i = 0;
    public bool teleport = false;

    public GameObject tVine1;
    public GameObject tVine2;
    public GameObject tVine3;

    public AudioSource attackSound;
    public AudioSource vineSound;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		if (pressE.activeSelf == true && Input.GetKeyDown(KeyCode.E))
        {
            if (i == 0)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                teleport = true;
                ngeru.GetComponent<Animator>().SetLayerWeight(5, 1);
                ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(4, 0);
                ngeru.GetComponent<Animator>().SetBool("Attack", true);
                attackSound.Play();
                i++;
                StartCoroutine(VineScratch());
                StartCoroutine(NgeruTeleports());
            } else if (i == 1)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                teleport = true;
                bossTree.SetBool("Sad", true);
                ngeru.GetComponent<Animator>().SetLayerWeight(5, 1);
                ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(4, 0);
                ngeru.GetComponent<Animator>().SetBool("Attack", true);
                attackSound.Play();
                i++;
                StartCoroutine(VineScratch());
                StartCoroutine(NgeruTeleports());
            } else if (i == 2)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                teleport = true;
                bossTree.SetBool("Death", true);
                ngeru.GetComponent<Animator>().SetLayerWeight(5, 1);
                ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(4, 0);
                ngeru.GetComponent<Animator>().SetBool("Attack", true);
                attackSound.Play();
                i++;
                StartCoroutine(VineScratch());
                StartCoroutine(NgeruTeleports());
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        pressE.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pressE.SetActive(false);
    }

    IEnumerator NgeruTeleports()
    {
        yield return new WaitForSeconds(1);

        if (i == 3)
        {
            SceneManager.LoadScene("Victory3");
        } else
        {
            ngeru.transform.position = new Vector3(-9.95f, -1.22f, 0);
            ngeru.GetComponent<Animator>().SetBool("Attack", false);
            teleport = false;
            ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
            ngeru.GetComponent<Animator>().SetLayerWeight(5, 0);
            ngeru.GetComponent<Animator>().SetLayerWeight(0, 1);
        }
        
    }

    IEnumerator VineScratch()
    {
        yield return new WaitForSeconds(0.5f);
        vineSound.Play();

        if (i == 1)
        {
            tVine1.SetActive(false);
        } else if (i == 2)
        {
            tVine2.SetActive(false);
        } else if (i == 3)
        {
            tVine3.SetActive(false);
        }
    }
}
