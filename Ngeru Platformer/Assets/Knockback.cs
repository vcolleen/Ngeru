﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public Rigidbody2D rgbd;
    public GameObject ngeru;

    bool Frozen;
    float FreezeTime;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {

    if (Frozen) {

      ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
      //ngeru.GetComponent<Animator>().enabled = false;

      rgbd.velocity = new Vector2(0,0);

      if (Time.time > FreezeTime) {
        Frozen = false;
        ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
        //ngeru.GetComponent<Animator>().enabled = true;
        ngeru.GetComponent<Animator>().SetBool("Knockback", false);
        ngeru.GetComponent<Animator>().SetLayerWeight(3, 0);
        ngeru.GetComponent<Animator>().SetLayerWeight(0, 1);
        rgbd.GetComponent<Rigidbody2D>().gravityScale = 1;
      }
    }

	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        //ngeru.GetComponent<Animation>().Play("Knockback");
        ngeru.GetComponent<Animator>().SetBool("Knockback", true);
        ngeru.GetComponent<Animator>().SetLayerWeight(3, 1);
        ngeru.GetComponent<Animator>().SetLayerWeight(0, 0);
        ngeru.GetComponent<Animator>().SetLayerWeight(1, 0);
        ngeru.GetComponent<Animator>().SetLayerWeight(2, 0);
        KnockbackForce(0.03f, 50, new Vector2(-5,0));
    }

    public void KnockbackForce(float duration, float power, Vector2 direction)
    {

        float timer = 0;
        Frozen = true;
        FreezeTime = Time.time + 1f;

        if (ngeru.GetComponent<ControllerPlayerScript>().isWalkingRight == true)
        {

          while (duration > timer)
          {
              timer += Time.deltaTime;
              rgbd.AddForce(new Vector2(direction.x * 170, direction.y + power));
              rgbd.GetComponent<Rigidbody2D>().gravityScale = 10;
          }

        } else if (ngeru.GetComponent<ControllerPlayerScript>().isWalkingLeft == true)
        {

            while (duration > timer)
            {
                timer += Time.deltaTime;
                rgbd.AddForce(new Vector2(direction.x * -170, direction.y + power));
                rgbd.GetComponent<Rigidbody2D>().gravityScale = 10;
            }

        } else
        {

            while (duration > timer)
            {
                timer += Time.deltaTime;
                rgbd.AddForce(new Vector2(direction.x * 170, direction.y + power));
                rgbd.GetComponent<Rigidbody2D>().gravityScale = 10;
            }

        }

    }

    public IEnumerator Freeze()
    {
        ngeru.GetComponent<ControllerPlayerScript>().enabled = false;
        yield return new WaitForSeconds(1);
        ngeru.GetComponent<ControllerPlayerScript>().enabled = true;
    }
}
