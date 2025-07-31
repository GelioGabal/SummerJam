using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    static UnityEvent<bool> toggleAll = new();
    Light2D[] lights;
    SpriteRenderer spriter;
    void Start()
    {
        lights = GetComponentsInChildren<Light2D>();
        spriter = GetComponent<SpriteRenderer>();
        toggleAll.AddListener(Toggle);
    }
    public void ToggleAll(bool enabled) => toggleAll.Invoke(enabled);
    public void Toggle(bool enabled)
    {
        foreach(Light2D light in lights)
            light.enabled = enabled;
        spriter.color = (enabled) ? Color.yellow : Color.white;
    }
}
