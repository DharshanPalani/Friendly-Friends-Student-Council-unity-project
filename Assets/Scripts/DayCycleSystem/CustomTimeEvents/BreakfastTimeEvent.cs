using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakfastTimeEvent : MonoBehaviour, ITimeEvent, IInteractable
{
    public int EventHour => 9;

    public int EventMinute => 0;

    public bool breakFastAte = false;

    public void Interact()
    {
        breakFastAte = true;
        Debug.Log("Breakfast task finished");
    }

    public void OnTimeReached()
    {
        if(!breakFastAte) Debug.Log("You failed to finish the breakfast task"); 
            
    }

    // Start is called before the first frame update
    void Start()
    {
        DayCycle.Instance.RegisterEvent(this);
    }
}
