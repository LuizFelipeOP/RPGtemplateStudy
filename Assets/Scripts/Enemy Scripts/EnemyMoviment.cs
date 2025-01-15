using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    private EnemyState enemyState;
    public float playerDetectRange = 4;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    public float attackCoolDown = 2;
    public float attackCoolDownTimer = 2;

    public float attackRange = 1.2f;
    public float speed = 4;
    public int facingDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }
    public void ChangeState(EnemyState newState)
    {
        //sai da animação
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIDLE", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving", false);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        //muda o state atual
        enemyState = newState;

        //muda para nova animação
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIDLE", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving", true);
        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState != EnemyState.Knockback){
            CheckForPlayer();
            if (attackCoolDownTimer > 0)
            {
                attackCoolDownTimer -= Time.deltaTime;
            }
            if (enemyState == EnemyState.Chasing)
            {
                Chase();
            }
            if(enemyState == EnemyState.Attacking)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    void Chase()
    {
        
        if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * speed;
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        
        if(hits.Length > 0)
        {
            player = hits[0].transform;

            //checar se o player esta na distancia certa e o cooldown pronto
            if (Vector2.Distance(transform.position, player.position) <= attackRange && attackCoolDownTimer <= 0)
            {
                attackCoolDownTimer = attackCoolDown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attacking)
            {
                ChangeState(EnemyState.Chasing);

            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
    Knockback
}