using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    [Header("Time Settings")]
    public float secondsPerGameMinute = 1f;

    [Header("Current Game Time")]
    public int hour = 0;
    public int minute = 0;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= secondsPerGameMinute)
        {
            timer = 0f;
            minute++;

            if (minute >= 60)
            {
                minute = 0;
                hour++;

                if (hour >= 24)
                {
                    hour = 0;
                }
            }

            Debug.Log($"Game Time: {hour:D2}:{minute:D2}");
        }
    }
}
