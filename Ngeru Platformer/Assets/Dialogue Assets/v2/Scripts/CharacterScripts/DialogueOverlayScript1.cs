using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOverlayScript1 : MonoBehaviour {
    //lion test script

    //Variables
    public Sprite storedPortrait;
    public Sprite image1;
    public Sprite image2;
    public Image portrait;
    int currentImage;
    int totalImages;
    //References

	void Start () {

        portrait.sprite = image1;
	}
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.E))
        {
            ButtonInteract();
        }
	}

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void ButtonInteract()
    {
        if (currentImage <= totalImages)
        {
            currentImage += 1;
            portrait.sprite = image2;
        }
        else
        {
            GetComponentInParent<NPCDialogueScript>().Prompt();
            DestroySelf();
        }
    }
}
