using System.Collections;
using System.Collections.Generic;
using TaskSystem;
using UnityEngine;

public class HomeWorkTask : MonoBehaviour, ITask, IInteractable
{
    public string taskName => this.name;
    private bool hasFinishedHomeWork = false;
    private bool failed = false;

    public bool IsCompleted => hasFinishedHomeWork;

    public bool IsFailed => failed && !hasFinishedHomeWork;

    private int homeworkReardPoint = 10;
    public int rewardPoint => homeworkReardPoint;

    public void CheckProgress(GameTime time)
    {
        if (!hasFinishedHomeWork && time.Hour >= 12 && !failed)
        {
            failed = true;
            Debug.Log("You didn't do homework on time.");
        }
    }

    public void Interact()
    {
        WriteHomeWork();
    }

    private void WriteHomeWork() {
        if(failed == false) {
            hasFinishedHomeWork = true;
            Debug.Log("Finished Homework!");
        }
    }
}
