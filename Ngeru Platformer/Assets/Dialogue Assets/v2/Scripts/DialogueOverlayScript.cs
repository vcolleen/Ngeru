using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOverlayScript : MonoBehaviour {

    //Variables
    public string storedText;
    int currentTextFile;
    public Sprite storedPortrait;
    public Image portrait;

    //References
    public Text textboxText;
    public Text buttonText;

	void Start () {
        currentTextFile = 1;
        portrait.sprite = storedPortrait;
	}
	
	void Update () {
        textboxText.text = storedText;
		if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTextFile == 1)
            {
                try
                {
                    storedText = GetComponentInParent<NPCDialogueScript>().textFile2.text;
                    currentTextFile = 2;
                    textboxText.text = storedText;
                }

                catch (UnassignedReferenceException)
                {
                    GetComponentInParent<NPCDialogueScript>().Prompt();
                    Destroy(gameObject);
                }
            }
            else if (currentTextFile == 2)
            {
                try
                {
                    storedText = GetComponentInParent<NPCDialogueScript>().textFile3.text;
                    currentTextFile = 3;
                    textboxText.text = storedText;
                }

                catch (UnassignedReferenceException)
                {
                    GetComponentInParent<NPCDialogueScript>().Prompt();
                    Destroy(gameObject);
                }
            }
            else if (currentTextFile == 3)
            {
                try
                {
                    storedText = GetComponentInParent<NPCDialogueScript>().textFile4.text;
                    currentTextFile = 4;
                    textboxText.text = storedText;
                }

                catch (UnassignedReferenceException)
                {
                    GetComponentInParent<NPCDialogueScript>().Prompt();
                    Destroy(gameObject);
                }
            }
            else if (currentTextFile == 4)
            {
                try
                {
                    storedText = GetComponentInParent<NPCDialogueScript>().textFile5.text;
                    currentTextFile = 5;
                    textboxText.text = storedText;
                }

                catch (UnassignedReferenceException)
                {
                    GetComponentInParent<NPCDialogueScript>().Prompt();
                    Destroy(gameObject);
                }

            }
            else
            {
                Destroy(gameObject);
            }
            //DestroySelf();
        }
	}

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
