using UnityEngine;

public class MiniGamePanel : MonoBehaviour
{
    private bool _isOpened = false;

    public void TogglePanel()
    {
        _isOpened = !_isOpened;
        gameObject.SetActive(_isOpened);
    }

    public void ClosePanel()
    {
        _isOpened = false;
        gameObject.SetActive(false);
    }
}
