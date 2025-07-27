using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flooding : MonoBehaviour
{
    [SerializeField] List<Flooding> NeighbourFloodings;
    [SerializeField] List<GateWay> Gates;
    float FloodingPercent = 0;  ////// !!!!!STEPA!!!!! 
    int BreakBonus = 0;
    private void Start()
    {
        foreach (InteractiveObject gate in Gates)
            gate.OnInteract.AddListener(UpdateFlooding);
    }
    List<Flooding> AdjacentRooms(List<Flooding> result)
    {
        result.Add(this);
        foreach(Flooding room in NeighbourFloodings)
            if(!result.Contains(room))
                foreach(var gate in room.Gates)
                    if(Gates.Contains(gate)&&gate.isOpen)
                        return room.AdjacentRooms(result);
        return result;
    }
    public void UpdateFlooding()
    {
        var rooms = AdjacentRooms(new());
        float sumBonus = rooms.Sum(room => room.BreakBonus);
        float sumLevel = rooms.Sum(room => room.FloodingPercent);
        foreach (var room in rooms)
        {
            room.StartFlooding(false);
            room.setWaterLevel(sumLevel / rooms.Count());
            room.StartFlooding(true, sumBonus / rooms.Count());
        }
        Debug.Log($"rooms {rooms.Count()} bonus {sumBonus / rooms.Count()}");
    }

    public void ChangeBreaked(int delta)
    {
        BreakBonus += delta;
        UpdateFlooding();
    }
    void setWaterLevel(float percent)
    {
        FloodingPercent = percent;
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
}
