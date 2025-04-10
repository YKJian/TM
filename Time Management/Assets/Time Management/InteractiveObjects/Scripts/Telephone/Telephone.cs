using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telephone : FastCompletable
{
    private AudioSource _audio;

    protected override void Awake()
    {
        fader = GameObject.Find("FadeScreen");
        _audio = GetComponent<AudioSource>();
    }

    public override IEnumerator Complete()
    {
        fader.GetComponent<Fader>().FadeImage();
        yield return new WaitForSeconds(2f);
        _audio.Play();
    }
}
