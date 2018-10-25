using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOverlayScript2 : MonoBehaviour {
    //lion test script

    //Variables
    public Sprite storedPortrait;
    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Image portrait;
    int currentImage;
    int totalImages;
    //References

	void Start () {

        portrait.sprite = image0;
        totalImages = 2;
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
            if (currentImage == 0)
            {
                portrait.sprite = image1;
            }
            if (currentImage == 1)
            {
                portrait.sprite = image2;
            }
            if (currentImage == 2)
            {
                portrait.sprite = image3;
            }
            currentImage += 1;
        }
        else
        {
            GetComponentInParent<NPCDialogueScript1>().Prompt();
            DestroySelf();
        }
    }
}
