using UnityEngine;

public class EconomyController : MonoBehaviour
{

    public void AddCurrency(MainStorage res, int amount)
    {
        EconomyManager.UpdateItemAmount(res.name, amount);
    }

    public void renoveCurrency(MainStorage res, int amount)
    {
        EconomyManager.UpdateItemAmount(res.name, -amount);
    }
}
