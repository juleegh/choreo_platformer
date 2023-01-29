public enum TaskType
{
    ChangeDiaper,
    FeedBottle,
    Hold,
    WatchTV,
    BuyDiapers,
    PrepareBottles,
}

public enum TaskItemType
{
    None,
    DirtyBaby,
    GrumpyBaby,
    HungryBaby,
    HappyBaby,
    Money,
    CleanDiaper,
    MilkBottle,
}

public static class TaskResults
{
    public static bool ValidTask(TaskItemType input, TaskType task)
    {
        switch (input)
        {
            case TaskItemType.None:
                return task == TaskType.WatchTV;
            case TaskItemType.DirtyBaby:
                return task == TaskType.ChangeDiaper;
        }

        return false;
    }
    
    public static TaskItemType TaskResult(TaskItemType input, TaskType task)
    {
        switch (input)
        {
            case TaskItemType.DirtyBaby:
                return TaskItemType.HappyBaby;
        }

        return input;
    }
    
    public static float TaskConsumption(TaskType task)
    {
        switch (task)
        {
            case TaskType.ChangeDiaper:
                return -0.15f;
            case TaskType.WatchTV:
                return 0.05f;
        }

        return 0f;
    }
}
