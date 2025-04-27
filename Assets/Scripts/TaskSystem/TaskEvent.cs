using System;
using UnityEngine;

public class TaskEvent
{
    public event Action onTaskFinish;
    public event Action onTaskFail;

    public void TaskFinished()
    {
        Debug.Log("TaskEvent: Task finished event invoked!");
        onTaskFinish?.Invoke();
    }

    public void TaskFailed()
    {
        Debug.Log("TaskEvent: Task failed event invoked!");
        onTaskFail?.Invoke();
    }
}
