using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    float dirX, moveSpeed = 0.5f;
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > -2f)
            moveRight = false;
        if (transform.position.x < -8f)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
