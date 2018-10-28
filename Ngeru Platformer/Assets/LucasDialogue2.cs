using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucasDialogue2 : MonoBehaviour {

    public GameObject ngeru;
    public GameObject e;
    public GameObject dia1;
    public GameObject dia2;
    public GameObject dia3;
    public GameObject dia4;
    public GameObject dia5;

    public AudioSource bass;

    int i;
    bool inBox;

    // Use this for initialization
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (i == 1 && bass.isPlaying == false)
        {
            e.SetActive(true);
        }

        if (inBox == true && Input.GetKeyDown(KeyCode.E) && bass.isPlaying == false)
        {

            if (i == 0)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                bass.Play();
                e.SetActive(false);
                i++;
            } else if (i == 1)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                dia1.SetActive(true);
                e.SetActive(false);
                i++;
            }
            else if (i == 2)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                dia1.SetActive(false);
                dia2.SetActive(true);
                i++;
            }
            else if (i == 3)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                dia2.SetActive(false);
                dia3.SetActive(true);
                i++;
            }
            else if (i == 4)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                dia3.SetActive(false);
                dia4.SetActive(true);
                i++;
            }
            else if (i == 5)
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
                dia4.SetActive(false);
                dia5.SetActive(true);
                i++;
            }
            else
            {
                ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
                dia5.SetActive(false);
                e.SetActive(true);
                i = 0;
            }
        }

        if (ngeru.GetComponent<ControllerPlayerScript>().enabled == false)
        {
            ngeru.GetComponent<Animator>().SetBool("isIdle", true);
            ngeru.GetComponent<Animator>().SetBool("isWalkingLeft", false);
            ngeru.GetComponent<Animator>().SetBool("isWalkingRight", false);
            ngeru.GetComponent<Animator>().SetBool("isRunning", false);
            ngeru.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -2);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        e.SetActive(true);
        inBox = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        e.SetActive(false);
        inBox = false;
    }
}
