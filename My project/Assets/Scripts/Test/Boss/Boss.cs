using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private Transform firepoint2;
    [SerializeField] private GameObject[] fireballs;


    private Animator anim;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public float bossHealth = 100f; // Add this to keep track of boss health

    void Update()
    {
        // Check if the boss is still alive
        if (bossHealth > 0)
        {
            cooldownTimer += Time.deltaTime;

            if (cooldownTimer > attackCoolDown)
            {
                Attack();
            }
        }
        else
        {
            OnBossDeath();
        }
    }

    private void OnBossDeath()
    {
        // Stop the timer when boss health is 0
        FindObjectOfType<Timer>().StopTimer();
    }


    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0; // Reset the cooldown timer


        // Pooling object bullet
        int fireballIndex = FindFireball();
        fireballs[fireballIndex].transform.position = firepoint.position;
        fireballs[fireballIndex].GetComponent<EnemyBullet>().SetDirection(Mathf.Sign(transform.localScale.x));

        // Pooling object bullet
        int fireballIndex2 = FindFireball();
        fireballs[fireballIndex2].transform.position = firepoint2.position;
        fireballs[fireballIndex2].GetComponent<EnemyBullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}