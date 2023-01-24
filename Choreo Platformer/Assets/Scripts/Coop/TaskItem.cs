using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    [SerializeField] private TaskItemType itemType;
    public TaskItemType ItemType {  get { return itemType; } }

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

    public void TaskCompleted(TaskType taskType)
    {
        itemType = TaskResults.TaskResult(itemType, taskType);
    }
}
