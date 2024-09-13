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

    private void Update()
    {
        // Increment the cooldown timer
        cooldownTimer += Time.deltaTime;

        // Check if the cooldown timer has exceeded the attack cooldown
        if (cooldownTimer > attackCoolDown)
        {
            Attack();
        }
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
