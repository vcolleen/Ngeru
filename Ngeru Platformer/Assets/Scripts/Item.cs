﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { MANA, HEALTH, ATTACK };

public class Item : MonoBehaviour {
    public ItemType type;
    public Sprite spriteNeutral;
    public Sprite spriteHighlighted;
    public int maxSize;
    public PlayerHealth heals;

    void Awake()
    {
        heals = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
    }

    public void Use()
    {
        switch (type) {
            case ItemType.MANA:
                Debug.Log("Glug glug mana");
                //Tie into attributes once the framework exists.
                break;
            case ItemType.HEALTH:
                Debug.Log("Glug glug health");
                //Tie into attributes once the framework exists.
                heals.currentHealth += 20;
                heals.HPReset();
                break;
            case ItemType.ATTACK:
                Debug.Log("triple six blaze it");
                //Tie into attributes once the framework exists.
                break;

                // YOU MUST GO TO INVENTORY SCRIPT, LINE 175 UNDER LOAD FUNCTION, IN ORDER TO ADD OTHER TYPES.
        }
    }

   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}