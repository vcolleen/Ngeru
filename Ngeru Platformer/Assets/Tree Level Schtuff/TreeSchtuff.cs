using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeSchtuff : MonoBehaviour {

    public GameObject pressE;
    public GameObject ngeru;
    public Animator bossTree;
    private int i = 0;
    public bool teleport = false;

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
                ngeru.GetComponent<Animator>().SetLayerWeight(4, 1);
                ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
                ngeru.GetComponent<Animator>().SetBool("Attack", true);
                i++;
                StartCoroutine(NgeruTeleports());
            } else if (i == 1)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                teleport = true;
                bossTree.SetBool("Sad", true);
                ngeru.GetComponent<Animator>().SetLayerWeight(4, 1);
                ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
                ngeru.GetComponent<Animator>().SetBool("Attack", true);
                i++;
                StartCoroutine(NgeruTeleports());
            } else if (i == 2)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                teleport = true;
                bossTree.SetBool("Death", true);
                ngeru.GetComponent<Animator>().SetLayerWeight(4, 1);
                ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
                ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
                ngeru.GetComponent<Animator>().SetBool("Attack", true);
                i++;
                StartCoroutine(NgeruTeleports());
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (ngeru.GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            pressE.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pressE.SetActive(false);
    }

    IEnumerator NgeruTeleports()
    {
        yield return new WaitForSeconds(0.75f);

        if (i == 3)
        {
            //LoadScene
        } else
        {
            ngeru.transform.position = new Vector3(-9.95f, -1.22f, 0);
            ngeru.GetComponent<Animator>().SetBool("Attack", false);
            teleport = false;
            ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
            ngeru.GetComponent<Animator>().SetLayerWeight(4, 0);
            ngeru.GetComponent<Animator>().SetLayerWeight(0, 1);
        }
        
    }
}
