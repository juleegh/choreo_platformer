using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
    [SerializeField] private bool recording = false;
    [SerializeField] private float sum;
    [SerializeField] private float beatCount;
    private float current;
    
    void Update()
    {
        current += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && recording)
        {
            sum += current;
            beatCount++;
            current = 0;
            Debug.LogError(sum / beatCount);
        }
    }
}
