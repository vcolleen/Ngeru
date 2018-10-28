using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RugTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;
    //public GameObject item;
    public GameObject tick;

    public GameObject cat;
    Animator ngeru;

    public AudioSource kapowSound;

    public bool gotItems;
    public bool combat;

    public GameObject eBut;
    bool eButActive = true;

    public Rigidbody2D rigid;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        ngeru = cat.GetComponent<Animator>();
        rigid.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        if (inside == true)
        {
            anim.SetBool("inside", true);
            if (Input.GetAxis("Trigger") == 1)
            {
                kapowSound.Play();
                if (combat)
                {
                    //Start Combat Here
                }

                StartCoroutine(Freeze());
                ngeru.SetLayerWeight(4, 1);
                ngeru.SetLayerWeight(2, 0);
                ngeru.SetTrigger("SwipeLow");
                anim.SetTrigger("play");
                tick.SetActive(true);
                eButActive = false;
                gameObject.GetComponent<RugTrigger>().enabled = false;

            }
        }

        if (inside == false)
        {
            anim.SetBool("inside", false);
        }

        if (eButActive == false)
        {
            eBut.SetActive(false);
        }

    }

    public IEnumerator Freeze()
    {
        rigid.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(1);
        rigid.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = true;
            if (eButActive)
            {
                eBut.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Transform>().CompareTag("Player"))
        {
            inside = false;
            if (eButActive)
            {
                eBut.SetActive(false);
            }
        }
    }


}
