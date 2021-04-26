using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public static Fader instance;

    private void Awake()
    {
        instance = this;
    }

    public Image imageFader;
    float fadeOutTime;
    System.Action fadeOutCallback;

    public void FadeOut(float time, System.Action callback = null)
    {
        this.fadeOutTime = time;
        this.fadeOutCallback = callback;
        StartCoroutine("ieFadeOut");
    }

    IEnumerator ieFadeOut()
    {
        float add = Mathf.Min(Time.deltaTime, 1 / 144f);
        Color c = imageFader.color;
        for (float a = 0; a < fadeOutTime; a+= add)
        {
            c.a = a / fadeOutTime;
            imageFader.color = c;
            yield return new WaitForSeconds(add);
        }
        c.a = 1;
        imageFader.color = c;
        if (fadeOutCallback != null)
        {
            fadeOutCallback();
        }
    }

    float fadeinTime;
    System.Action fadeinCallback;

    public void FadeIn(float time, System.Action callback = null)
    {
        this.fadeinTime = time;
        this.fadeinCallback = callback;
        StartCoroutine("ieFadeIn");
    }

    IEnumerator ieFadeIn()
    {
        float add = Mathf.Min(Time.deltaTime, 1 / 144f);
        Color c = imageFader.color;
        for (float a = 0; a < fadeinTime; a+= add)
        {
            c.a = 1 - (a / fadeinTime);
            imageFader.color = c;
            yield return new WaitForSeconds(add);
        }
        c.a = 0;
        imageFader.color = c;
        if (fadeinCallback != null)
        {
            fadeinCallback();
        }
    }
}
