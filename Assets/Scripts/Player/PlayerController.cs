using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Move
    Vector3 velocity;
    Vector3 verticalInput;
    float Speed = 3.0f;
    float upspped = 3.0f;
    [Header("Animatons")]
    [SerializeField] Animator moveAnimator;
    [SerializeField] Animator dieAnimator;
    #endregion

    #region Health
    private float playerHealth;
    private float lerpTimer;
    float playerMaxHealth = 100;
    float chipSpeed = 2f;
    [Header("Character Health")]
    [SerializeField] Image frontHealthBar;
    [SerializeField] Image backHealthBar;
    [SerializeField] TextMeshProUGUI HealthText;
    #endregion

    
    private int level = 1;
    private float experiencePoints;
    private float requiredXp = 130;

    #region LevelUI
    private float delayTimer;

    [Header("LevelUI")]
    public Image frontXpBar;
    public Image backXpBar;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI XpText;

    // ------ Multiplier ---------
    [Range(1f, 300f)]
    private float additionMultiplier = 300;
    [Range(2f, 4f)]
    private float powerMultiplier = 2;
    [Range(7f, 14f)]
    private float divisionMultiplier = 7;
    #endregion

    private void Start()
    {
        playerHealth = playerMaxHealth;
        frontXpBar.fillAmount = experiencePoints / requiredXp;
        backXpBar.fillAmount = experiencePoints / requiredXp;
        requiredXp = CalculateRequiredXp();
        levelText.text = "" + level;
    }

    private void Update()
    {
        Move();
        playerHealth = Mathf.Clamp(playerHealth, 0, playerMaxHealth);
        UpdateHealthUI();
        Die();
        UpdateXpUI();
        if (experiencePoints > requiredXp)
        {
            LevelUp();
        }


    }

    #region Hareket
    void Move()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        verticalInput = new Vector3(0f, Input.GetAxis("Vertical"));
        moveAnimator.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        moveAnimator.SetFloat("upspeed", Mathf.Abs(Input.GetAxis("Vertical")));
        transform.position += velocity * Speed * Time.deltaTime;
        transform.position += verticalInput * upspped * Time.deltaTime;

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if ((Input.GetAxisRaw("Horizontal") == 1))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    #endregion

    #region Can
    public void UpdateHealthUI()
    {

        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = playerHealth / playerMaxHealth;
        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }
        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);
        }
    }

    public void Die()
    {
        if (playerHealth <= 0)
        {
            dieAnimator.SetBool("isDead", true);
            Destroy(gameObject, 0.75f);
        }
    }

    public void TakeDamage(float damage)
    {
        playerHealth -= damage;
        lerpTimer = 0f;
    }
    public void RestoreHealhth(float healAmount)
    {
        playerHealth += healAmount;
        lerpTimer = 0f;
    }

    #endregion

    #region Level
    public void UpdateXpUI()
    {
        float xpFraction = experiencePoints / requiredXp;
        float FXP = frontXpBar.fillAmount;

        if (FXP < xpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount = xpFraction;
        }

        if (delayTimer > 3)
        {
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / 4;
            frontXpBar.fillAmount = Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
        }
        XpText.text = experiencePoints + "/" + requiredXp;

    }
    public void GainExperiencePoints(int points)
    {
        experiencePoints += points;
        lerpTimer = 0f;
    }

    public void GainExperienceScalable(float points, int passedLevel)
    {
        if (passedLevel < level)
        {
            float multiplier = 1 + (level - passedLevel) * 0.1f;
            experiencePoints += points * multiplier;
        }
        else
        {
            experiencePoints += points;
        }
        lerpTimer = 0f;
        delayTimer = 0f;
    }

    public void LevelUp()
    {
        level++;
        frontXpBar.fillAmount = 0f;
        backXpBar.fillAmount = 0f;
        experiencePoints = Mathf.RoundToInt(experiencePoints - requiredXp);
        requiredXp = CalculateRequiredXp();
        levelText.text = "" + level;
        playerMaxHealth = playerHealth += 10;

    }
    private int CalculateRequiredXp()
    {
        int solveforRequiredXp = 0;
        for (int levelCycle = 1; levelCycle <= level; levelCycle++)
        {
            float divisionValue = Mathf.Max(1f, levelCycle / divisionMultiplier);
            solveforRequiredXp += (int)Mathf.Floor(levelCycle + additionMultiplier * Mathf.Pow(powerMultiplier, divisionValue));
        }
        return solveforRequiredXp / 4;
    }
        #endregion
 }
