using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempoCounter : MonoBehaviour
{
    public static TempoCounter Instance { get { return instance; } }
    private static TempoCounter instance;

    private bool preBeatFrame;
    private bool postBeatFrame;
    bool firstTime;

    WaitForSeconds unaceptable;
    WaitForSeconds preAcceptable;
    WaitForSeconds postAcceptable;

    public bool IsOnPreTempo { get { return preBeatFrame; } }
    public bool IsOnPostTempo { get { return postBeatFrame; } }
    public bool IsOnTempo { get { return IsOnPreTempo || IsOnPostTempo; } }
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

    public void SetTempo(float freq)
    {
        frequency = freq;
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

    private void ClearDelay()
    {
        StopAllCoroutines();
        StartCoroutine(PostTempo());
    }

    private IEnumerator PostTempo()
    {
        yield return preAcceptable;
        preBeatFrame = false;
        postBeatFrame = true;
        yield return postAcceptable;
        postBeatFrame = false;
        StartCoroutine(PreTempo());
    }
}