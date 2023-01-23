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
        GetComponent<Collider>().enabled = false;
    }

    public TaskItem Empty()
    {
        TaskItem item = itemOnTop;
        itemOnTop.transform.SetParent(null);
        itemOnTop = null;
        GetComponent<Collider>().enabled = true;
        return item;
    }
}
