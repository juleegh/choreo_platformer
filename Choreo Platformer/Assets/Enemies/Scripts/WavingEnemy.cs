using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WavingEnemy : Enemy
{
    [SerializeField] private List<Vector3Int> rotations;
    [SerializeField] private Transform prop;
    [SerializeField] private float tempoPercentage = 0.15f;

    private int rotationIndex;
    private bool movedInTempo;

    protected override void DoFrameActions()
    {
        base.DoFrameActions();
        CheckForObstacle(prop.position);
        
        if (movedInTempo)
        {
            if (!TempoCounter.Instance.IsOnPostTempo)
            {
                movedInTempo = false;
            }
            else
            {
                return;
            }
        }

        if (TempoCounter.Instance.IsOnPostTempo)
        {
            TryToRotate();
        }
    }

    private void TryToRotate()
    {
        rotationIndex++;
        if (rotationIndex >= rotations.Count)
            rotationIndex = 0;

        transform.DORotate(rotations[rotationIndex], TempoCounter.Instance.TempoLength * tempoPercentage);
        movedInTempo = true;
    }
}
