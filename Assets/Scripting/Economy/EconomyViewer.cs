using TMPro;
using UnityEngine;

public class EconomyViewer : MonoBehaviour
{
    [SerializeField] TMP_Text[] texts   ;

    private void Update()
    {
        ViewStats();
    }
    public void ViewStats()
    {
        EconomyController economyController = GetComponent<EconomyController>();
        texts[0].text = economyController.ViewOxigen();
        texts[1].text = economyController.ViewSubHelth();
        texts[2].text = economyController.ViewMachineHelth();
        texts[3].text = economyController.ViewGeneratorHelth();
        texts[4].text = economyController.ViewHathHelth();
        texts[5].text = economyController.ViewControlRoomHelth();
        texts[6].text = economyController.ViewMiningHelth();
        texts[7].text = economyController.ViewOxigenRoomHelth();
        texts[8].text = economyController.ViewStorageHelth();
        texts[9].text = economyController.ViewRoom_8();
        texts[10].text = economyController.ViewRoom_9();
        texts[11].text = economyController.ViewRoom_10();
        texts[12].text = economyController.ViewRoom_11();
    }
}
