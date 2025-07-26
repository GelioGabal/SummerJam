using UnityEngine;

public class EconomyController : MonoBehaviour
{
    [SerializeField] MainStorage[] states;

    private void Start()
    {
        for (int i=0; i<states.Length;i++)
        {
            EconomyManager.RegisterItem(states[i]);
        }
    }
    public void AddSubHelth( int amount)
    {

        EconomyManager.UpdateItemAmount(states[0].name, amount);
        Debug.Log(states[0].name+"|"+ states[0].amount);
    }

    public void renoveSubHelth( int amount)
    {
        EconomyManager.UpdateItemAmount(states[0].name, -amount);
        Debug.Log(states[0].name + "|" + states[0].amount);
    }
}
