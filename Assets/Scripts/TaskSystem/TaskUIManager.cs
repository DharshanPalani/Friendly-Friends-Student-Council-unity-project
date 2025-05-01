using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TaskSystem
{
    public class TaskUIManager : MonoBehaviour
    {

        private void OnEnable()
        {
            TaskEvent.taskUIAction += InitiateTaskNames;            
        }

        private void OnDisable()
        {
            TaskEvent.taskUIAction -= InitiateTaskNames;
        }

        public TextMeshProUGUI tasksList;
        private List<ITask> currentTaskname = new List<ITask>();    

        public void InitiateTaskNames(List<ITask> totalTaskNames) {
            currentTaskname = totalTaskNames;

            ShowTaskInUI();
        }

        private void ShowTaskInUI() {
            foreach (var task in currentTaskname) {
                tasksList.text += $"{task.taskName}\n";
            }
        }
    }
}