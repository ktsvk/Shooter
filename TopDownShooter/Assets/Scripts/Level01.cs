using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class Level01 : MonoBehaviour
{
    private Player player;
    private PortalScript pscript;
    private Shooting shooting;

    [SerializeField]
    private Transform[] enemySpawns;
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private Light2D flashLight;
    [SerializeField]
    private Light2D[] dangerLight;

    [SerializeField]
    private TextMeshProUGUI scoreLabel;
    [SerializeField]
    private TextMeshProUGUI moneyLabel;
    [SerializeField]
    private TextMeshProUGUI enemyLabel;
    [SerializeField]
    private TextMeshProUGUI portalLabel;
    [SerializeField]
    private TextMeshProUGUI waveLabel;
    [SerializeField]
    private TextMeshProUGUI weaponLabel;
    void Start()
    {
        Time.timeScale = 1f;
        player = Player.instance;
        shooting = player.GetComponent<Shooting>();
        player.OnMainMenu = false;
        for (int i = 0; i < enemySpawns.Length; i++)
        {
            var _enemy = Instantiate(enemy, enemySpawns[i].position, Quaternion.identity);
            _enemy.KillEnemy += Enemy_KillEnemy;
        }
    }
    private void Enemy_KillEnemy(object sender, System.EventArgs e)
    {
        var Enemy = (Enemy)sender;
        player.Score += Mathf.Round(Random.Range(enemy.Experience - 10, enemy.Experience + 10));
        scoreLabel.text = "SCORE " + player.Score.ToString("");
    }

    void Update()
    {
        moneyLabel.text = player.GetMoney().ToString("0");
        enemyLabel.text = "Enemies alive: " + GameObject.FindGameObjectsWithTag("Enemy").Length;
        portalLabel.text = "Portals count: " + GameObject.FindGameObjectsWithTag("Portal").Length;
        if(GameObject.FindGameObjectsWithTag("Portal") == null && GameObject.FindGameObjectsWithTag("Enemy") == null)
        {
            for (int i = 0; i < dangerLight.Length; i++)
            {
                dangerLight[i].color = Color.green;
                Debug.Log("Green");
            }
        }
        if(GameObject.FindGameObjectsWithTag("Portal") != null)
            pscript = GameObject.FindGameObjectWithTag("Portal").GetComponent<PortalScript>();
        if (pscript != null)
        waveLabel.text = "Next wave: " + pscript.TimeToInstantiate.ToString("0");

        var currentWeapon = shooting.GetCurrentWeapon();
        weaponLabel.text = $"Current Weapon: {currentWeapon.Name}; Damage: {currentWeapon.Bullet.Damage}; Speed:{currentWeapon.TimePerShooting}";

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (flashLight.gameObject.activeSelf)
            {
                flashLight.gameObject.SetActive(false);
            }
            else flashLight.gameObject.SetActive(true);
        }
    }
}
