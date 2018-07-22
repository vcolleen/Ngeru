using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;
	public KeyCode moveKey;

    public int startingHealth = 20;
    public int attackDamage = 5;
    public int currentHealth;

    GameObject enemy;
    EnemyMoveScript enemyScript;

    void Start () {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystemScript>();

        foreach(TurnSystemScript.TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }

        currentHealth = startingHealth;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScript = enemy.GetComponent<EnemyMoveScript>();
    }
	

	void Update () {

        isTurn = turnClass.isTurn; 

        if(isTurn)
        {
            if (Input.GetKeyDown(moveKey))
            {
                transform.position += Vector3.left;
                Attack();
                isTurn = false;
                turnClass.isTurn = isTurn;
                turnClass.wasTurnPrev = true;
            }
        }
    }

    void Attack()
    {
        enemyScript.TakeDamage(attackDamage);
    }

    public void TakeDamage (int amount) {
        currentHealth -= amount; 
    }
}

