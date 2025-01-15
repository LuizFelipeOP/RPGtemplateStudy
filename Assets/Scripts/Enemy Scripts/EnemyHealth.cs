using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
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
            Destroy(gameObject);
        }
    }
}
