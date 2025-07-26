using System;
using UnityEngine;
using UnityEngine.InputSystem;

    public class interaction : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject[] interactionMenus;

    private GameObject currentActiveMenu; 
    private GameObject playerInTrigger;


    private void Awake()
        {
            // InputManager.input.Player.Interact.performed += context => interact();
        }


    private void OnTriggerEnter(Collider other)
    {
    
        foreach (var menu in interactionMenus)
        {
            if (other.gameObject == menu.GetComponent<InteractioTriger>().triggerObject)
            {
                playerInTrigger = other.gameObject;
                break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (playerInTrigger == other.gameObject)
        {
            playerInTrigger = null;
            HideAllMenus();
        }
    }

    private void interact()
    {
        if (playerInTrigger == null) return;


        foreach (var menu in interactionMenus)
        {
            var trigger = menu.GetComponent<InteractioTriger>();
            if (trigger != null && trigger.triggerObject == playerInTrigger)
            {
                ToggleMenu(menu);
                return;
            }
        }
    }

    private void ToggleMenu(GameObject menu)
    {
        // ���� ���� ��� ������� - �������� ���
        if (currentActiveMenu == menu)
        {
            menu.SetActive(false);
            currentActiveMenu = null;
            return;
        }

        // �������� ��� ������ ����
        HideAllMenus();

        // ���������� ������ ����
        menu.SetActive(true);
        currentActiveMenu = menu;
    }

    private void HideAllMenus()
    {
        foreach (var menu in interactionMenus)
        {
            if (menu != null)
                menu.SetActive(false);
        }
        currentActiveMenu = null;
    }
}
