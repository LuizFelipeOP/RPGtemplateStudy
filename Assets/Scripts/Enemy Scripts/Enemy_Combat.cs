using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;
    public float stunTime;

    public float knockedBackForce;

    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        
        if(hits.Length > 0)
        {
            hits[0].GetComponent<HealthBar>().ChangeHealth(-StatsManager.Instance.damage);
            hits[0].GetComponent<PlayerMoviment>().KnockBack(transform, knockedBackForce, stunTime);
        }
    }
}
