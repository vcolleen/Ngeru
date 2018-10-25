using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlantTrigger : MonoBehaviour
{

    Animator anim;
    public bool inside;
    //public GameObject item;
    public GameObject tick;

    public GameObject cat;
    Animator ngeru;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        ngeru = cat.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (inside == true)
        {
            anim.SetBool("inside", true);
            if (Input.GetAxis("Trigger") == 1)
            {

                //SceneManager.LoadScene("VS1");

            }
        }

        //if (e.activeInHierarchy) {
        //    Debug.Log("Gotta catch em all");
        //}

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = false;
        }
    }


}
