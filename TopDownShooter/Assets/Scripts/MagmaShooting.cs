using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagmaShooting : MonoBehaviour
{
    public bool getBack = false;

    private Vector2 mousePos;
    private float speed = 40f;
    private Player player;

    public void Initialize(float speed)
    {
        this.speed = speed;
    }
    private void Start()
    {
        player = Player.instance;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        if (getBack)
        {
            float distance = Vector2.Distance(transform.position, player.gameObject.transform.position);
            if (distance <= 0.5f)
            {
                Destroy(gameObject);
            }
            transform.position = Vector2.MoveTowards(transform.position, player.gameObject.transform.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        }
    }
}
