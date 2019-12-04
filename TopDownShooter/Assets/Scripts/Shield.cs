using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject[] hitEffect;
    public Transform target;

    public float xSpread;
    public float ySpread;

    public float rotSpeed;

    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime * rotSpeed;
        Rotate();
    }
    void Rotate()
    {
        float x = Mathf.Cos(timer) * xSpread;
        float y = Mathf.Sin(timer) * ySpread;
        Vector2 pos = new Vector2(x, y);
        transform.position = pos + new Vector2(target.position.x, target.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var target = collision.gameObject.GetComponent<Enemy>();
            target.healthSystem.Damage(Random.Range(10, 30));
            int whichEffect = Random.Range(0, hitEffect.Length);
            GameObject effect = Instantiate(hitEffect[whichEffect], transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
