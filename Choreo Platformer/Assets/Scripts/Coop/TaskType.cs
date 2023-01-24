public enum TaskType
{
    ChangeDiaper,
    FeedBottle,
    Hold,
}

public enum TaskItemType
{
    DirtyBaby,
    HappyBaby,
}

public static class TaskResults
{
    public static TaskItemType TaskResult(TaskItemType input, TaskType task)
    {
        switch (input)
        {
            case TaskItemType.DirtyBaby:
                return TaskItemType.HappyBaby;
        }

        return input;
    }
}
