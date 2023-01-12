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
        CheckForObstacle(transform.position + Vector3.up * 0.5f);
    }

    protected void CheckForObstacle(Vector3 center)
    {
        RaycastHit hit;

        if (Physics.Raycast(center, transform.forward, out hit, 0.52f))
        {
            DanceCharacter character = hit.transform.GetComponent<DanceCharacter>();
            if (character != null)
            {
                character.GetHit(center);
            }
        }
        else if (Physics.Raycast(center, -transform.forward, out hit, 0.52f))
        {
            DanceCharacter character = hit.transform.GetComponent<DanceCharacter>();
            if (character != null)
            {
                character.GetHit(center);
            }
        }
        else if (Physics.Raycast(center, transform.right, out hit, 0.52f))
        {
            DanceCharacter character = hit.transform.GetComponent<DanceCharacter>();
            if (character != null)
            {
                character.GetHit(center);
            }
        }
        else if (Physics.Raycast(center, -transform.right, out hit, 0.52f))
        {
            DanceCharacter character = hit.transform.GetComponent<DanceCharacter>();
            if (character != null)
            {
                character.GetHit(center);
            }
        }
    }
}
