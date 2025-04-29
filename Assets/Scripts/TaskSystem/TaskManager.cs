using System.Collections.Generic;
using UnityEngine;

namespace TaskSystem
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> taskBehaviours = new();

        private List<ITask> tasks = new();

        private void Start()
        {
            foreach (var behaviour in taskBehaviours)
            {
                if (behaviour is ITask task)
                    tasks.Add(task);
                else
                    Debug.LogWarning($"{behaviour.name} does not implement ITask.");
            }
        }

        private void Update()
        {
            var time = new GameTime(DayCycle.Instance.hour, DayCycle.Instance.minute);

            foreach (var task in tasks)
                task.CheckProgress(time);

            if (tasks.TrueForAll(t => t.IsCompleted))
                Debug.Log("All tasks complete!");
            else if (tasks.Exists(t => t.IsFailed))
                Debug.Log("Some tasks failed.");
        }
    }

}
