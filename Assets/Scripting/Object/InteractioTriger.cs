using UnityEngine;

public class InteractioTriger : MonoBehaviour
{
    [Tooltip("Объект, который будет активировать это меню")]
    public GameObject triggerObject;

    [Tooltip("Ссылка на соответствующее меню взаимодействия")]
    public GameObject interactionMenu;
}
