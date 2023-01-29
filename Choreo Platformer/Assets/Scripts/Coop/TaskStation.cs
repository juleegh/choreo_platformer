using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskStation : WorldSurface, TagHolder
{
    [SerializeField] private TaskType taskType;
    [SerializeField] private Image progressBar;
    [SerializeField] private GameObject progressBarContainer;

    public TaskType TaskType { get { return taskType; } }
    float percentage = 0;

    private void Awake()
    {
        UpdateProgressBar();
    }

    protected override void AfterItemPlaced()
    {
        base.AfterItemPlaced();
        percentage = 0;
        UpdateProgressBar();
    }

    protected override void AfterItemRemoved()
    {
        base.AfterItemRemoved();
        percentage = 0;
        UpdateProgressBar();
    }

    public bool PerformTask(float percentageIncrease)
    {
        TaskItemType taskItem = itemOnTop == null ? TaskItemType.None : itemOnTop.ItemType;
        TaskItemType taskItem2 = itemOnTop == null ? TaskItemType.None : itemOnTop.SecondItemType;

        if (!TaskResults.ValidTask(taskItem, taskType, taskItem2))
        {
            return false;
        }

        percentage += percentageIncrease;
        UpdateProgressBar();

        if (percentage >= 1)
        {
            TaskItemType result = TaskResults.TaskResult(taskItem, taskType, taskItem2);
            if (result != TaskItemType.None)
            {
                if (itemOnTop != null)
                {
                    itemOnTop.TaskCompleted(taskType);
                }
                else
                {
                    TryToPlace(ItemDispenser.Instance.GetObject(result));
                }
            }

            percentage = 0f;
            return true;
        }


        return false;
    }

    private void UpdateProgressBar()
    {
        progressBarContainer.SetActive(percentage > 0 && percentage < 1);
        progressBar.fillAmount = percentage;
    }

    public string GetTagContent()
    {
        return taskType.ToString();
    }
}
