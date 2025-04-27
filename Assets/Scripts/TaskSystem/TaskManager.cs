using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public int tasksCount;

    private int taskCompleted;

    public bool completedTasks;

    private TaskEvent taskEvent = new TaskEvent();

    void OnEnable()
    {
        taskEvent.onTaskFail += taskFailed;
    }

    void OnDisable()
    {
        taskEvent.onTaskFail -= taskFailed;
    }

    private void Update()
    {
        if(tasksCount == taskCompleted && !completedTasks) {
            completedTasks = true;
            Debug.Log("Task finished");
        }
    }

    public void updateTask() {
        taskCompleted += 1;
    }


    private void taskFailed() {
        Debug.Log("Task failed");
    }


}
