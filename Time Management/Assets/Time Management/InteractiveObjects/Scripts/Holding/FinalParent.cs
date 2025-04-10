using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalParent : MonoBehaviour
{
    protected GameObject player;

    protected virtual void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        CheckFinalKid();
    }

    protected virtual void CheckFinalKid()
    {
        GameObject kid = GetComponent<ObjectParent>()._kidObject;

        if (kid != null)
        {
            if (kid.GetComponent<Object>()._objectParent != null)
            {
                player.GetComponent<CountTasks>().AddScore(1);
                kid.GetComponent<Object>()._objectParent = null;
            }
        }
    }
}
