using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueOverlayScript5 : MonoBehaviour {
    //lion test script

    //Variables
    public Sprite storedPortrait;
    public Sprite image0;
    public Sprite image1;
    public Sprite image2;
    public Sprite image3;
    public Sprite image4;
    public Sprite image5;
    public Sprite image6;
    public Sprite image7;
    public Sprite image8;
    public Sprite image9;
    public Sprite image10;
    public Sprite image11;
    public Sprite image12;
    public Sprite image13;
    public Sprite image14;
    public Sprite image15;
    public Sprite image16;
    public Sprite image17;
    public Sprite image18;
    public Sprite image19;
    public Sprite image20;
    public Sprite image21;
    public Sprite image22;
    public Sprite image23;
    public Sprite image24;
    public Sprite image25;
    public Sprite image26;
    public Sprite image27;
    public Sprite image28;
    public Sprite image29;
    public Sprite image30;
    public Sprite image31;
    public Sprite image32;
    public Sprite image33;
    public Sprite image34;
    public Sprite image35;
    public Sprite image36;
    public Sprite image37;
    public Sprite image38;
    public Sprite image39;
    public Sprite image40;
    public Sprite image41;
    public Sprite image42;

    public Image portrait;
    public int currentImage;
    int totalImages;

    public List<Sprite> imageList = new List<Sprite>();

    public Button pink;
    public Button purple;
    public Button blue;
    public Button black;
    //References

	void Start () {

        
        totalImages = 53;
        pink.enabled = false;
        purple.enabled = false;
        blue.enabled = false;
        black.enabled = false;

        currentImage = 1;

        imageList.Add(image0);

        imageList.Add(image1);
        imageList.Add(image2);
        imageList.Add(image3);
        imageList.Add(image4);
        imageList.Add(image5);
        imageList.Add(image6);
        imageList.Add(image7);
        imageList.Add(image8);
        imageList.Add(image9);
        imageList.Add(image10);
        imageList.Add(image11);
        imageList.Add(image12);
        imageList.Add(image13);
        imageList.Add(image14);
        imageList.Add(image15);
        imageList.Add(image16);
        imageList.Add(image17);
        imageList.Add(image18);
        imageList.Add(image19);
        imageList.Add(image20);
        imageList.Add(image21);
        imageList.Add(image22);
        imageList.Add(image23);
        imageList.Add(image24);
        imageList.Add(image25);
        imageList.Add(image26);
        imageList.Add(image27);
        imageList.Add(image28);
        imageList.Add(image29);
        imageList.Add(image30);
        imageList.Add(image31);
        imageList.Add(image32);
        imageList.Add(image33);
        imageList.Add(image34);
        imageList.Add(image35);
        imageList.Add(image36);
        imageList.Add(image37);
        imageList.Add(image38);
        imageList.Add(image39);
        imageList.Add(image40);
        imageList.Add(image41);
        imageList.Add(image42);

        portrait.sprite = imageList[1];
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
        portrait.sprite = imageList[32];
        Buttons();
        currentImage = 32;
    }

    public void No()
    {
        portrait.sprite = imageList[29];
        Buttons();
        currentImage = 29;
    }

    void Buttons()
    {
        purple.enabled = (!purple.enabled);
        pink.enabled = (!pink.enabled);
        blue.enabled = (!blue.enabled);
        black.enabled = (!black.enabled);
    }

    public void PlayMusic()
    {
        //Play Music here <<<-----------------------------------------------------------
    }
    public void TakeItem()
    {
        //Take Item here <<<-----------------------------------------------------------
    }

    public void ButtonInteract()
    {
        //pre question
        if (currentImage <= 16)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        // pose question
        if (currentImage == 17)
        {
            //Give Choice
        }

        //picked black
        if (currentImage == 18)
        {
            currentImage = 19;
            portrait.sprite = imageList[currentImage];
        }

        if (currentImage == 19)
        {
            currentImage = 17;
            portrait.sprite = imageList[currentImage];
        }

        //picked blue
        if (currentImage == 20)
        {
            currentImage = 21;
            portrait.sprite = imageList[currentImage];
        }

        if (currentImage == 21)
        {
            currentImage = 17;
            portrait.sprite = imageList[currentImage];
        }

        //picked pink
        if (currentImage == 22)
        {
            currentImage = 23;
            portrait.sprite = imageList[currentImage];
        }

        if (currentImage == 23)
        {
            currentImage = 24;
            portrait.sprite = imageList[currentImage];
        }

        if (currentImage == 24)
        {
            currentImage = 17;
            portrait.sprite = imageList[currentImage];
        }

        //picked pruple
        if (currentImage >= 25 && currentImage <= 41)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        if (currentImage == 42)
        {
            //fade
        }



        if (currentImage <= 26)
            {
                currentImage += 1;
                portrait.sprite = imageList[currentImage];
            }
            else if (currentImage == 27)
            {
                Buttons();
                currentImage += 1;
                portrait.sprite = imageList[currentImage];
            }
            else if (currentImage >= 29 && currentImage <=30)
            {
                currentImage += 1;
                portrait.sprite = imageList[currentImage];
            }
            else if (currentImage >= 32 && currentImage <= 43)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }
            else if (currentImage == 44)
        {
            PlayMusic();
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }
            else if (currentImage >= 45 && currentImage <= 51)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }
            else if (currentImage == 31)
            {
                GetComponentInParent<NPCDialogueScript1>().Prompt();
                DestroySelf();
            }
            else if (currentImage == 52)
        {
            GetComponentInParent<NPCDialogueScript1>().Prompt();
            DestroySelf();
        }
            
    }
}
