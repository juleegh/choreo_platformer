using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoCounter : MonoBehaviour
{
    public static TempoCounter Instance { get { return instance; } }
    private static TempoCounter instance;

    private float currentBeatDelay;
    private bool preBeatFrame;
    private bool postBeatFrame;

    WaitForSeconds unaceptable;
    WaitForSeconds preAcceptable;
    WaitForSeconds postAcceptable;

    public bool IsOnPreTempo { get { return preBeatFrame; } }
    public bool IsOnPostTempo { get { return postBeatFrame; } }
    public bool IsOnTempo { get { return InsideAcceptableRange(WorldManager.Instance.GetRequiredTempo()); } }
    public float TempoLength { get { return frequency; } }
    public float CurrentBeatPercentage {  get { return currentBeatDelay / frequency; } }

    [SerializeField] private float frequency;
    [SerializeField] private float AcceptablePercentage;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartTempoCount();
    }

    private void FixedUpdate()
    {
        currentBeatDelay += Time.fixedDeltaTime;
    }

    public void StartTempoCount()
    {
        unaceptable = new WaitForSeconds(frequency * (1 - AcceptablePercentage));
        preAcceptable = new WaitForSeconds(frequency * AcceptablePercentage * 0.60f);
        postAcceptable = new WaitForSeconds(frequency * AcceptablePercentage * 0.40f);
        StartCoroutine(FirstTempoCount());
    }

    public void StopTempoCount()
    {
        StopAllCoroutines();
    }

    private IEnumerator FirstTempoCount()
    {
        yield return postAcceptable;
        postBeatFrame = false;
        StartCoroutine(TempoCount());
    }
    
    private IEnumerator TempoCount()
    {
        yield return unaceptable;
        preBeatFrame = true;
         yield return preAcceptable;
        preBeatFrame = false;
        postBeatFrame = true;
        currentBeatDelay = 0f;
        yield return postAcceptable;
        postBeatFrame = false;
        StartCoroutine(TempoCount());
    }

    public bool InsideAcceptableRange(float target)
    {
        if (CurrentBeatPercentage <= AcceptablePercentage || CurrentBeatPercentage >= 1 - AcceptablePercentage)
        {
            return true;
        }

        for (float current = target; current < 1; current += target)
        {
            if (CurrentBeatPercentage <= current + AcceptablePercentage && CurrentBeatPercentage >= current - AcceptablePercentage)
            { 
                return true;
            }
        }

        return false;
    }
}