using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FighterStats : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private int maxStamina;

    private int health;
    private int stamina;

    public Action HealthChanged;
    public Action UsedStamina;
    public Action NotEnoughStamina;

    public int CurrentHealth { get { return health; } }
    public int MaxHealth { get { return maxHealth; } }
    public int CurrentStamina { get { return stamina; } }
    public int MaxStamina { get { return maxStamina; } }
    public bool HasEnoughStamina { get { return stamina > 0; } }

    private void Awake()
    {
        health = maxHealth;
        stamina = maxStamina;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (HealthChanged != null)
        {
            HealthChanged();
        }
    }

    public bool TryUseStamina()
    {
        if (stamina == 0)
        {
            if (NotEnoughStamina != null)
            {
                NotEnoughStamina();
            }
            return false;
        }
        else
        { 
            stamina--;
            if (UsedStamina != null)
            {
                UsedStamina();
            }
            return true;
        }
    }
}
