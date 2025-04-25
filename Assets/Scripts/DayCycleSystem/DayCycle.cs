using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public static DayCycle Instance { get; private set; }

    [Header("Time Settings")]
    public float secondsPerGameMinute = 1f;

    [Header("Current Game Time")]
    public int hour = 0;
    public int minute = 0;

    private float _timer = 0f;

    private readonly List<ITimeEvent> _timeEvents = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= secondsPerGameMinute)
        {
            _timer = 0f;
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
            CheckForEvents();
        }
    }

    private void CheckForEvents()
    {
        foreach (var timeEvent in _timeEvents)
        {
            if (timeEvent.EventHour == hour && timeEvent.EventMinute == minute)
            {
                timeEvent.OnTimeReached();
            }
        }
    }

    public void RegisterEvent(ITimeEvent timeEvent)
    {
        _timeEvents.Add(timeEvent);
    }
}
