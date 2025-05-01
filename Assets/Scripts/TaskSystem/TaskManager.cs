using System.Collections.Generic;
using UnityEngine;

namespace TaskSystem
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> taskBehaviours = new();


        private List<ITask> tasks = new();

        private List<ITask> finishedTask = new();
        private List<ITask> failedTask = new();

        private bool allTaskCompleted = false;
        private bool taskFailed = false;

        private void Start()
        {
            foreach (var behaviour in taskBehaviours)
            {
                if (behaviour is ITask task)
                {
                    tasks.Add(task);
                }
                else
                {
                    Debug.LogWarning($"{behaviour.name} does not implement ITask.");
                }
            }

            TaskEvent.taskUIAction?.Invoke(tasks);
        }

        private void Update()
        {
            var time = new GameTime(DayCycle.Instance.hour, DayCycle.Instance.minute);

            foreach (var task in tasks)
            {
                task.CheckProgress(time);

                if(task.IsCompleted && !finishedTask.Contains(task))
                {
                    finishedTask.Add(task);
                    Debug.Log(task.taskName + " is completed and verified from task manager");
                }

                if(task.IsFailed && !failedTask.Contains(task))
                {
                    failedTask.Add(task);
                    Debug.Log(task.taskName + " is failed and verified from task manager");
                }
            }

            if (!allTaskCompleted && tasks.TrueForAll(t => t.IsCompleted)) {
                Debug.Log("All tasks complete!");
                allTaskCompleted = true;
            }
            else if (!taskFailed && tasks.Exists(t => t.IsFailed)) {
                Debug.Log("Some tasks failed.");
                taskFailed = true;
            }
        }
    }

}
