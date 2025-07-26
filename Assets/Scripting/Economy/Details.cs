using UnityEngine;
using UnityEngine.Events;

public class Details : MonoBehaviour
{
    private static int _detailsCount = 0;
    public static event System.Action<int> OnDetailsChanged; //

    public static int GetDetailsCount()
    {
        return _detailsCount;
    }

    public static void SetDetailsCount(int newValue)
    {
        int oldValue = _detailsCount;

        if (newValue < 0)
        {
            Debug.LogWarning("Нельзя установить значение меньше 0!");
            _detailsCount = 0;
        }
        else if (newValue > 10)
        {
            Debug.LogWarning("Нельзя установить значение больше 10");
            _detailsCount = 10;
        }
        else
        {
            _detailsCount = newValue;
        }

 
        if (oldValue != _detailsCount)
        {
            OnDetailsChanged?.Invoke(_detailsCount);
        }
    }


}
