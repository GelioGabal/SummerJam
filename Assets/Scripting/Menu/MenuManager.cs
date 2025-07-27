using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Menu Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    
    [Header("Buttons")]
    [SerializeField] private KeyCode pauseKey = KeyCode.Escape;

    private bool _isPaused;
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }

    private void Start()
    {
        ShowMainMenu();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(pauseKey)) return;
        
        if (_isPaused) ResumeGame();
        else ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        ShowMainMenuPanel(true);
        ShowSettingsPanel(false);
        Time.timeScale = 0f;
    }

    public void ShowSettings()
    {
        ShowMainMenuPanel(false);
        ShowSettingsPanel(true);
    }

    public void ResumeGame()
    {
        ShowMainMenuPanel(false);
        ShowSettingsPanel(false);
        Time.timeScale = 1f;
    }

    private void ShowMainMenuPanel(bool show)
    {
        mainMenuPanel.SetActive(show);
    }

    private void ShowSettingsPanel(bool show)
    {
        settingsPanel.SetActive(show);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}