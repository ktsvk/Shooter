using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private Player player;
    public HealthSystem healthSystem;
    [SerializeField]
    private Image healthbar;
    [SerializeField]
    private Text healthStat;
    void Start()
    {
        player = Player.instance;
        if (player.onMainMenu)
            return;
        healthSystem = new HealthSystem(1000);
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        healthStat.text = $"{healthSystem.GetHealth()}/{healthSystem.GetMaxHealth()}";
    }
    private void HealthSystem_OnHealthChanged(object sender, System.EventArgs e)
    {
        healthbar.fillAmount = healthSystem.GetHealth() / healthSystem.GetMaxHealth();
        healthStat.text = $"{healthSystem.GetHealth()}/{healthSystem.GetMaxHealth()}";
    }
}
