using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOverlayScript3 : MonoBehaviour {
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

    public Button yes;
    public Button no;
    //References

	void Start () {

        portrait.sprite = image0;
        totalImages = 2;
        yes.enabled = false;
        no.enabled = false;
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

    public void Yes()
    {
        portrait.sprite = image2;
        Buttons();
        currentImage = 2;
    }

    public void No()
    {
        portrait.sprite = image3;
        Buttons();
        currentImage = 3;
    }

    void Buttons()
    {
        yes.enabled = (!yes.enabled);
        no.enabled = (!no.enabled);
    }

    public void ButtonInteract()
    {
        if (currentImage <= totalImages)
        {
            if (currentImage == 0)
            {
                currentImage = 1;
                portrait.sprite = image1;
                Buttons();
            }
            if (currentImage == 2)
            {
                GetComponentInParent<NPCDialogueScript>().Prompt();
                DestroySelf();
            }
            if (currentImage == 3)
            {
                GetComponentInParent<NPCDialogueScript>().Prompt();
                DestroySelf();
            }
            
        }
        else
        {
            GetComponentInParent<NPCDialogueScript>().Prompt();
            DestroySelf();
        }
    }
}
