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
    public string ViewSubHelth()
    {
        string name = EconomyManager.GetItemAmount(states[0].name).ToString();
        return name;
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
    public string ViewOxigen()
    {
        string name = EconomyManager.GetItemAmount(states[1].name).ToString();
        return name;
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
    public string ViewMachineHelth()
    {
        string name = EconomyManager.GetItemAmount(states[2].name).ToString();
        return name;
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
    public string ViewGeneratorHelth()
    {
        string name = EconomyManager.GetItemAmount(states[3].name).ToString();
        return name;
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
    public string ViewHathHelth()
    {
        string name = EconomyManager.GetItemAmount(states[4].name).ToString();
        return name;
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
    public string ViewControlRoomHelth()
    {
        string name = EconomyManager.GetItemAmount(states[5].name).ToString();
        return name;
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
    public string ViewMiningHelth()
    {
        string name = EconomyManager.GetItemAmount(states[6].name).ToString();
        return name;
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
    public string ViewOxigenRoomHelth()
    {
        string name = EconomyManager.GetItemAmount(states[7].name).ToString();
        return name;
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
    public string ViewStorageHelth()
    {
        string name = EconomyManager.GetItemAmount(states[8].name).ToString();
        return name;
    }

    public void AddRoom_8(int amount)
    {

        EconomyManager.UpdateItemAmount(states[9].name, amount);
        Debug.Log(states[9].name + "|" + states[9].amount);
    }

    public void renoveRoom_8(int amount)
    {
        EconomyManager.UpdateItemAmount(states[9].name, -amount);
        Debug.Log(states[9].name + "|" + states[9].amount);
    }
    public string ViewRoom_8()
    {
        string name = EconomyManager.GetItemAmount(states[9].name).ToString();
        return name;
    }

    public void AddRoom_9(int amount)
    {

        EconomyManager.UpdateItemAmount(states[10].name, amount);
        Debug.Log(states[10].name + "|" + states[10].amount);
    }

    public void renoveRoom_9(int amount)
    {
        EconomyManager.UpdateItemAmount(states[10].name, -amount);
        Debug.Log(states[9].name + "|" + states[10].amount);
    }
    public string ViewRoom_9()
    {
        string name = EconomyManager.GetItemAmount(states[10].name).ToString();
        return name;
    }

    public void AddRoom_10(int amount)
    {

        EconomyManager.UpdateItemAmount(states[11].name, amount);
        Debug.Log(states[11].name + "|" + states[11].amount);
    }

    public void renoveRoom_10(int amount)
    {
        EconomyManager.UpdateItemAmount(states[11].name, -amount);
        Debug.Log(states[11].name + "|" + states[11].amount);
    }
    public string ViewRoom_10()
    {
        string name = EconomyManager.GetItemAmount(states[11].name).ToString();
        return name;
    }

    public void AddRoom_11(int amount)
    {

        EconomyManager.UpdateItemAmount(states[12].name, amount);
        Debug.Log(states[12].name + "|" + states[12].amount);
    }

    public void renoveRoom_11(int amount)
    {
        EconomyManager.UpdateItemAmount(states[12].name, -amount);
        Debug.Log(states[12].name + "|" + states[12].amount);
    }
    public string ViewRoom_11()
    {
        string name = EconomyManager.GetItemAmount(states[12].name).ToString();
        return name;
    }
    

    public void VieAll()
    {
        EconomyManager.PrintAllItems();
    }


}
