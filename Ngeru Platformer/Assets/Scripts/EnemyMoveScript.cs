using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMoveScript : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;

    //public int startingEnemyHealth;
    public int attackDamage;
   // public int currentEnemyHealth;
    public GameObject winMessage;

    public Image enemyHP;

    [SerializeField]
    private float startingEnemyHealth;
    [SerializeField]
    private float enemyPercentage;
    [SerializeField]
    private float currentEnemyHealth;

    [SerializeField]
    private float enemyCrit;
    [SerializeField]
    private float hitChance;
    [SerializeField]
    private int critDamage;
    [SerializeField]
    private float enemyMissHit;
    [SerializeField]
    private bool hasAttacked;


    GameObject player;
    PlayerHealth playerHealth;



    void Start()
    {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystemScript>();

        foreach (TurnSystemScript.TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }

        currentEnemyHealth = startingEnemyHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        winMessage.SetActive(false);

        if (enemyHP != null)
        {
            enemyPercentage = enemyHP.fillAmount * 100;
        }

    }

    void Update() {

        isTurn = turnClass.isTurn;
        if (enemyHP != null)
        {
            enemyPercentage = currentEnemyHealth;
            enemyHP.fillAmount = enemyPercentage / 100;
        }

        if (isTurn)
        {
            StartCoroutine("WaitAndMove");
        }
        if (currentEnemyHealth <= 0)
        {
            Death();
        }

    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(2f);
        Attack();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        Debug.Log("Attacks Player");
        ResetEnemyHP();
        hasAttacked = false;
        StopCoroutine("WaitAndMove");
    }

    void Attack ()
    {
        hitChance = Random.Range(0f, 100f);

        if (hitChance >= enemyCrit & hasAttacked == false)
        {
            playerHealth.TakeDamage(critDamage);
            Debug.Log("Enemy Crits!!!");
            hasAttacked = true;
        }

        if(hitChance <= enemyMissHit & hasAttacked == false)
        {
            EnemySkipTurn();
            Debug.Log("Enemy misses?!");
            hasAttacked = true;
        }

        else
        {
            if (hasAttacked == false)
            {
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy hits.");
                hasAttacked = true;
            }
        }





        //enemyHP.fillAmount = (currentEnemyHealth / 100);
    }

    public void TakeDamage (int amount)
    {
        currentEnemyHealth -= amount;
        enemyHP.fillAmount = (currentEnemyHealth / 100);

        if (currentEnemyHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(gameObject);
        winMessage.SetActive(true);
    }

    public void ResetEnemyHP()
    {
        enemyHP.fillAmount = (currentEnemyHealth / 100);
    }

    private void EnemySkipTurn()
    {
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
    }

}



