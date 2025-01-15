using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;


    [Header("Combat stats")]
        public int damage;
        public float weaponRange;
        public float knockbackForce;
        public float knockbackTime;
        public float stunTime;

    [Header("Moviment stats")]
        public int speed;

    [Header("Health Stats")]
        public int maxHealth;
        public int currentHealth;

        public int maxHealthGoblin;
        public int currentHealthGoblin;

    public void Awake()
    {
        if(Instance == null){
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}


