using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaShooting : MonoBehaviour
{
    private Vector2 targetPos;

    public float speed = 40f;
    public Transform firePoint;

    public bool getBack = false;

    private Player player;
    private float distance;
    private void Start()
    {
        player = Player.instance;
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        if (getBack)
        {
            distance = Vector2.Distance(transform.position, player.gameObject.transform.position);
            if (distance <= 0.5f)
            {
                Destroy(gameObject);
            }
            transform.position = Vector2.MoveTowards(transform.position, player.gameObject.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        }
    }
}
