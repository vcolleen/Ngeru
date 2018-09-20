using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleCommandScript : MonoBehaviour {
    public InputField inputRef;
    public Text textRef;
    string fieldString;
    string newline = "\n";
    bool selectingLevel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameObject.GetComponent<Canvas>().enabled = !gameObject.GetComponent<Canvas>().enabled;
        }
	}

    public void ReadLine()
    {
        fieldString = inputRef.text;
        Debug.Log(fieldString);
        textRef.text = ("\n" + fieldString);

        if (fieldString == "help")
        {
            textRef.text = (textRef.text + "\n [help] \n [selectlevel] \n [mainmenu] \n [close] \n [additem]");
        }
        if (fieldString == "selectlevel")
        {
            textRef.text = (textRef.text + "\n use [selectlevel x] where x is \n [1] \n [2] \n [3]");
            selectingLevel = true;
        }
        if (fieldString == "mainmenu")
        {
            textRef.text = (textRef.text + "\n Send to Main Menu");
        }
        if (fieldString == "close")
        {
            textRef.text = (textRef.text + "\n closing game...");
        }
        if (fieldString == "additem")
        {
            textRef.text = (textRef.text + "\n use [additem x] where x is \n [healthpotion] \n [manapotion] \n [storyitem1] \n [storyitem2]");
        }
            Debug.Log("selectstage");
            if (fieldString == "selectlevel 1")
            {
                textRef.text = (textRef.text + "\n Level 1");
                Debug.Log("printstage");
            }
            if (fieldString == "selectlevel 2")
            {
                textRef.text = (textRef.text + "\n Level 2");
            }
            if (fieldString == "selectlevel 3")
            {
                textRef.text = (textRef.text + "\n Level 3");
            }
            selectingLevel = false;



        inputRef.text = "";
        fieldString = "";
    }
}
