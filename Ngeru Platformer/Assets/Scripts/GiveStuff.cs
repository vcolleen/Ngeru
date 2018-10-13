using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GiveStuff : MonoBehaviour {

    public Inventory inventory;


  
    // Use this for initialization
    void Start () {
        inventory = GameObject.FindObjectOfType<Inventory>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    //public void GiveMethings()
  //  {
  //      if (gameObject.tag == "HEALTH") {
  //          inventory.AddItem(hpot);
 //       }
  //      else if (gameObject.tag == "MANA")
  //      {
 //           inventory.AddItem(mpot);
 //       }
 //   }



      private void OnTriggerEnter2D (Collider2D other) {
      Debug.Log("gen-trigger detected");
       if (other.tag == "Item")
        {
            Debug.Log("Try to add item.");
             inventory.AddItem(other.GetComponent<Item>());
            Debug.Log("Item added!");
            //This method can only be done once I have access to the movement/interaction script.
        }
    }
}
