using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSpriteScript : MonoBehaviour {

    public Sprite One;
    public Sprite Two;

    float timer = 0.5f;
    float delay = 0.5f;

    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = One;
    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == One)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Two;
                timer = delay;
                return;
            }
            if (this.gameObject.GetComponent<SpriteRenderer>().sprite == Two)
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = One;
                timer = delay;
                return;
            }
        }
    }
}
