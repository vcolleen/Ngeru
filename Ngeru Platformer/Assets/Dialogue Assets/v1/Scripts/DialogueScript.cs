using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour {
    //Variables
    bool interfaceOpen = false;
    bool promptOpen = false;
    string localStoredText;
    int localStoredOption;
    public bool isOverlay;

    public GameObject bubble;
    public GameObject prompt;
    public GameObject overlay;
    public GameObject player;

    GameObject currentComponent;
    Vector2 position;

    public float interactDelay;
    float activateTime;
    public float yOffset = 1.5f;

    public bool tempUseOverlay;

    //Dialogue Options Dictionary, bool true means dialogue option is end of interaction
    public List<string> dialogueList = new List<string>();

    //Functions
	void Start () {
        activateTime = Time.time;
        AddDialogueOptions();
	}
	
	void Update () {
        
	}



    //---------------------------------------------------------------------------------------------------------

    public void ReceiveInteraction ()
    {
        if (promptOpen)
        {
            if (isOverlay)
            {
                TextOverlay();
            }
            else
            {
                TextBubble(position);
            }
        }

        else
        {
            HoverPrompt(position, isOverlay, localStoredText, localStoredOption);
        }
    }

    public void HoverPrompt (Vector2 targetPosition, bool overlayTrue, string storedText, int selectedOption)
    {
        if (Time.time > (activateTime + interactDelay))
        {
            position = targetPosition;
            isOverlay = overlayTrue;
            localStoredText = storedText;
            localStoredOption = selectedOption;
            gameObject.GetComponent<Transform>().position = (position + new Vector2(0, yOffset));
            if (interfaceOpen)
            {
                currentComponent = gameObject.GetComponent<Transform>().GetChild(0).gameObject;
                Destroy(currentComponent);
            }
            activateTime = Time.time;
            player.GetComponent<PlayerScript>().canMove = true;
            gameObject.GetComponent<Transform>().position = (position + new Vector2(0, yOffset));
            Instantiate(prompt, gameObject.GetComponent<Transform>());
            interfaceOpen = true;
            promptOpen = true;
        }

    }

    public void TextBubble (Vector2 targetPosition)
    {
        if (Time.time > (activateTime + interactDelay))
        {
            position = targetPosition;
            if (interfaceOpen)
            {
                currentComponent = gameObject.GetComponent<Transform>().GetChild(0).gameObject;
                Destroy(currentComponent);
            }
            activateTime = Time.time;
            player.GetComponent<PlayerScript>().canMove = true;
            gameObject.GetComponent<Transform>().position = (position + (new Vector2 (-4.8f,-2.41f)));
            gameObject.GetComponent<Transform>().localScale = (new Vector3(1, 1, 1));
            Instantiate(bubble, gameObject.GetComponent<Transform>());
            //GetComponentInChildren<BubbleScript>().storedText = localStoredText;
            GetComponentInChildren<BubbleScript>().storedText = (dialogueList[localStoredOption]);

            interfaceOpen = true;
            promptOpen = false;
        }
    }

    public void TextOverlay ()
    {
        if (Time.time > (activateTime + interactDelay))
        {
            if (interfaceOpen)
            {
                currentComponent = gameObject.GetComponent<Transform>().GetChild(0).gameObject;
                Destroy(currentComponent);
            }
            activateTime = Time.time;
            player.GetComponent<PlayerScript>().canMove = false;

            gameObject.GetComponent<Transform>().position = (position + new Vector2(0, yOffset));
            Instantiate(overlay, gameObject.GetComponent<Transform>());
            GetComponentInChildren<OverlayScript>().storedText = (dialogueList[localStoredOption]);
            interfaceOpen = true;
            promptOpen = false;
        }
    }

    public void closeInterfaces ()
    {
        currentComponent = gameObject.GetComponent<Transform>().GetChild(0).gameObject;
        Destroy(currentComponent);
        interfaceOpen = false;
        promptOpen = false;
    }

    void AddDialogueOptions()
    {
        //Add dialogue options here
        //
        //Max characters
        //overlay: 40 (10 per line x 4)
        //Bubble: 42 (14 per line x 3)

        //0
        dialogueList.Add("Hello, small message");

        //1
        dialogueList.Add("Hi this is a slightly larger message");

        //2
        dialogueList.Add("This is gona be a nice big one I guess so enjoy the ride friend");

        //3
        dialogueList.Add("12345678901234567890123456789012345678901234567890123456789012345678901234567890");
    }

}
