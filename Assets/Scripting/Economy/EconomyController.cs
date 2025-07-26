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


    public void AddOxigen(int amount)
    {

        EconomyManager.UpdateItemAmount(states[1].name, amount);
        Debug.Log(states[0].name + "|" + states[1].amount);
    }

    public void renoveOxigen(int amount)
    {
        EconomyManager.UpdateItemAmount(states[1].name, -amount);
        Debug.Log(states[0].name + "|" + states[1].amount);
    }

    public void AddMachineHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[2].name, amount);
        Debug.Log(states[0].name + "|" + states[2].amount);
    }

    public void renoveMachineHelth(int amount)
    {
        EconomyManager.UpdateItemAmount(states[2].name, -amount);
        Debug.Log(states[0].name + "|" + states[2].amount);
    }

    public void AddGeneratorHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[3].name, amount);
        Debug.Log(states[0].name + "|" + states[3].amount);
    }

    public void renoveGeneratorHelthh(int amount)
    {
        EconomyManager.UpdateItemAmount(states[3].name, -amount);
        Debug.Log(states[0].name + "|" + states[3].amount);
    }

    public void AddHathHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[4].name, amount);
        Debug.Log(states[0].name + "|" + states[4].amount);
    }

    public void renoveHathHelth(int amount)
    {
        EconomyManager.UpdateItemAmount(states[4].name, -amount);
        Debug.Log(states[0].name + "|" + states[4].amount);
    }

    public void AddControlRoomHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[5].name, amount);
        Debug.Log(states[0].name + "|" + states[5].amount);
    }

    public void renoveControlRoomHelth(int amount)
    {
        EconomyManager.UpdateItemAmount(states[5].name, -amount);
        Debug.Log(states[0].name + "|" + states[5].amount);
    }

    public void AddMiningHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[6].name, amount);
        Debug.Log(states[0].name + "|" + states[6].amount);
    }

    public void renoveMiningHelth(int amount)
    {
        EconomyManager.UpdateItemAmount(states[6].name, -amount);
        Debug.Log(states[0].name + "|" + states[6].amount);
    }

    public void AddOxigenRoomHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[7].name, amount);
        Debug.Log(states[0].name + "|" + states[7].amount);
    }

    public void renoveOxigenRoomHelth(int amount)
    {
        EconomyManager.UpdateItemAmount(states[7].name, -amount);
        Debug.Log(states[0].name + "|" + states[7].amount);
    }

    public void AddStorageHelth(int amount)
    {

        EconomyManager.UpdateItemAmount(states[8].name, amount);
        Debug.Log(states[0].name + "|" + states[8].amount);
    }

    public void renoveStorageHelth(int amount)
    {
        EconomyManager.UpdateItemAmount(states[8].name, -amount);
        Debug.Log(states[0].name + "|" + states[8].amount);
    }


}
