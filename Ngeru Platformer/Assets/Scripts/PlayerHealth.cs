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
    public GameObject inventory;

    //[SerializedField]
    GameObject enemy;
    EnemyMoveScript enemyScript;

    public float speed = 2.0f;
    private float timetoReach;
    private float length;

    Animator anim;

    public bool scratch;
    public bool bite;

    public float wait = 1;
    public float waiter = 0.5f;

    public GameObject missText;
    public GameObject hitText;
    public GameObject critText;

    public AudioSource catAttack;
    public AudioSource deathSound;

    [SerializeField]
    private string sceneName;


    void Start () {

        anim = GetComponent<Animator>();

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
    }

    public void Strike() {
        if (isTurn)
        {
            HitLight();
        }
    }

    public void HitLight()
    {
        Attack();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
    }

    public void HitHeavy()
    {
        AttackHeavy();
        isTurn = false;
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        buttonArea.SetActive(true);
        inventory.SetActive(true);
    }

    IEnumerator Timer2()
    {
        yield return new WaitForSeconds(1);
        buttonArea.SetActive(false);
        inventory.SetActive(false);
    }

    void Update () {

        isTurn = turnClass.isTurn;
        if (isTurn == true)
        {
            StartCoroutine(Timer());
        }

        if (isTurn == false) 
        {
            StartCoroutine(Timer2());
        }

        if(currentHealth > MaxHP)
        {
            currentHealth = MaxHP;
        }
        if (currentHealth <= DeadHold)
        {
            PlayerDead();
        }  
       

        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Scratch"))
        {
            anim.SetBool("Scratch", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Bite"))
        {
            anim.SetBool("Bite", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("NgeruBattleDamage"))
        {
            anim.SetBool("Ouch", false);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            anim.SetBool("Death", false);
        }



    }

    public void SkipTurn()
    {
        isTurn = false;
        catAttack.Play();
        turnClass.isTurn = isTurn;
        turnClass.wasTurnPrev = true;
        missText.SetActive(true);
        StartCoroutine(TextDelay());
    }

    void Attack()
    {
        anim.SetBool("Scratch", true);
        catAttack.Play();
        enemyScript.TakeDamage(attackDamage);
        hitText.SetActive(true);
        StartCoroutine(TextDelay());
    }

    void AttackHeavy()
    {
        anim.SetBool("Bite", true);
        catAttack.Play();
        enemyScript.TakeDamage(critDamage);
        critText.SetActive(true);
        StartCoroutine(TextDelay());
    }

    public void TakeDamage (int amount) {
        anim.SetBool("Ouch", true);
        currentHealth -= amount;
        healthImage.fillAmount = (currentHealth / 100);

    }

    public void HPReset()
    {
        healthImage.fillAmount = (currentHealth / 100);
    }

    public void PlayerDead()
    {
        anim.SetBool("Death", true);
        deathSound.Play();
        StartCoroutine(TransitionDelay());
    }

    IEnumerator TextDelay ()
    {
        yield return new WaitForSeconds(1);
        missText.SetActive(false);
        hitText.SetActive(false);
        critText.SetActive(false);
    }

    IEnumerator TransitionDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(sceneName);
    }

}

