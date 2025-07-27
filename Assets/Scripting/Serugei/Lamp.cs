using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    static UnityEvent<bool> toggleAll = new();
    Light2D light;
    SpriteRenderer spriter;
    void Start()
    {
        light = GetComponentInChildren<Light2D>();
        spriter = GetComponent<SpriteRenderer>();
        toggleAll.AddListener(Toggle);
    }
    public void ToggleAll(bool enabled) => toggleAll.Invoke(enabled);
    public void Toggle(bool enabled)
    {
        light.enabled = enabled;
        spriter.color = (enabled) ? Color.yellow : Color.white;
    }
}
