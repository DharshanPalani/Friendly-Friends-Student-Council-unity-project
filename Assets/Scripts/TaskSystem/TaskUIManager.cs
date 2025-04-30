using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

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
        private List<string> currentTaskname = new List<string>();    

        public void InitiateTaskNames(List<string> totalTaskNames) {
            currentTaskname = totalTaskNames;

            foreach (var taskName in currentTaskname) {
                Debug.Log(taskName);
            }

            ShowTaskInUI();
        }

        private void ShowTaskInUI() {
            foreach (var taskName in currentTaskname) {
                tasksList.text += $"{taskName}\n";
            }
        }
    }
}