using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour, IInteractable
{
    private float lastTriggerTime; // 현재 트리거 발생 시간
    private float previousTriggerTime; // 이전 트리거 발생 시간
    private bool isTriggered = false; // 트리거 여부

    public float ElapsedTime // 경과 시간(초)을 리턴하는 프로퍼티
    {
        get
        {
            if (isTriggered)
            {
                return Time.time - lastTriggerTime;
            }
            return 0f;
        }
    }

    public float TriggerInterval // 두 트리거 간의 간격(초)을 리턴하는 프로퍼티
    {
        get
        {
            if (isTriggered)
            {
                return lastTriggerTime - previousTriggerTime;
            }
            return 0f;
        }
    }

    public void OnInteract(int questType)
    {
        UpdateTriggerTime();
        Debug.Log($"QuestType {questType} interaction triggered. Interval: {TriggerInterval} seconds");
    }

    public void OnInteract()
    {
        UpdateTriggerTime();
        Debug.Log($"Default interaction triggered. Interval: {TriggerInterval} seconds");
    }

    public void UpdateTriggerTime()
    {
        if (isTriggered)
        {
            // 이전 트리거 시간을 갱신
            previousTriggerTime = lastTriggerTime;
        }

        // 현재 트리거 시간을 갱신
        lastTriggerTime = Time.time;

        isTriggered = true;
    }

    public void ResetTimer()
    {
        lastTriggerTime = 0f;
        previousTriggerTime = 0f;
        isTriggered = false;
    }

    // public string GetElapsedTimeFormatted()
    public float GetElapsedTime()
    {
        // int elapsedSeconds = Mathf.FloorToInt(ElapsedTime);
        // int minutes = elapsedSeconds / 60;
        // int seconds = elapsedSeconds % 60;
        // return $"{minutes:D2}:{seconds:D2}";
        return ElapsedTime;
    }

    public float GetTriggerIntervalTime()
    {
        // int elapsedSeconds = Mathf.FloorToInt(ElapsedTime);
        // int minutes = elapsedSeconds / 60;
        // int seconds = elapsedSeconds % 60;
        // return $"{minutes:D2}:{seconds:D2}";
        return TriggerInterval;
    }
}
