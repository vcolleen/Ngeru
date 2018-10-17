using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType { HEALTH, HEALTHMED, HEALTHBIG, BROKENHEALTH };



public class Item : MonoBehaviour {
    public ItemType type;
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;
    public int maxSize;

    public string itemName;

    public string description;


    public Sprite ChangeTo;

    public PlayerHealth heals;

    public PlayerHealth moreheals;
    public Slot ItemCheck;



    void Awake()
    {
        heals = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
      
        // itemCard = itemCardObject;
        //ItemCheck = GameObject.FindObjectOfType(typeof(Slot)) as Slot;
    }

    public void Use()
    {
        switch (type) {
            case ItemType.HEALTHMED:
                Debug.Log("medium health");
                //Tie into attributes once the framework exists.
                heals.currentHealth += 20;
                heals.HPReset();
                break;

            case ItemType.HEALTH:
                Debug.Log("small health");
                //Tie into attributes once the framework exists.
                heals.currentHealth += 10;
                heals.HPReset();
              
                break;

            case ItemType.HEALTHBIG:
                moreheals.currentHealth += 50;
                heals.currentHealth += 50;
                Debug.Log("big health");
                //Tie into attributes once the framework exists.
              //  heals.currentHealth += 40;
               // heals.HPReset();

                break;

            case ItemType.BROKENHEALTH:
                heals.currentHealth += 20;
                heals.HPReset();
                // YOU MUST GO TO INVENTORY SCRIPT, LINE 175 UNDER LOAD FUNCTION, IN ORDER TO ADD OTHER TYPES.
                break;
        }
    }

   
    // Use this for initialization
    void Start () {
		
	}

    public string GetToolTip()
    {
        return string.Format(itemName);
    }
	
	// Update is called once per frame
	void Update () {
        moreheals = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
    }
}
