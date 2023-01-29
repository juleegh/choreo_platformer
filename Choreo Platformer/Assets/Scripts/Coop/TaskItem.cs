using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskItem : MonoBehaviour, TagHolder
{
    [SerializeField] protected TaskItemType itemType;
    public TaskItemType ItemType {  get { return itemType; } }

    private TaskItemType secondItemType;

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
        secondItemType = TaskItemType.None;
    }

    public bool TryToPileUp(TaskItemType newItemType)
    {
        if (secondItemType != TaskItemType.None)
            return false;

        bool result = TaskResults.CanPileUp(itemType, newItemType);
        if (result)
        {
            secondItemType = newItemType;
        }

        return result;
    }

    public string GetTagContent()
    {
        string content = itemType.ToString();
        if (secondItemType != TaskItemType.None)
        { 
            content += ", " + secondItemType.ToString();
        }
        return content;   
    }
}
