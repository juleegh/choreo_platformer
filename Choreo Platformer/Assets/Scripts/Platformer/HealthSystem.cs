using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int currentHealth;
    public Action HealthUpdated;

    public int CurrentHealth {  get { return currentHealth; } }
    public int MaxHealth {  get { return maxHealth; } }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void GetHit()
    {
        currentHealth--;
        if (HealthUpdated != null)
        {
            HealthUpdated();
        }
    }

    public void Restart()
    { 
        currentHealth = maxHealth;
        if (HealthUpdated != null)
        {
            HealthUpdated();
        }
    }

    public bool HasDied()
    {
        return currentHealth <= 0;
    }
}
