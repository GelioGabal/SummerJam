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
            Debug.LogWarning($"Предмет под названием {item.name} уже зарегистрирован");
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


    public static void PrintAllItems()
    {
        Debug.Log("=== Содержимое словаря items ===");

        if (items.Count == 0)
        {
            Debug.Log("Словарь пуст");
            return;
        }

        foreach (var pair in items)
        {
            Debug.Log($"Ключ: {pair.Key}, Значение: {pair.Value.amount}");
            // Если MainStorage имеет дополнительные поля, можно выводить и их:
            // Debug.Log($"Ключ: {pair.Key}, Значение: {pair.Value.ToString()}");
        }

        Debug.Log("=== Конец вывода ===");
    }
}
