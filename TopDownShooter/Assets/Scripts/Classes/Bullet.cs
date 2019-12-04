using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Bullet
{
    [SerializeField]
    private string name;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject prefab;
    [SerializeField]

    public string Name { get => name; }
    public float Damage { get => damage; }
    public float Speed { get => speed; }
    public GameObject Prefab { get => prefab; }
}
