using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }


}
