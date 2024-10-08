using UnityEngine;

public class Pattack : MonoBehaviour
{
    [SerializeField] private float attackCoolDown;
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    [Header("SFX")]
    [SerializeField] private AudioClip shootingsound;

    private Animator anim;
    private Pmovement playermovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playermovement = GetComponent<Pmovement>();
    }
    private void Update()
    {
        if(!PauseMenu.isPaused)
        {
            if(Input.GetKey(KeyCode.J) && cooldownTimer > attackCoolDown )//&& playermovement.canAttack())
            { Attack();}//cooldownTimer += Time.deltaTime;
             cooldownTimer += Time.deltaTime;
        }
    }

    private void Attack()
    {
        //SoundManager2.instance.PlaySound(shootingsound);
        AudioManager.instance.PlayPew("Pew1");
        
       anim.SetTrigger("attack");
       cooldownTimer = 0;
       //pooling object bullet
       fireballs[FindFireball()].transform.position = firepoint.position;
       fireballs[FindFireball()].GetComponent<bullet>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for(int i = 0; i < fireballs.Length;i++)
        {
           if(!fireballs[i].activeInHierarchy)
           return i;
        }
        return 0;
    }
}