using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    private RawImage _fadingImage;

    private void Awake()
    {
        _fadingImage = GetComponent<RawImage>();
    }

    public void FadeImage()
    {
        StartCoroutine(GetFaded());
    }

    public IEnumerator GetFaded()
    {
        // transparent to opaque
        for (float i = 0; i <= 1; i += Time.fixedDeltaTime)
        {
            _fadingImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(1f);

        // vice versa
        for (float i = 1; i >= 0; i -= Time.fixedDeltaTime)
        {
            _fadingImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
