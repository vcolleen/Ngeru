using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject lose;
    public Text healthText;
    private int health = 5;

    // Use this for initialization
    void Start () {
        healthText.text = "Health: " + health.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
        {
            lose.SetActive(true);
            transform.position = new Vector3(-1.934f, -0.99f, 0);
        }
	}

    public void TakeDamage ()
    {
        if (health > 0)
        {
            health--;
            healthText.text = "Health: " + health.ToString();
        }
    }
}
