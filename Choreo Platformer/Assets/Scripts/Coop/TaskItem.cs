using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    [SerializeField] private TaskType taskType;

    public WorldSurface CurrentHolder
    {
        get
        {
            if (transform.parent != null)
            {
                WorldSurface parentSurface = transform.parent.GetComponent<WorldSurface>();
                if (parentSurface != null)
                { 
                    return parentSurface;
                }
            }
            return null;
        }
    }
}
