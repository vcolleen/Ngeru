using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAnimationScript : MonoBehaviour {

    public string charName;
    public int numBoxes;

    public GameObject imageRef;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RunNext();
            Debug.Log("Keydown");
        }
	}

    public void RunNext ()
    {
        imageRef.GetComponent<Animator>().SetTrigger("Next");
    }
}
