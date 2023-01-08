using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DanceCharacter : MonoBehaviour
{
    [SerializeField] private float tempoPercentage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TryToMove(Vector3Int.forward);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TryToMove(Vector3Int.back);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            TryToMove(Vector3Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            TryToMove(Vector3Int.right);
        }
    }

    private void TryToMove(Vector3Int direction)
    {
        if (TempoCounter.Instance.IsOnTempo)
        {
            transform.DOMove(transform.position + direction, TempoCounter.Instance.TempoLength * tempoPercentage);
        }
        else
        {
            transform.DOShakePosition(TempoCounter.Instance.TempoLength * tempoPercentage, 0.15f);
        }
    }
}
