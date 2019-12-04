using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseHealth : MonoBehaviour
{
    public GameObject effect;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public void Use()
    {
        GameObject _effect = Instantiate(effect, player.position, Quaternion.identity);
        Destroy(_effect, 0.5f);
        Destroy(gameObject);
    }

}
