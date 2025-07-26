using System.Collections.Generic;
using UnityEngine;

public static class EconomyManager
{
    private static Dictionary<string, MainStorage> items = new Dictionary<string, MainStorage>();
    public static void UpdateItemAmount(string itemName, float amount)
    {
        if (items.TryGetValue(itemName, out MainStorage item))
        {
            item.ModifyAmount(amount);
        }
        else
        {
            Debug.LogError($"ресурс под названием {itemName} не найден");
        }
    }

    public static float GetItemAmount(string itemName)
    {
        if (items.TryGetValue(itemName, out MainStorage item))
        {
            return item.amount;
        }
        return 0;
    }
}
