using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public Rigidbody2D rgbd;
    public GameObject ngeru;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter2D(Collision2D col)
    {
        ngeru.GetComponent<Animation>().Play("Flash");
        KnockbackForce(0.03f, 60, ngeru.transform.position);
        //StartCoroutine(Freeze());
    }

    public void KnockbackForce(float duration, float power, Vector2 direction)
    {
        float timer = 0;

        if (ngeru.GetComponent<ControllerPlayerScript>().isWalkingRight == true)
        {

            while (duration > timer)
            {
                timer += Time.deltaTime;
                rgbd.AddForce(new Vector2(direction.x * 150, direction.y + power));
            }

        } else if (ngeru.GetComponent<ControllerPlayerScript>().isWalkingLeft == true)
        {

            while (duration > timer)
            {
                timer += Time.deltaTime;
                rgbd.AddForce(new Vector2(direction.x * -150, direction.y + power));
            }

        } else
        {

            while (duration > timer)
            {
                timer += Time.deltaTime;
                rgbd.AddForce(new Vector2(direction.x * 150, direction.y + power));
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
