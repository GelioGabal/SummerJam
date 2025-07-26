using UnityEngine;

public class Details : MonoBehaviour
{
    private static int _detailsCount = 0;

    public  int GetDetailsCount()
    {
        return _detailsCount;
    }


    public  void SetDetailsCount(int newValue)
    {
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
    }
}
