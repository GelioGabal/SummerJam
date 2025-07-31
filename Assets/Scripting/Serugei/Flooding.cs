using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Flooding : MonoBehaviour
{
    [SerializeField] List<Flooding> NeighbourFloodings;
    [SerializeField] List<GateWay> Gates;
    public static UnityEvent<string, float> OnChangeLevel = new();
    public float FloodingPercent { get; private set; } = 0;
    bool isPumping = false;
    int BreakBonus = 0;
    private void Start()
    {
        PumpController.OnTogglePump.AddListener(changePumping);
        foreach (GateWay gate in Gates)
            gate.OnInteract.AddListener(UpdateFlooding);
    }
    private void Update()
    {
        if (isPumping)
        {
            if (FloodingPercent > 0)
                setWaterLevel(FloodingPercent - Time.deltaTime * 0.05f);
            else changePumping(transform.parent.name, false);
        }
    }

    List<Flooding> AdjacentRooms(List<Flooding> result)
    {
        result.Add(this);
        foreach (Flooding room in NeighbourFloodings)
        {
            if (!result.Contains(room) && room.isAdjacent(this))
                result = room.AdjacentRooms(result);
        }
        return result;
    }
    bool isAdjacent(Flooding flooding) =>
        flooding.Gates.Any(gate => Gates.Contains(gate) && gate.isOpen);
    public void UpdateFlooding()
    {
        var rooms = AdjacentRooms(new());

        //var names = rooms.Select(room => room.transform.parent.name).ToArray();
        //Debug.Log($"Adjacent rooms {rooms.Count()} \n {string.Join("\n", names)}");

        float sumBonus = rooms.Sum(room => room.BreakBonus);
        float sumLevel = rooms.Sum(room => room.FloodingPercent);
        foreach (var room in rooms)
        {
            room.StartFlooding(false);
            room.setWaterLevel(sumLevel / rooms.Count());
            room.StartFlooding(true, sumBonus / rooms.Count());
            room.setPumping(room.isPumping && sumBonus <= 0);
        }
    }

    public void ChangeBreaked(int delta)
    {
        BreakBonus += delta;
        UpdateFlooding();
    }
    void setWaterLevel(float percent)
    {
        FloodingPercent = percent;
        OnChangeLevel.Invoke(transform.parent.name, FloodingPercent);
        transform.localScale = new(transform.localScale.x, Mathf.Lerp(0, 2.5f, percent), 1);
    }
    Coroutine coroutine;
    void StartFlooding(bool enabled, float percent = 0)
    {
        if (enabled && percent != 0) coroutine = StartCoroutine(flooding(percent));
        else if (coroutine != null) StopCoroutine(coroutine);
    }
    IEnumerator flooding(float percent)
    {
        while (true)
        {
            yield return new WaitForSeconds(5 - percent);
            setWaterLevel(Mathf.Clamp(FloodingPercent + 0.05f, 0f, 1f));
        }
    }
    void changePumping(string name, bool enabled)
    {
        if (transform.parent.name == name)
        {
            var rooms = AdjacentRooms(new());
            float sumBonus = rooms.Sum(room => room.BreakBonus);
            foreach (var room in rooms)
                room.setPumping(enabled && sumBonus <= 0 && FloodingPercent > 0f);
        }
    }
    void setPumping(bool enabled)
    {
        isPumping = enabled;
        ControlPanelScript.OnChangePumping.Invoke(transform.parent.name, enabled);
    }
}
