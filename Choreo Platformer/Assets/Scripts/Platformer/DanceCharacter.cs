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
        if (currentMovement != null && currentMovement.active && !currentMovement.IsComplete())
        {
            return;
        }

        if (TempoCounter.Instance.IsOnTempo(WorldManager.Instance.GetRequiredTempo()))
        {
            currentMovement = transform.DOMove(transform.position + direction, TempoCounter.Instance.TempoLength * tempoPercentage).OnComplete(() => CheckDeath());
        }
        else
        {
            currentMovement = transform.DOShakePosition(TempoCounter.Instance.TempoLength * tempoPercentage, 0.15f);
        }
    }

    public void GetHit(Enemy enemy)
    {
        if (currentMovement != null)
        {
            currentMovement.Kill();
        }

        bodyCollider.enabled = false;
        Vector3 direction = transform.position - enemy.transform.position;
        Vector3 position = WorldManager.Instance.FixedPosition(transform.position + direction);
        currentMovement = transform.DOMove(position, TempoCounter.Instance.TempoLength * tempoPercentage).OnComplete(() => ProcessHit());
        healthSystem.GetHit();
    }

    private void ProcessHit()
    {
        bodyCollider.enabled = true;
        healthSystem.GetHit();
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (!WorldManager.Instance.PositionExists(transform.position))
        {
            currentMovement = transform.DOMove(transform.position + Vector3.down * 3, 1).SetEase(Ease.InQuad).OnComplete(() => SpawnManager.Instance.Respawn());
        }
        else if (healthSystem.HasDied())
        {
            SpawnManager.Instance.Respawn();
        }
    }
}
