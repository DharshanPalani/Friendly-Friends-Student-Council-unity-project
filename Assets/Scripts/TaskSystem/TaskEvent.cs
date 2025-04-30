using System.Collections.Generic;
using System;

public static class TaskEvent
{
    public static Action onTaskFinish;
    public static Action onTaskFail;

    public static Action<List<string>> taskUIAction;
}
