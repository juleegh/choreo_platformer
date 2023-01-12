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
        CheckForObstacle();
    }

    private void CheckForObstacle()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position + Vector3.up * 0.5f, -transform.forward, out hit, 0.52f))
        {
            DanceCharacter character = hit.transform.GetComponent<DanceCharacter>();
            if (character != null)
            {
                character.GetHit(this);
            }
        }
    }
}
