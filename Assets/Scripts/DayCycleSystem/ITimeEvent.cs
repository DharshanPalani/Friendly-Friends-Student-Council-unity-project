using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeEvent
{
    public int EventHour {get; }
    public int EventMinute {get; }

    public void OnTimeReached();
}
