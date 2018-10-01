using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public TurnSystemScript turnSystem;
    public TurnSystemScript.TurnClass turnClass;
    public bool isTurn = false;

    public float startingHealth;

    public float MaxHP;
    public float DeadHold;

    public int attackDamage;
    public int critDamage;
    public float currentHealth;
    public Image healthImage;
    public GameObject buttonArea;

    //[SerializedField]
    GameObject enemy;
    EnemyMoveScript enemyScript;

    public float speed = 2.0f;
    private float timetoReach;
    private float length;

    public GameObject yaDed;


    void Start () {
        turnSystem = GameObject.Find("TurnBasedSystem").GetComponent<TurnSystemScript>();

        foreach(TurnSystemScript.TurnClass tc in turnSystem.playersGroup)
        {
            if (tc.playerGameObject.name == gameObject.name) turnClass = tc;
        }

        MaxHP = startingHealth;
        currentHealth = startingHealth;
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyScript = enemy.GetComponent<EnemyMoveScript>();
        buttonArea.SetActive(false);
        yaDed.SetActive(false);
   

    }

    public void Strike() {
        if (isTurn)
        {
            
            HitLight();
        }
    }

public void HitLight()
    {
        transform.position += Vector3.left;
        Attack();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        Debug.Log("Hit Enemy");
    }

    public void HitHeavy()
    {
        transform.position += Vector3.left;
        AttackHeavy();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        Debug.Log("Hit Enemy");
    }
    

	
    void Update () {
        

        isTurn = turnClass.isTurn;
        if(isTurn)
        {
            buttonArea.SetActive(true);
        }

        else
        {
            buttonArea.SetActive(false);
        }

        if(currentHealth > MaxHP)
        {
            currentHealth = MaxHP;
        }
        if (currentHealth <= DeadHold)
        {
            PlayerDead();
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

    void AttackHeavy()
    {
        enemyScript.TakeDamage(critDamage);
    }

    public void TakeDamage (int amount) {
        currentHealth -= amount;
        healthImage.fillAmount = (currentHealth / 100);

    }

    public void HPReset()
    {
        healthImage.fillAmount = (currentHealth / 100);
    }

    public void PlayerDead()
    {
        buttonArea.SetActive(false);
        yaDed.SetActive(true);


        if (Input.anyKey)
        {
            SceneManager.LoadScene(2);
        }

    }

}

