using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveScript : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;
    public int startingHealth;
    public int attackDamage;
    public int currentHealth;
    public GameObject winMessage;

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
        winMessage.SetActive(false);
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
        transform.position += Vector3.right;
        Attack();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        Debug.Log("Hit Player");

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
        winMessage.SetActive(true);
    }

}



