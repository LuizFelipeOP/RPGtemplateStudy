using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyMoviment enemyMoviment;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMoviment = GetComponent<EnemyMoviment>();
    }
    public void KnockBack(Transform playerTransform, float knockbackForce, float knockBackTime, float stunTime)
    {
        enemyMoviment.ChangeState(EnemyState.Knockback);
        StartCoroutine(StunTimer(knockBackTime, stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.velocity = direction * knockbackForce;
    }    
    IEnumerator StunTimer(float knockBackTime, float stunTime)
    {
        yield return new WaitForSeconds(knockBackTime);
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMoviment.ChangeState(EnemyState.Idle);
    }
}
