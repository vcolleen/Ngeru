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

    public GameObject pink;
    public GameObject purple;
    public GameObject blue;
    public GameObject black;

    public BoxCollider2D colliderRef;
    public GameObject sphynxRef;
    //References

	void Start () {

        
        //totalImages = 53;
        pink.SetActive(false);
        purple.SetActive(false);
        blue.SetActive(false);
        black.SetActive(false);

        currentImage = 0;
        sphynxRef = GameObject.Find("Sphynx");
        colliderRef = sphynxRef.GetComponent<BoxCollider2D>();
        colliderRef.enabled = true;

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

        portrait.sprite = imageList[0];
    }
	
	void Update () {

		if (Input.GetKeyDown(KeyCode.E))
        {
            ButtonInteract();
        }
	}

    public void DestroySelf()
    {
        //Destroy(gameObject);

        //Play anim
        colliderRef.enabled = false;
    }

    public void Purple()
    {
        currentImage = 24;
        portrait.sprite = imageList[currentImage];
        Buttons();
        
    }

    public void Pink()
    {
        currentImage = 21;
        portrait.sprite = imageList[currentImage];
        Buttons();
    }
    public void Blue()
    {
        currentImage = 19;
        portrait.sprite = imageList[currentImage];
        Buttons();
    }
    public void Black()
    {
        currentImage = 17;
        portrait.sprite = imageList[currentImage];
        Buttons();
    }

    void Buttons()
    {
        purple.SetActive(!purple.activeInHierarchy);
        pink.SetActive(!pink.activeInHierarchy);
        blue.SetActive(!blue.activeInHierarchy);
        black.SetActive(!black.activeInHierarchy);
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
        if (currentImage <= 14)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        // pose question
        else if (currentImage == 15)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
            Buttons();
        }

        //picked black
        else if (currentImage == 17)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        else if (currentImage == 18)
        {
            currentImage = 16;
            portrait.sprite = imageList[currentImage];
            Buttons();
        }

        //picked blue
        else if (currentImage == 19)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        else if (currentImage == 20)
        {
            currentImage = 16;
            portrait.sprite = imageList[currentImage];
            Buttons();
        }

        //picked pink
        else if (currentImage == 21)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        else if (currentImage == 22)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        else if (currentImage == 23)
        {
            currentImage = 16;
            portrait.sprite = imageList[currentImage];
            Buttons();
        }

        //picked pruple
        else if (currentImage >= 24 && currentImage <= 41)
        {
            currentImage += 1;
            portrait.sprite = imageList[currentImage];
        }

        else if (currentImage == 42)
        {
            DestroySelf();
        }



       
            
    }
}
