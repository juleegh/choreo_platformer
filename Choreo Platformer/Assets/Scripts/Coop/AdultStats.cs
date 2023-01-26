using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdultStats : MonoBehaviour
{
    [SerializeField] private GameObject barContainer;
    [SerializeField] private Image staminaBar;
    private float currentStamina;

    private void Awake()
    {
        currentStamina = 1f;
        staminaBar.fillAmount = currentStamina;
    }

    private void Update()
    {
        barContainer.transform.eulerAngles = Vector3.zero;
    }

    public void ModifyStamina(float value)
    {
        currentStamina += value;
        staminaBar.fillAmount = currentStamina;
    }
}
