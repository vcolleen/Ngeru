using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;
    public KeyCode moveKey;

	// Use this for initialization

	void Start () {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystemScript>();

        foreach(TurnSystemScript.TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }
	}
	
	// Update is called once per frame
	void Update () {

        isTurn = turnClass.isTurn; 

        if(isTurn)
        {
            if(Input.GetKeyDown(moveKey))
            {
                transform.position += Vector3.left;
                isTurn = false;
                turnClass.isTurn = isTurn;
                turnClass.wasTurnPrev = true;
            }
        }
    }
}

