using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    public TMP_Text timeCounter;
    private TimeSpan timePlaying;
    private bool timerGoing;
    private string timePlayingStr;

    private float elapsedTime;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        if(timeCounter == null)
        {
            Debug.Log("Timer counter is null");
        }
        timeCounter.text = "Time : 00:00:00";
    }

    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;
        Debug.Log("Timer has started");
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }
    private IEnumerator UpdateTimer()
    {
        while(timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            timePlayingStr = "Time: " + timePlaying.ToString("mm':'ss'.'fff");
            timeCounter.text = timePlayingStr;

            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
