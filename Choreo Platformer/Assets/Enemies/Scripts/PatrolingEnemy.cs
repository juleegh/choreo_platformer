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

    private void Update()
    {
        if (movedInTempo)
        {
            if (!TempoCounter.Instance.IsOnTempo)
            {
                movedInTempo = false;
            }
            else
            {
                return;
            }
        }

        if (TempoCounter.Instance.IsOnTempo)
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
