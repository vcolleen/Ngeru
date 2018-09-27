using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChoiceScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Yes()
    {
        GetComponentInParent<BattleTargetScript>().Yes();
    }

    public void No()
    {
        GetComponentInParent<BattleTargetScript>().No();
    }
}
