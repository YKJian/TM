using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private TimeSpan timeStart = new TimeSpan(0, 2, 0);
    [SerializeField] private Text _timerText;
    [SerializeField] private GameObject _defeatScreen;

    private void FixedUpdate()
    {
        CountTime();
        CountDefeat();
    }

    private void CountTime()
    {
        double t = Time.deltaTime;
        string deltaTimeInString = "00:00:0" + t.ToString().Replace(",", ".").Substring(0, 9);
        timeStart -= TimeSpan.Parse(deltaTimeInString);

        _timerText.text = timeStart.ToString().Substring(3, 5);
    }

    private void CountDefeat()
    {
        if (timeStart <= TimeSpan.Zero)
        {
            _defeatScreen.SetActive(true);
        }
    }
}
