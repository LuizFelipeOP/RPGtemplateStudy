using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    private EnemyState enemyState, newState;

    private bool isChasing;

    public float speed = 4;
    public int facingDirection = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }
    void ChangeState(EnemyState newState)
    {
        //sai da animação
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIDLE", false);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving", false);

        //muda o state atual
        enemyState = newState;

        //muda para nova animação
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIDLE", true);
        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isMoving", true);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.Chasing)
        {
            if (player.position.x > transform.position.x && facingDirection == -1 || 
                player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }
    }
    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }
}

public enum EnemyState
{
    Idle,
    Chasing
}