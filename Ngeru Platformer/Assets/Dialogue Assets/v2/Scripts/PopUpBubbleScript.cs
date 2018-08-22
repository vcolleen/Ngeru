using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpBubbleScript : MonoBehaviour {

    //variables
    float spawnTime;
    public float lifeTime;

    public string storedText;

    //references
    public Text textField;

	void Start () {
        spawnTime = (Time.time + lifeTime);
	}
	
	void Update () {
        textField.text = storedText;
        if (Time.time > spawnTime)
        {
            if (GetComponentInParent<NPCDialogueScript>().playerInCollider)
            {
                GetComponentInParent<NPCDialogueScript>().Prompt();
            }
            Destroy(gameObject);
        }
	}

}
