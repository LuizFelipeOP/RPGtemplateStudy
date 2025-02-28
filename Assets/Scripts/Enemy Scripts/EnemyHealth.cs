using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int ExpReward = 3;
    public delegate void MonsterDefeated(int exp);
    public static event MonsterDefeated OnMonsterDefeated;

    private void Start()
    {
        StatsManager.Instance.currentHealthGoblin = StatsManager.Instance.maxHealthGoblin;
    }

    public void ChangeHealth(int amount)
    {
        StatsManager.Instance.currentHealthGoblin += amount;

        if(StatsManager.Instance.currentHealthGoblin > StatsManager.Instance.maxHealthGoblin)
        {
            StatsManager.Instance.currentHealthGoblin = StatsManager.Instance.maxHealthGoblin;
        }
        else if(StatsManager.Instance.currentHealthGoblin <= 0)
        {
            OnMonsterDefeated(ExpReward);
            Destroy(gameObject);
        }
    }
}
