using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : FastCompletable
{
    public override IEnumerator Complete()
    {
        fader.GetComponent<Fader>().FadeImage();
        GetComponent<BoxCollider>().isTrigger = false;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
