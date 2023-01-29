using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : TaskItem
{
    [SerializeField] private float minChangeTime = 5f;
    [SerializeField] private float maxChangeTime = 45f;

    private float currentChangeDelay;
    private float currentChangeTarget;

    private void Start()
    {
        DoRandomStat();    
    }

    private void Update()
    {
        if (currentChangeTarget <= 0)
        {
            if(ItemType != TaskItemType.HappyBaby)
                return;

            currentChangeDelay = 0;
            currentChangeTarget = Random.Range(minChangeTime, maxChangeTime);
        }

        if (currentChangeDelay < currentChangeTarget)
        {
            currentChangeDelay += Time.deltaTime;
            if (currentChangeDelay >= currentChangeTarget)
            {
                DoRandomStat();
            }
        }
    }

    private void DoRandomStat()
    {
        itemType = RandomSat;
        currentChangeDelay = 0;
        currentChangeTarget = 0;
    }

    private TaskItemType RandomSat
    {
        get
        {
            List<TaskItemType> stats = new List<TaskItemType>();
            stats.Add(TaskItemType.DirtyBaby);
            stats.Add(TaskItemType.GrumpyBaby);
            stats.Add(TaskItemType.HungryBaby);
            return stats[Random.Range(0, stats.Count)];
        }
    }
}
