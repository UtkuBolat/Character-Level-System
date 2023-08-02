
using Scripts.Systems.HealthSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHp = 100;
    public int hp;

    public int MaxHp => maxHp;
    public int Hp
    {
        get => hp;
        private set
        {
            var isDamage = value < hp;
            var healthChangeData = new HealthChangeArgs
            {
                NewValue = Mathf.Clamp(value, 0, maxHp),
                OldValue = hp,
                AttemptedChange = value - hp
            };
            hp = healthChangeData.NewValue;
            if (isDamage)
            {
                Damaged.Invoke(healthChangeData);
            }
            else
            {
                Healed.Invoke(healthChangeData);
            }
            if (hp <= 0)
            {
                Died.Invoke();
            }
        }
    }

    public UnityEvent<HealthChangeArgs> Healed;
    public UnityEvent<HealthChangeArgs> Damaged;
    public UnityEvent Died;
    private void Awake()
    {
        hp = maxHp;
    }

    public void Damage(int amount) => Hp -= amount;
    public void Heal (int amount) => Hp += amount;
    public void HealFull() => Hp = maxHp;
    public void Kill() => Hp = 0;
    public void Adjust(int value) => hp = value;
}
