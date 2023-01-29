using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSurface : MonoBehaviour
{
    [SerializeField] protected Vector3 surfacePos;
    protected TaskItem itemOnTop;

    public bool IsEmpty {  get { return itemOnTop == null; } }

    private void Awake()
    {
        Vector3 pos = new Vector3(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));
        transform.position = pos;
    }

    public bool TryToPlace(TaskItem item)
    {
        if (itemOnTop != null)
        {
            bool result = itemOnTop.TryToPileUp(item.ItemType);
            if (result)
            {
                Destroy(item.gameObject);
                AfterItemPlaced();
            }
            return result;
        }
        else
        {
            itemOnTop = item;
            itemOnTop.transform.SetParent(transform);
            itemOnTop.transform.localPosition = surfacePos;
            AfterItemPlaced();
            return true;
        }
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
