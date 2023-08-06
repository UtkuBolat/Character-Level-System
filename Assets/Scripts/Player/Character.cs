using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
   //------Move------- 
    Vector3 velocity;
    Vector3 verticalInput;
    float Speed = 3.0f;
    float upspped = 3.0f;
    [Header("Animatons")]
    [SerializeField] Animator moveAnimator;
    [SerializeField] Animator dieAnimator;
    //------Health------- 
    private float health;
    private float lerpTimer;
    float maxHealth = 100;
    float chipSpeed = 2f;
    [Header("Character Health")]
    [SerializeField] Image frontHealthBar;
    [SerializeField] Image backHealthBar;
    [SerializeField] TextMeshProUGUI HealthText;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        Move();
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        Die();

    }
    // --------- Character Move Scripts ---------
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
    // --------- Character Health Scripts ---------
    public void UpdateHealthUI()
    {

        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;
        float hFraction = health / maxHealth;
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
        HealthText.text = Mathf.Round(health) + "/" + Mathf.Round(maxHealth);
    }

    public void Die()
    {
        if (health <= 0)
        {
            dieAnimator.SetBool("isDead", true);
            Destroy(gameObject, 0.75f);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
    }
    public void RestoreHealhth(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
    }
    // ---------------------------------------------


}
