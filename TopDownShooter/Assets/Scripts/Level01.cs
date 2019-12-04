using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Level01 : MonoBehaviour
{
    private Player player;

    [SerializeField]
    private Transform[] enemySpawns;

    [SerializeField]
    private Enemy enemy;

    [SerializeField]
    private Light2D flashlight;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;

    private float score = 0;
    void Start()
    {
        Time.timeScale = 1f;
        player = Player.instance;
        player.onMainMenu = false;
        for (int i = 0; i < enemySpawns.Length; i++)
        {
            var _enemy = Instantiate(enemy, enemySpawns[i].position, Quaternion.identity);
            _enemy.KillEnemy += Enemy_KillEnemy;
        }
    }

    private void Enemy_KillEnemy(object sender, System.EventArgs e)
    {
        var enemy = (Enemy)sender;
        player.score += Mathf.Round(Random.Range(enemy.experience - 10, enemy.experience + 10));
        scoreLabel.text = "SCORE " + player.score.ToString("");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashlight.gameObject.activeSelf)
            {
                flashlight.gameObject.SetActive(false);
            }
            else flashlight.gameObject.SetActive(true);
        }
    }
}
