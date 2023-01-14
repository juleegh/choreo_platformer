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
    private Tween currentMovement;

    private void Awake()
    {
        rotationIndex = -1;
    }

    protected override void DoFrameActions()
    {
        base.DoFrameActions();

        bool isMoving = currentMovement != null && currentMovement.active && !currentMovement.IsComplete();
        if (!isMoving)
        { 
            CheckForObstacle(prop.position);
        }
        
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

        currentMovement = transform.DORotate(rotations[rotationIndex], TempoCounter.Instance.TempoLength * tempoPercentage);
        movedInTempo = true;
    }
}
