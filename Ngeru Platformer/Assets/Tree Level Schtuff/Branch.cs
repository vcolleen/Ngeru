using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Branch : MonoBehaviour {

    public GameObject ngeru;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        ngeru.GetComponent<Health>().TakeDamage();
        ngeru.GetComponent<Animation>().Play();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(ColliderOff());
    }

    IEnumerator ColliderOff()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
