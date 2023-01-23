using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultTaskManager : MonoBehaviour
{
    private TaskItem currentItem;


    public void TryToExecuteTask()
    {
        //if (CurrentStation != null)
        {
            // Execute task
        }
    }

    public void TryToToggleSelection()
    {
        if (currentItem == null)
        {
            TryToGrab();
        }
        else if (currentItem != null && FrontSurface() != null)
        {
            FrontSurface().Place(currentItem);
            currentItem = null;
        }
    }

    private void TryToGrab()
    {
        TaskItem item = FrontItem();
        if (item != null)
        {
            currentItem = item;
            if (currentItem.CurrentHolder != null)
            {
                currentItem.CurrentHolder.Empty();
            }
            currentItem.transform.SetParent(transform);
        }
    }

    private TaskItem FrontItem()
    {
        RaycastHit hit;
        if (FrontRaycast(out hit))
        {
            return hit.collider.GetComponent<TaskItem>();
        }
        return null;
    }

    private WorldSurface FrontSurface()
    {
        RaycastHit hit;
        if (FrontRaycast(out hit))
        {
            return hit.collider.GetComponent<WorldSurface>();
        }
        return null;
    }

    private TaskStation FrontStation()
    {
        RaycastHit hit;
        if (FrontRaycast(out hit))
        {
            return hit.collider.GetComponent<TaskStation>();
        }
        return null;
    }

    private bool FrontRaycast(out RaycastHit hit)
    {
        bool result = Physics.Raycast(transform.position + Vector3.up*0.25f, transform.forward, out hit, 5);
        //Debug.LogError(hit.collider);
        return result;
    }
}
