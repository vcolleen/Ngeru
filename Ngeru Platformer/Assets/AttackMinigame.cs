using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackMinigame : MonoBehaviour
{
    // public Image AttackMeter; Original attack method.
    public Slider AttackMeter;

    //public Image missSpace;
    //public Image hitSpace;
   // public Image critSpace;

    public bool isTime = false;

    public int sign = 1;

    [SerializeField]
    private float AttackPercent;
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
        if (AttackMeter != null)
        {
            //AttackPercent = AttackMeter.fillAmount * 100;
            AttackPercent = AttackMeter.value * 100;
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
        if (AttackMeter != null)
        {
            // AttackMeter.fillAmount = AttackPercent / 100;
            AttackMeter.value = AttackPercent / 100;
        }


        if (isTime == true)
        {
            AttackPercent += sign;
            //Debug.Log(AttackPercent);

            if (AttackPercent >= 100 || AttackPercent <= 0)
            {
                sign *= -1;
                AttackPercent = ((AttackPercent <= 0) ? 0 : 100);

                 
            }
        }

        if (Input.anyKey && isTime == true)
        {
            CalculateHit();
            isTime = false;

        }

    }

    public void CalculateHit()
    {
        if (AttackPercent > minHitPercent & AttackPercent < maxHitPercent)
        {
            //Use light strike here.
          

            if (AttackPercent > minCritPercent & AttackPercent < maxCritPercent)
            {
                //use heavy strike function here.

                Debug.Log("YouCrit");
                attackAccess.HitHeavy();
                AttackPercent = 0;

            }

            else
            {
                Debug.Log("YouHit");
                attackAccess.HitLight();
                AttackPercent = 0;
            }

        }

        

        else //(AttackPercent < minHitPercent || AttackPercent > maxHitPercent)
        {

            attackAccess.SkipTurn();
            AttackPercent = 0;
            Debug.Log("Youmiss");


        }
    }


}

