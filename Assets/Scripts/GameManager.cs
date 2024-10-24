using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    private void Start()
    {
        player.onDeath += RestartGame;
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Main");
    }
}
