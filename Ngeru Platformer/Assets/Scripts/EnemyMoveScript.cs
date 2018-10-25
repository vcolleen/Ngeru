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

    public GameObject missText;
    public GameObject hitText;
    public GameObject critText;
    Animator text;

    public AudioSource flowerAttack;

    public GameObject otherGameObject;
    Animator scratch;

    Animator anim;




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

        if (enemyHP != null)
        {
            enemyPercentage = enemyHP.fillAmount * 100;
        }

        anim = GetComponent<Animator>();
        scratch = otherGameObject.GetComponent<Animator>();
    }

    void FixedUpdate() {

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

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlowerDeath"))
        {
            anim.SetBool("Death", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlowerAttack"))
        {
            anim.SetBool("Attack", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("MouseAttack"))
        {
            anim.SetBool("Attack", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("MouseTakeDamage"))
        {
            anim.SetBool("TakeDamage", false);
            scratch.SetBool("Scratch", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FlowerTakeDamage"))
        {
            anim.SetBool("TakeDamage", false);
            scratch.SetBool("Scratch", false);
        }
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(2f);
        Attack();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        ResetEnemyHP();
        hasAttacked = false;
        StopCoroutine("WaitAndMove");
    }

    void Attack ()
    {
        hitChance = Random.Range(0f, 100f);

        if (hitChance >= enemyCrit & hasAttacked == false)
        {
            anim.SetBool("Attack", true);
            flowerAttack.Play();
            critText.SetActive(true);
            playerHealth.TakeDamage(critDamage);
            Debug.Log("Enemy Crits!!!");
            hasAttacked = true;
            StartCoroutine(TextDelay());
        }

        if(hitChance <= enemyMissHit & hasAttacked == false)
        {
            EnemySkipTurn();
            flowerAttack.Play();
            missText.SetActive(true);
            Debug.Log("Enemy misses?!");
            hasAttacked = true;
            StartCoroutine(TextDelay());
        }

        else
        {
            if (hasAttacked == false)
            {
                anim.SetBool("Attack", true);
                flowerAttack.Play();
                hitText.SetActive(true);
                playerHealth.TakeDamage(attackDamage);
                Debug.Log("Enemy hits.");
                hasAttacked = true;
                StartCoroutine(TextDelay());
            }
        }

    }

    public void TakeDamage (int amount)
    {
        anim.SetBool("TakeDamage", true);
        scratch.SetBool("Scratch", true); 
        currentEnemyHealth -= amount;
        enemyHP.fillAmount = (currentEnemyHealth / 100);

        if (currentEnemyHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        anim.SetBool("Death", true);
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

    IEnumerator TextDelay()
    {
        yield return new WaitForSeconds(1);
        missText.SetActive(false);
        hitText.SetActive(false);
        critText.SetActive(false);
    }

}



