using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void SpawnDroppedItem()
    {
        int posX = Random.Range(-4, 4);
        int posY = Random.Range(-4, 4);
        Vector2 playerPos = new Vector2(player.position.x + posY, player.position.y + posX) ;
        Instantiate(item, playerPos, Quaternion.identity);
    }
}
