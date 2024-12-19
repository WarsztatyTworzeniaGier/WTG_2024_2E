using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private float respawnTime = 1f;

    private void Start()
    {
        player.onDeath += StartRestartLevel;
    }

    public void StartRestartLevel()
    {
        //Invoke(nameof(RestartLevel), respawnTime);
        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        player.KillPlayer();
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(respawnTime);
        Time.timeScale = 1f;
        player.RespawnPlayer(respawnTime);
    }
}
