using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Economy/Item")]
public class MainStorage : ScriptableObject
{
public string itemName; 
public Sprite icon; 
public float amount; 


public void ModifyAmount(float value)
{
    amount += value;
    amount = Mathf.Max(0, amount); 
}
}
