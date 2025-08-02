using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuWindow, settingsWindow;
    
    [Header("Buttons")]
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    private bool _isPaused = false;
    private void Start()
    {
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().name != "Menu")
            InputManager.playerInput.UI.EscMenu.performed += toggleEscMenu;
    }
    public void LoadScene(int id)
    {
        SceneManager.LoadSceneAsync(id);
    }
    void toggleEscMenu(InputAction.CallbackContext ctx) =>
        Pause(!_isPaused);
    private void OnDisable()
    {
        if(InputManager.playerInput != null)
            InputManager.playerInput.UI.EscMenu.performed -= toggleEscMenu;
    }
    public void Pause(bool enabled)
    {
        _isPaused = enabled;
        Time.timeScale = enabled ? 0f : 1f;
        if(enabled) InputManager.playerInput.Player.Disable();
        else InputManager.playerInput.Player.Enable();
        settingsWindow.SetActive(false);
        menuWindow.SetActive(enabled);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void OpenLink(string link) =>
        Application.OpenURL(link);
}