using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMinigame : MonoBehaviour
{
     public Image powerMeterBar;
    public bool isTime = false;

    public int sign = 1;

    [SerializeField]
    private float percentage;
    [SerializeField]
    private float currentAmount;
    [SerializeField]
    private float speed = 30;

    [SerializeField]
    private float minHitPercent;
    [SerializeField]
    private float maxHitPercent;


    [SerializeField]
    private float minCritPercent;
    [SerializeField]
    private float maxCritPercent;


    public PlayerHealth attackAccess;

    void Start()
    {
       attackAccess = GameObject.FindObjectOfType(typeof(PlayerHealth)) as PlayerHealth;
        if (powerMeterBar != null)
        {
            percentage = powerMeterBar.fillAmount * 100;
        }
    }


    public void TimeToIncrease()
    {

        if (attackAccess.isTurn == true)
        {
            if (isTime == true)
            {
                isTime = false;
            }

            if (isTime == false)
            {
                isTime = true;
            }
        }
    }

    public void Update()
    {
        if (powerMeterBar != null)
        {
            powerMeterBar.fillAmount = percentage / 100;
        }


        if (isTime == true)
        {
            percentage += sign;
            Debug.Log(percentage);

            if (percentage >= 100 || percentage <= 0)
            {
                sign *= -1;
                percentage = ((percentage <= 0) ? 0 : 100);

                 
            }
        }

        if (Input.anyKey && isTime == true)
        {
            CalculateHit();
            isTime = false;
            
            


        }

        ColourRecoder();

    }

    public void CalculateHit()
    {
        if (percentage > minHitPercent & percentage < maxHitPercent)
        {
            //Use light strike here.
          

            if (percentage > minCritPercent & percentage < maxCritPercent)
            {
                //use heavy strike function here.

                Debug.Log("YouCrit");
                attackAccess.HitHeavy();
                percentage = 0;

            }

            else
            {
                Debug.Log("YouHit");
                attackAccess.HitLight();
                percentage = 0;
            }

        }

        

        if (percentage < minHitPercent || percentage > maxHitPercent)
        {
                Debug.Log("Youmiss");
            attackAccess.SkipTurn();
            percentage = 0;


        }
    }

    void ColourRecoder()
    {
        if (percentage > minHitPercent & percentage < maxHitPercent)
        {
            powerMeterBar.color = Color.green;

        }

        if (percentage > minCritPercent & percentage < maxCritPercent)
        {
            powerMeterBar.color = Color.blue;

        }

        if (percentage < minHitPercent || percentage > maxHitPercent)
        {
            powerMeterBar.color = Color.yellow;

        }
    }

}

