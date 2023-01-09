using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] private int maxHealth;

    private int currentHealth;
    public Action HealthDecreased;

    public int CurrentHealth {  get { return currentHealth; } }
    public int MaxHealth {  get { return maxHealth; } }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void GetHit()
    {
        currentHealth--;
        if (HealthDecreased != null)
        {
            HealthDecreased();
        }
    }
}
