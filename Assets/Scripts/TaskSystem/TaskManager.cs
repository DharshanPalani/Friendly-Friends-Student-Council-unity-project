using System.Collections.Generic;
using UnityEngine;

namespace TaskSystem
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> taskBehaviours = new();

        private List<string> taskNamesToSend = new List<string>();   

        private List<ITask> tasks = new();

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

            foreach (var nameOfTask in tasks)
            {
                taskNamesToSend.Add(nameOfTask.taskName);
            }

            TaskEvent.taskUIAction?.Invoke(taskNamesToSend);
        }

        private void Update()
        {
            var time = new GameTime(DayCycle.Instance.hour, DayCycle.Instance.minute);

            foreach (var task in tasks)
                task.CheckProgress(time);

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
