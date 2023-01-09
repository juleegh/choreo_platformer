using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image healthBar;

    private void Start()
    {
        healthSystem.HealthDecreased = UpdateHealth;    
    }

    private void UpdateHealth()
    {
        healthBar.fillAmount = (float) healthSystem.CurrentHealth / (float) healthSystem.MaxHealth;
    }
}
