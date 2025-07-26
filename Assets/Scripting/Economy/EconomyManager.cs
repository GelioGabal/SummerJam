using System.Collections.Generic;
using UnityEngine;

public class EconomyManager:MonoBehaviour
{
    private static Dictionary<string, MainStorage> items = new Dictionary<string, MainStorage>();


    public static void RegisterItem(MainStorage item)
    {
        if (!items.ContainsKey(item.name))
        {
            items.Add(item.name, item);
        }
        else
        {
            Debug.LogWarning($"������� ��� ��������� {item.name} ��� ���������������");
        }
    }
    public static void UpdateItemAmount(string itemName, float amount)
    {
        if (items.TryGetValue(itemName, out MainStorage item))
        {
            item.ModifyAmount(amount);
        }
        else
        {
            Debug.LogError($"������ ��� ��������� {itemName} �� ������");
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
