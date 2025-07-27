using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    SpriteRenderer spriter;
    Image image;
    [SerializeField] float fadeTime;
    Coroutine coroutine;
    public void Fade(bool fadeIn = true)
    {
        if(coroutine != null) StopCoroutine(coroutine);
        if(TryGetComponent(out spriter))
            coroutine = StartCoroutine(fader(spriter,fadeTime,fadeIn));
        else if(TryGetComponent(out image))
            coroutine = StartCoroutine(fader(image, fadeTime, fadeIn));
    }
    IEnumerator fader(SpriteRenderer spriter, float fadeTime, bool fadeIn)
    {
        float t = 0;
        float startFade = spriter.color.a;
        float targetFade = (fadeIn) ? 0 : 1;
        Color c = spriter.color;
        while(t< fadeTime)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(startFade, targetFade, Mathf.InverseLerp(0, fadeTime, t));
            spriter.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator fader(Image image, float fadeTime, bool fadeIn)
    {
        float t = 0;
        float startFade = image.color.a;
        float targetFade = (fadeIn) ? 0 : 1;
        Color c = image.color;
        while(t< fadeTime)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(startFade, targetFade, Mathf.InverseLerp(0, fadeTime, t));
            image.color = c;
            yield return new WaitForEndOfFrame();
        }
    }
}
