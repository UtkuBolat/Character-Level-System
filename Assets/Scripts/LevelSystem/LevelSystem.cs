using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class LevelSystem : MonoBehaviour
{
    
    private int level = 1;
    private float currentXp;
    private float requiredXp = 130;
   

    private float lerpTimer;
    private float delayTimer;

    [Header("UI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;

    // ------ Multiplier ---------
    [Range (1f,300f)]
    private float additionMultiplier = 300;
    [Range(2f, 4f)]
    private float powerMultiplier = 2;
    [Range(7f, 14f)]
    private float divisionMultiplier = 7;

    private void Start()
    {
        frontXpBar.fillAmount = currentXp / requiredXp;
        backXpBar.fillAmount = currentXp / requiredXp;
        requiredXp = CalculateRequiredXp();
        levelText.text= ""+level;
    }

    private void Update()
    {
        UpdateXpUI();
        if(currentXp > requiredXp)
        {
            LevelUp();
        }
    }

    public void UpdateXp()
    {
        
       
        
       GainExperienceFLatRate(20);
        
        UpdateXpUI();
        if(currentXp > requiredXp) 
        {
        LevelUp();
        }
        
        
     
        
    }

    public void UpdateXpUI()
    {
        float xpFraction = currentXp / requiredXp;
        float FXP = frontXpBar.fillAmount;

        if(FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
        }

        if(delayTimer>3)
        {
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 4;
            frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount , percentComplete);
        }
        XpText.text = currentXp + "/" + requiredXp;
        
    }
    public void GainExperienceFLatRate(float xpGained)
    {
        currentXp += xpGained;
        lerpTimer = 0f;
        
        
       
    }

    public void GainExperienceScalable(float xpGained, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            currentXp += xpGained * multiplier;
        }
        else
        {
            currentXp += xpGained;
        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount =0f;
        currentXp = Mathf.RoundToInt(currentXp - requiredXp);
        requiredXp = CalculateRequiredXp();
        levelText.text = "" +level;

    }
    private int CalculateRequiredXp()
    {
        int solveforRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            solveforRequiredXp += (int) Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, levelCycle / divisionMultiplier));
        }
        return solveforRequiredXp / 4;
    }



}
