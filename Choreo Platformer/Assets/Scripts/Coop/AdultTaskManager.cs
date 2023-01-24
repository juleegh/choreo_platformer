using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdultTaskManager : MonoBehaviour
{
    private TaskItem currentItem;
    [SerializeField] private float taskPerformSpeed = 0.33f;

    public void TryToExecuteTask(float deltaTime)
    {
        if (FrontStation() != null)
        {
            FrontStation().PerformTask(taskPerformSpeed * deltaTime);
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
        else
        {
            WorldSurface surface = FrontSurface();
            if (surface != null && !surface.IsEmpty)
            {
                currentItem = surface.Empty();
                currentItem.transform.SetParent(transform);
            }
        }
    }

    private TaskItem FrontItem()
    {
        RaycastHit hit;
        if (FrontRaycast(out hit, LayerMask.GetMask("Item")))
        {
            return hit.collider.GetComponent<TaskItem>();
        }
        return null;
    }

    private WorldSurface FrontSurface()
    {
        RaycastHit hit;
        if (FrontRaycast(out hit, LayerMask.GetMask("Surface")))
        {
            return hit.collider.GetComponent<WorldSurface>();
        }
        return null;
    }

    private TaskStation FrontStation()
    {
        RaycastHit hit;
        if (FrontRaycast(out hit, LayerMask.GetMask("Surface")))
        {
            return hit.collider.GetComponent<TaskStation>();
        }
        return null;
    }

    private bool FrontRaycast(out RaycastHit hit, int layerMask)
    {
        bool result = Physics.Raycast(transform.position + Vector3.up*0.25f, transform.forward, out hit, 5, layerMask);
        //Debug.LogError(hit.collider);
        return result;
    }
}
