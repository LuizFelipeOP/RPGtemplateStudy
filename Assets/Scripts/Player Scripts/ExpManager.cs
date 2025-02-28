using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExpManager : MonoBehaviour
{
    public int level;
    public int currentExp;
    public int expToLevel = 10;
    public float expGrowthMultiplier = 1.2f;

    public Slider expSlider;
    public TMP_Text currentLevelText;

    private void Start()
    {
        UpdateUI();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            GainExp(2);
        }
    }

    private void OnEnable()
    {
        EnemyHealth.OnMonsterDefeated += GainExp;
    }

    private void OnDisabled()
    {
        EnemyHealth.OnMonsterDefeated -= GainExp;
    }
    public void GainExp(int amount)
    {
        currentExp += amount;
        if(currentExp >= expToLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }
    public void LevelUp()
    {
        level++;
        currentExp -= expToLevel;
        expToLevel = Mathf.RoundToInt(expToLevel * expGrowthMultiplier);
    }

    public void UpdateUI()
    {
        expSlider.maxValue = expToLevel;
        expSlider.value = currentExp;
        currentLevelText.text = "Level: " + level;
    }
}
