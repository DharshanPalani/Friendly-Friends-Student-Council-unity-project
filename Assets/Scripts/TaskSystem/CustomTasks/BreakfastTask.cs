using TaskSystem;
using UnityEngine;

public class BreakfastTask : MonoBehaviour, ITask, IInteractable
{
    private bool hasEaten = false;
    private bool failed = false;

    public bool IsCompleted => hasEaten;
    public bool IsFailed => failed && !hasEaten;

    public void Interact()
    {
        Eat();
    }

    public void CheckProgress(GameTime time)
    {
        if (!hasEaten && time.Hour >= 9 && !failed)
        {
            failed = true;
            Debug.Log("You missed breakfast.");
        }
    }

    private void Eat()
    {
        if (failed == false)
        {
            hasEaten = true;
            Debug.Log("Breakfast eaten on time!");
        }
    }
}