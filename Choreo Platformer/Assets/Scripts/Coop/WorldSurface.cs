using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSurface : MonoBehaviour
{
    [SerializeField] protected Vector3 surfacePos;
    protected TaskItem itemOnTop;

    public bool IsEmpty {  get { return itemOnTop == null; } }

    public void Place(TaskItem item)
    {
        itemOnTop = item;
        itemOnTop.transform.SetParent(transform);
        itemOnTop.transform.localPosition = surfacePos;
        AfterItemPlaced();
    }

    public TaskItem Empty()
    {
        if (itemOnTop == null)
            return null;

        TaskItem item = itemOnTop;
        itemOnTop.transform.SetParent(null);
        itemOnTop = null;
        AfterItemRemoved();
        return item;
    }

    protected virtual void AfterItemPlaced()
    { 
    
    }

    protected virtual void AfterItemRemoved()
    {

    }
}
