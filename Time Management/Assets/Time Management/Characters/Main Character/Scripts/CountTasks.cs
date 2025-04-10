using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class CountTasks : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private int _score;

    private void FixedUpdate()
    {
        CheckTasks();
    }

    private void CheckTasks()
    {
        if (_score == 4)
        {
            _winScreen.SetActive(true);
        }
    }
    public void AddScore(int score)
    {
        _score += score;
    }
}
