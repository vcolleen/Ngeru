using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public GameObject lose;
    public Text healthText;
    private int health = 5;

    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public GameObject hp4;
    public GameObject hp5;
    public GameObject hp1s;
    public GameObject hp2s;
    public GameObject hp3s;
    public GameObject hp4s;
    public GameObject hp5s;

    // Use this for initialization
    void Start () {
        healthText.text = "Health: " + health.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if (health == 0)
        {
            lose.SetActive(true);
            hp1.SetActive(false);
            hp1s.SetActive(true);
            transform.position = new Vector3(-1.934f, -0.99f, 0);
        } else if (health == 4)
        {
            hp5.SetActive(false);
            hp5s.SetActive(true);
        }
        else if (health == 3)
        {
            hp4.SetActive(false);
            hp4s.SetActive(true);
        }
        else if (health == 2)
        {
            hp3.SetActive(false);
            hp3s.SetActive(true);
        }
        else if (health == 1)
        {
            hp2.SetActive(false);
            hp2s.SetActive(true);
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
