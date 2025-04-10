using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCompletable : MonoBehaviour
{
    protected GameObject fader;

    protected virtual void Awake()
    {
        fader = GameObject.Find("FadeScreen");
    }

    public virtual IEnumerator Complete()
    {
        fader.GetComponent<Fader>().FadeImage();
        yield return null;
    }

    public void CompleteTask()
    {
        StartCoroutine(Complete());
    }
}
