public enum TaskType
{
    DiaperStation,
    HighChair,
    PlayStation,
    TV,
    DiaperStorage,
    FoodDispenser,
    WorkComputer,
}

public enum TaskItemType
{
    None,
    DirtyBaby,
    GrumpyBaby,
    HungryBaby,
    HappyBaby,
    Money,
    Diaper,
    BabyFood,
}

public static class TaskResults
{
    public static bool ValidTask(TaskItemType input, TaskType task)
    {
        switch (input)
        {
            case TaskItemType.None:
                return task == TaskType.TV;
            case TaskItemType.DirtyBaby:
                return task == TaskType.DiaperStation;
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
            case TaskType.DiaperStation:
                return -0.15f;
            case TaskType.TV:
                return 0.05f;
        }

        return 0f;
    }

    public static bool CanPileUp(TaskItemType input1, TaskItemType input2)
    {
        bool result = false;
        switch (input1)
        {
            case TaskItemType.DirtyBaby:
                result = input2 == TaskItemType.Diaper;
                break;
            case TaskItemType.HungryBaby:
                result = input2 == TaskItemType.BabyFood;
                break;
        }

        return result;
    }
}
