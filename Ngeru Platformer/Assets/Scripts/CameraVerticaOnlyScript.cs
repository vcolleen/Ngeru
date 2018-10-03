using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVerticaOnlyScript : MonoBehaviour {

    [SerializeField]
    private Transform targetToFollow;

    void Update ()
    {
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(targetToFollow.position.y, 0f, 10f),
            transform.position.z);
    }
}
