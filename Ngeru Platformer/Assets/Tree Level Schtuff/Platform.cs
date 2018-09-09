using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    public GameObject ngeru;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        ngeru.transform.parent = gameObject.transform;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        ngeru.transform.parent = null;
    }
}
