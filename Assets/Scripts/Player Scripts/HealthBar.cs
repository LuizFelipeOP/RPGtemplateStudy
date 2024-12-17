using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public TMP_Text healthText;
    public Animator healthTextAnim;

    private void Start()
    {
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
    }
    public void ChangeHealth(int amount)
    {
        currentHealth += amount;
        healthText.text = "HP: " + currentHealth + " / " + maxHealth;
        healthTextAnim.Play("TextUpdate");


        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
