using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawns;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Player player;

    void Start()
    {
        Time.timeScale = 0.5f;
        var _player = Instantiate(player, new Vector3(0f, 0f, 0f), Quaternion.identity);
        _player.onMainMenu = true;
        for (int i = 0; i < spawns.Length; i++)
        {
            var _enemy = Instantiate(enemy, spawns[i].transform.position, Quaternion.identity);
            _enemy.GetComponentInChildren<Canvas>().enabled = false;
        }
    }
    public void OnStartPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void OnOptions()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExit()
    {
        Application.Quit();
    }
}
