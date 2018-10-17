using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;

    public int startingHealth;
    public int attackDamage;
    public float currentHealth;
    public Image healthImage;
    public GameObject button;

    public Animator animRef;
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
        button.SetActive(false);
        
    }

    public void Strike() {
        if(isTurn)
        {
            transform.position += Vector3.left;
            Attack();
            isTurn = false;
            turnClass.isTurn = isTurn;
            turnClass.wasTurnPrev = true;
            Debug.Log("Hit Enemy");

        }
    }
	
    void Update () {

        isTurn = turnClass.isTurn;
        if(isTurn)
        {
            button.SetActive(true);
        }

        else
        {
            button.SetActive(false);
        }

    }

    public void SkipTurn()
    {
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
    }

    void Attack()
    {
        enemyScript.TakeDamage(attackDamage);
    }

    public void TakeDamage (int amount) {
        currentHealth -= amount;
        healthImage.fillAmount = (currentHealth / 100);
    }

    public void HPReset()
    {
        healthImage.fillAmount = (currentHealth / 100);
    }

}

