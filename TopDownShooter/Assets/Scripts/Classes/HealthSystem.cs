using System;

public class HealthSystem
{
    public event EventHandler OnHealthChanged;
    public event EventHandler Death;

    private float health;
    private float healthMax;

    public HealthSystem(float healthMax)
    {
        this.healthMax = healthMax;
        health = healthMax;
    }
    public float GetHealth()
    {
        return health;
    }
    public void Damage(float damageAmount)
    {
        health -= damageAmount;
        if (health < 0)
        {
            Death?.Invoke(this, EventArgs.Empty);
            health = 0;
        }
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
    public float GetMaxHealth()
    {
        return healthMax;
    }
    public void Heal(float healAmount)
    {
        health += healAmount;
        if (health > healthMax) health = healthMax;
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
