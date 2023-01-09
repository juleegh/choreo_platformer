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
    bool firstTime;

    WaitForSeconds unaceptable;
    WaitForSeconds preAcceptable;
    WaitForSeconds postAcceptable;

    public bool IsOnPreTempo { get { return preBeatFrame; } }
    public bool IsOnPostTempo { get { return postBeatFrame; } }
    public bool IsOnTempo { get { return InsideAcceptableRange(WorldManager.Instance.GetRequiredTempo()); } }
    public float TempoLength { get { return frequency; } }

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
        firstTime = true;
        unaceptable = new WaitForSeconds(frequency * (1 - AcceptablePercentage));
        preAcceptable = new WaitForSeconds(frequency * AcceptablePercentage * 0.65f);
        postAcceptable = new WaitForSeconds(frequency * AcceptablePercentage * 0.35f);
        StartCoroutine(PreTempo());
    }

    public void StopTempoCount()
    {
        StopAllCoroutines();
    }

    private IEnumerator PreTempo()
    {
        if (firstTime)
        {
            yield return postAcceptable;
            firstTime = false;
        }
        yield return unaceptable;
        preBeatFrame = true;
        StartCoroutine(PostTempo());
    }

    private IEnumerator PostTempo()
    {
        yield return preAcceptable;
        preBeatFrame = false;
        postBeatFrame = true;
        currentBeatDelay = 0f;
        yield return postAcceptable;
        postBeatFrame = false;
        StartCoroutine(PreTempo());
    }

    private bool InsideAcceptableRange(float target)
    {
        float currentPercentage = currentBeatDelay / frequency;
        if (currentPercentage <= AcceptablePercentage || currentPercentage >= 1 - AcceptablePercentage)
        {
            return true;
        }

        for (float current = target; current < 1; current += target)
        {
            if (currentPercentage <= current + frequency * AcceptablePercentage &&  currentPercentage >= current - frequency * AcceptablePercentage)
                return true;
        }

        return false;
    }
}