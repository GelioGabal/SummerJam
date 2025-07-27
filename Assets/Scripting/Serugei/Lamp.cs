using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Lamp : MonoBehaviour
{
    Light2D light;
    SpriteRenderer spriter;
    void Start()
    {
        light = GetComponentInChildren<Light2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    public void Toggle(bool enabled)
    {
        light.enabled = enabled;
        spriter.color = (enabled) ? Color.yellow : Color.white;
    }
}
