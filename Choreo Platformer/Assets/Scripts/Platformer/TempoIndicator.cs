using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempoIndicator : MonoBehaviour
{
    [SerializeField] private Image indicator;
    
    void Update()
    {
        indicator.color = TempoCounter.Instance.IsOnPostTempo ? Color.green : Color.red;
    }
}
