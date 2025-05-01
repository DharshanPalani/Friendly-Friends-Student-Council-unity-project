using System.Collections.Generic;
using System;
using TaskSystem;

public static class TaskEvent
{
    public static Action onTaskFinish;
    public static Action onTaskFail;

    public static Action<List<ITask>> taskUIAction;
}
