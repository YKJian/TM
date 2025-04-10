using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Printer : FinalParent
{
    private AudioSource _audio;

    protected override void Awake()
    {
        player = GameObject.Find("Player");
        _audio = GetComponent<AudioSource>();
    }

    protected override void CheckFinalKid()
    {
        GameObject kid = GetComponent<ObjectParent>()._kidObject;

        if (kid != null)
        {
            if (kid.GetComponent<Object>()._objectParent != null)
            {
                _audio.Play();
                Destroy(kid);
                player.GetComponent<CountTasks>().AddScore(1);
                kid.GetComponent<Object>()._objectParent = null;
            }
        }
    }
}
