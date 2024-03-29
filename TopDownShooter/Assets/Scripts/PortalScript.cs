﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalScript : MonoBehaviour
{
    Player player;
    float timeToInstantiate = 30f;
    float experience = 50f;

    [SerializeField]
    float speed = 30f;

    Enemy _enemy;
    HealthSystem healthSystem;

    [SerializeField]
    Image healthbar;
    [SerializeField]
    Enemy enemy;

    public event EventHandler DestroyPortal;
    public float TimeToInstantiate { get => timeToInstantiate; }
    public float Experience { get => experience;}

    void Start()
    {
        player = Player.instance;
        healthSystem = new HealthSystem(1500);
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        healthSystem.Death += HealthSystem_Death;
    }

    private void HealthSystem_Death(object sender, EventArgs e)
    {
        var gObject = transform.parent.gameObject;
        Destroy(gObject);
        DestroyPortal?.Invoke(this, EventArgs.Empty);
    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        healthbar.fillAmount = healthSystem.GetHealth() / healthSystem.GetMaxHealth();
    }

    public void TakeDamage(float damage)
    {
        this.healthSystem.Damage(damage);
    }
    private void Enemy_KillEnemy(object sender, System.EventArgs e)
    {
        var Enemy = (Enemy)sender;
        player.Score += Mathf.Round(UnityEngine.Random.Range(enemy.Experience - 10, enemy.Experience + 10));
    }
    void Update()
    {
        timeToInstantiate -= Time.deltaTime;
        if (timeToInstantiate <= 0)
        {
            _enemy = Instantiate(enemy, transform.position, Quaternion.identity);
            _enemy.KillEnemy += Enemy_KillEnemy;
            timeToInstantiate = 30f;
        }
        transform.Rotate(new Vector3(0f, 0f, speed * Time.deltaTime));
    }
}
