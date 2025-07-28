using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ControlPanelScript : InteractiveObject
{
    [SerializeField] Color disabledColor, enabledColor;
    [SerializeField] List<Image> floodIndicators = new();
    public static UnityEvent<string, bool> OnChangePumping = new();
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
        Flooding.OnChangeLevel.AddListener(updateFlooding);
        OnChangePumping.AddListener(updateFeedback);
    }
    void updateFlooding(string name, float percent)
    {
        var ind = floodIndicators.First(ind => ind.gameObject.name == name);
        if (ind != default) ind.fillAmount = percent;
    }
    void updateFeedback(string name, bool enabled)
    {
        source.enabled = enabled;
        var ind = floodIndicators.First(ind => ind.gameObject.name == name);
        if (ind != default) ind.color = (enabled) ? enabledColor : disabledColor;
    }
}
