using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class FighterStatsUI : MonoBehaviour
{
    [SerializeField] private FighterStats healthSystem;
    [SerializeField] private Image healthBar;
    [SerializeField] private List<StaminaIndicator> staminaPoints;

    private void Start()
    {
        healthSystem.HealthChanged = UpdateHealth;
        healthSystem.UsedStamina = UpdateStamina;
        healthSystem.NotEnoughStamina = HighlightStamina;
    }

    private void UpdateHealth()
    {
        healthBar.fillAmount = (float) healthSystem.CurrentHealth / (float) healthSystem.MaxHealth;
    }

    private void UpdateStamina()
    {
        for (int i = 0; i < staminaPoints.Count; i++)
        {
            staminaPoints[i].Toggle(healthSystem.MaxStamina - healthSystem.CurrentStamina <= i);
        }
    }

    private void HighlightStamina()
    {
        staminaPoints[0].transform.parent.DOShakePosition(TempoCounter.Instance.TempoLength * 0.15f, 0.15f);
    }
}