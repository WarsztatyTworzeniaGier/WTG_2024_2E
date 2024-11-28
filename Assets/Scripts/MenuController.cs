using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "Main";

    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Window mainScreen, settingsScreen, creditsScreen;

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ToggleSettings(bool toggle)
    {
        mainScreen.Toggle(!toggle);
        settingsScreen.Toggle(toggle);
    }

    public void ToggleCredits(bool toggle)
    {
        mainScreen.Toggle(!toggle);
        creditsScreen.Toggle(toggle);
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    private void Awake()
    {
        startButton.onClick.AddListener(StartGame);
    }
}
