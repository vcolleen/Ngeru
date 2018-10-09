using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AHHHH : MonoBehaviour {
    public Animator animRef;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Bite()
    {
        animRef.SetTrigger("Bite");
    }
    public void Scratch()
    {
        animRef.SetTrigger("Scratch");
    }
    public void Heal()
    {
        animRef.SetTrigger("Heal");
    }
    public void Hurt()
    {
        animRef.SetTrigger("Damage");
    }
}
