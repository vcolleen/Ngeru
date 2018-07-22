using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveScript : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;
    public int startingHealth = 10;
    public int attackDamage = 5;
    public int currentHealth;

    GameObject player;
    PlayerHealth playerHealth;



    void Start()
    {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystemScript>();

        foreach (TurnSystemScript.TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }

        currentHealth = startingHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update() {

        isTurn = turnClass.isTurn; 

        if(isTurn)
        {
            StartCoroutine("WaitAndMove");
        }
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(2f);
        transform.position += Vector3.left;
        Attack();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;

        StopCoroutine("WaitAndMove");
    }

    void Attack ()
    {
        playerHealth.TakeDamage(attackDamage);
    }

    public void TakeDamage (int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
    }

}



