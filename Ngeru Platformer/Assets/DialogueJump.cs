using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueJump : MonoBehaviour {

    public GameObject dia1;
    //public GameObject dia2;
    public GameObject dia3;
    public GameObject dia4;
    public GameObject dia5;
    public GameObject dia6;
    public GameObject dia7;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.GetComponent<ControllerPlayerScript>().isGrounded == false)
        {
            dia1.SetActive(false);
            //dia2.SetActive(false);
            dia3.SetActive(false);
            dia4.SetActive(false);
            dia5.SetActive(false);
            dia6.SetActive(false);
            dia7.SetActive(false);
        } else
        {
            dia1.SetActive(true);
            //dia2.SetActive(true);
            dia3.SetActive(true);
            dia4.SetActive(true);
            dia5.SetActive(true);
            dia6.SetActive(true);
            dia7.SetActive(true);

        }
	}
}
