using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hitEffect;

    private Rigidbody2D rb;
    private Player player;

    private float damage;
    private void Start()
    {
        player = Player.instance;
        rb = GetComponent<Rigidbody2D>();
        if(gameObject.name == "FireBullet(Clone)")
        {
            Destroy(gameObject, 0.5f);
        }
    }
    public void Initialize(float damage)
    {
        this.damage = damage;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            var target = collision.gameObject.GetComponent<Enemy>();
            if (!player.onMainMenu)
            {
                target.healthSystem.Damage(damage);
            }
        }
        if(!collision.gameObject.CompareTag("Bullet"))
        {
            if (hitEffect.Length > 0)
            {
                int whichEffect = Random.Range(0, hitEffect.Length);
                GameObject effect = Instantiate(hitEffect[whichEffect], transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
            }
            Destroy(gameObject);
        }
    }
}
