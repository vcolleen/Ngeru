using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CouchTrigger : MonoBehaviour {

    Animator anim;
    public bool inside;
    //public GameObject item;
    public GameObject tick;
    public Rigidbody2D catBody;

    public GameObject cat;
    Animator ngeru;

    public AudioSource kapowSound;

    //public GameObject a, b, c, d, e, f, g;
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

        if (cat.GetComponent<ControllerPlayerScript>().isGrounded == false)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        } else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (inside == true)
        {
            
            anim.SetBool("inside", true);
            if (Input.GetAxis("Trigger") == 1)
            {
                
                StartCoroutine(HealSound());
                if (combat)
                {
                    //Start Combat Here
                }

                StartCoroutine(Freeze());
                ngeru.SetLayerWeight(4, 1);
                ngeru.SetLayerWeight(2, 0);
                ngeru.SetTrigger("Pee");
                anim.SetTrigger("play");
                tick.SetActive(true);
                eButActive = false;
                gameObject.GetComponent<CouchTrigger>().enabled = false;
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

    IEnumerator HealSound ()
    {
        yield return new WaitForSeconds(0.5f);
        kapowSound.Play();
    }

}
