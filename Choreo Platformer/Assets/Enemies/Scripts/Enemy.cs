using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Update()
    {
        DoFrameActions();
    }

    protected virtual void DoFrameActions()
    { 
        CheckForObstacle(transform.position + Vector3.up * 0.5f, transform.forward, 0.52f);
        CheckForObstacle(transform.position + Vector3.up * 0.5f, -transform.forward, 0.52f);
        CheckForObstacle(transform.position + Vector3.up * 0.5f, transform.right, 0.52f);
        CheckForObstacle(transform.position + Vector3.up * 0.5f, -transform.right, 0.52f);
    }

    protected void CheckForObstacle(Vector3 center, Vector3 direction, float distance)
    {
        RaycastHit hit;

        if (Physics.Raycast(center, direction, out hit, distance))
        {
            DanceCharacter character = hit.transform.GetComponent<DanceCharacter>();
            if (character != null)
            {
                character.GetHit(this);
            }
        }
    }
}
