using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animation;

    public float cooldown = 2;
    private float timer;

    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void Attack()
    {
        if(timer <= 0)
        {
            animation.SetBool("isAttacking", true);
            timer = cooldown;
        }
    }

    public void FinishAttack()
    {
        animation.SetBool("isAttacking", false);
    }
}
