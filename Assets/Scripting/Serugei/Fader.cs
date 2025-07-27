using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriter;
    [SerializeField] float fadeTime;
    Coroutine coroutine;
    public void Fade(bool fadeIn = true)
    {
        if(coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(fader(spriter,fadeTime,fadeIn));
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
}
