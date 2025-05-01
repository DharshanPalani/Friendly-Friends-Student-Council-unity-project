using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TaskSystem
{
    public class TaskUIManager : MonoBehaviour
    {
        public TextMeshProUGUI tasksList;

        private List<ITask> currentTask = new List<ITask>();

        private void OnEnable()
        {
            TaskEvent.taskUIAction += InitiateTaskNames;
            TaskEvent.taskVerify += UpdateTaskNameStatus;
        }

        private void OnDisable()
        {
            TaskEvent.taskUIAction -= InitiateTaskNames;
            TaskEvent.taskVerify -= UpdateTaskNameStatus;
        }

        public void InitiateTaskNames(List<ITask> totalTaskNames)
        {
            currentTask = totalTaskNames;
            ShowTaskInUI();
        }

        public void UpdateTaskNameStatus(ITask task)
        {
            if (task.IsCompleted)
            {
                RemoveTaskFromUI(task);
            }
        }

        private void ShowTaskInUI()
        {
            tasksList.text = string.Empty;
            foreach (var task in currentTask)
            {
                tasksList.text += $"{task.taskName}\n";
            }
        }

        private void RemoveTaskFromUI(ITask task)
        {
            string[] lines = tasksList.text.Split('\n');
            tasksList.text = "";

            foreach (string line in lines)
            {
                if (!line.Equals(task.taskName))
                {
                    tasksList.text += $"{line}\n";
                }
            }
        }
    }
}
