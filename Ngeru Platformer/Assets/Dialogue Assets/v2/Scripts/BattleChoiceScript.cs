using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleChoiceScript : MonoBehaviour {

    string storedName;

    public Text textField;

	// Use this for initialization
	void Start () {
        storedName = GetComponentInParent<BattleTargetScript>().objectName;
        textField.text = ("Fight " + storedName + "?");
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
