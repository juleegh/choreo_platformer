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
    private int charge;

    public Action HealthChanged;
    public Action UsedStamina;
    public Action NotEnoughStamina;

    public int CurrentCharge { get { return charge; } }
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

    public void Heal(int quantity)
    {
        health += quantity;
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

    public void RecoverStamina()
    {
        if (stamina == maxStamina)
            return;

        stamina++;
        if (UsedStamina != null)
        {
            UsedStamina();
        }
    }

    public void SetCharge(int newCharge)
    {
        charge = newCharge;
    }
}
