using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] hitEffect;


    private Player player;

    private float damage;
    private float speed;
    private Vector2 mousePos;
    private void Start()
    {
        player = Player.instance;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(gameObject.name == "FireBullet(Clone)")
        {
            Destroy(gameObject, 0.5f);
        }
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        if(Vector2.Distance(transform.position, mousePos) <= 0.1f)
        {
            if (hitEffect.Length == 0)
                return;
            int whichEffect = Random.Range(0, hitEffect.Length);
            GameObject effect = Instantiate(hitEffect[whichEffect], transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }
    public void Initialize(float damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            if (player.OnMainMenu)
                return;
            var target = collision.gameObject.GetComponent<Enemy>();
            target.TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Portal"))
        {
            var target = collision.gameObject.GetComponent<PortalScript>();
            target.TakeDamage(damage);
        }
        if (!collision.gameObject.CompareTag("Bullet"))
        {
            if (hitEffect.Length == 0)
                return;
            int whichEffect = Random.Range(0, hitEffect.Length);
            GameObject effect = Instantiate(hitEffect[whichEffect], transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(gameObject.name == "FireBullet(Clone)")
        {
            Debug.Log("Trigger fire");
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if (player.OnMainMenu)
                    return;
                var target = collision.gameObject.GetComponent<Enemy>();
                target.TakeDamage(damage);
            }
            if (collision.gameObject.CompareTag("Portal"))
            {
                var target = collision.gameObject.GetComponent<PortalScript>();
                target.TakeDamage(damage);
            }
            if (!collision.gameObject.CompareTag("Bullet"))
            {
                if (hitEffect.Length == 0)
                    return;
                int whichEffect = Random.Range(0, hitEffect.Length);
                GameObject effect = Instantiate(hitEffect[whichEffect], transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
                Destroy(gameObject);
            }
        }
    }
}
