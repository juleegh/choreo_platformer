using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PatrolingEnemy : Enemy
{
    [SerializeField] private List<Vector3Int> directions;
    [SerializeField] private float tempoPercentage = 0.15f;

    private int directionIndex;
    private bool movedInTempo;

    protected override void DoFrameActions()
    {
        base.DoFrameActions();

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
            TryToMove();
        }
    }

    private void TryToMove()
    {
        directionIndex++;
        if (directionIndex >= directions.Count)
            directionIndex = 0;

        transform.DOMove(transform.position + directions[directionIndex], TempoCounter.Instance.TempoLength * tempoPercentage);
        movedInTempo = true;
    }
}
