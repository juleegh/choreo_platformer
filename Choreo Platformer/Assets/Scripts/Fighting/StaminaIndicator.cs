using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaIndicator : MonoBehaviour
{
    [SerializeField] private GameObject indicator;

    public void Toggle(bool isActive)
    {
        indicator.SetActive(isActive);
    }
}
