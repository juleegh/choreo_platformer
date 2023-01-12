using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DanceCharacter : MonoBehaviour
{
    [SerializeField] private float tempoPercentage;
    private HealthSystem healthSystem;
    private Collider bodyCollider;
    private Tween currentMovement;

    private void Awake()
    {
        healthSystem = GetComponent<HealthSystem>();
        bodyCollider = GetComponent<Collider>();
    }

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
            currentMovement = transform.DOMove(transform.position + direction, TempoCounter.Instance.TempoLength * tempoPercentage);
        }
        else
        {
            currentMovement = transform.DOShakePosition(TempoCounter.Instance.TempoLength * tempoPercentage, 0.15f);
        }
    }

    public void GetHit(Vector3 origin)
    {
        if (currentMovement != null)
        {
            currentMovement.Kill();
        }

        bodyCollider.enabled = false;
        Vector3 direction = transform.position - origin;
        Vector3 position = WorldManager.Instance.FixedPosition(transform.position + direction);
        currentMovement = transform.DOMove(position, TempoCounter.Instance.TempoLength * tempoPercentage).OnComplete(() => bodyCollider.enabled = true);
        healthSystem.GetHit();
    }
}
