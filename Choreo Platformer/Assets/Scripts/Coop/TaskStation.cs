using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskStation : WorldSurface
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

        if (!TaskResults.ValidTask(taskItem, taskType))
        {
            return false;
        }

        percentage += percentageIncrease;
        UpdateProgressBar();

        if (percentage >= 1)
        {
            if (itemOnTop != null && TaskResults.TaskResult(itemOnTop.ItemType, taskType) != itemOnTop.ItemType)
            {
                itemOnTop.TaskCompleted(taskType);
            }
            return true;
        }


        return false;
    }

    private void UpdateProgressBar()
    {
        progressBarContainer.SetActive(percentage > 0 && percentage < 1);
        progressBar.fillAmount = percentage;
    }
}
