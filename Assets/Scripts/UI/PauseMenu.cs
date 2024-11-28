using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Window pauseScreen;

    private bool isPaused;

    public void TogglePause(bool pause)
    {
        isPaused = pause;

        Time.timeScale = pause ? 0f : 1.0f;
        pauseScreen.Toggle(pause);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            TogglePause(!isPaused);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadSceneAsync("Menu");
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync("Main");
        }
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }
}
