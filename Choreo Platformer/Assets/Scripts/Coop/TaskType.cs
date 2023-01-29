public enum TaskType
{
    DiaperStation,
    HighChair,
    PlayStation,
    TV,
    DiaperStorage,
    FoodDispenser,
    WorkComputer,
    Cradle,
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
    public static bool ValidTask(TaskItemType input, TaskType task, TaskItemType input2)
    {
        switch (task)
        {
            case TaskType.DiaperStation:
                return input == TaskItemType.DirtyBaby && input2 == TaskItemType.Diaper;
            case TaskType.HighChair:
                return input == TaskItemType.HungryBaby && input2 == TaskItemType.BabyFood;
            case TaskType.PlayStation:
                return input == TaskItemType.GrumpyBaby;
            case TaskType.WorkComputer:
            case TaskType.TV:
                return input == TaskItemType.None;
            case TaskType.FoodDispenser:
            case TaskType.DiaperStorage:
                return input == TaskItemType.Money;
        }

        return false;
    }
    
    public static TaskItemType TaskResult(TaskItemType input, TaskType task, TaskItemType input2)
    {
        switch (task)
        {
            case TaskType.DiaperStation:
            case TaskType.HighChair:
            case TaskType.PlayStation:
                    return TaskItemType.HappyBaby;
            case TaskType.WorkComputer:
                    return TaskItemType.Money;
            case TaskType.FoodDispenser:
                    return TaskItemType.BabyFood;
            case TaskType.DiaperStorage:
                    return TaskItemType.Diaper;
        }

        return input;
    }
    
    public static float TaskConsumption(TaskType task)
    {
        switch (task)
        {
            case TaskType.DiaperStation:
                return -0.2f;
            case TaskType.HighChair:
                return -0.25f;
            case TaskType.TV:
                return 0.05f;
            case TaskType.PlayStation:
                return 0.10f;
            case TaskType.WorkComputer:
                return -0.10f;
            case TaskType.FoodDispenser:
            case TaskType.DiaperStorage:
                return -0.05f;
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
