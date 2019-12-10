using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Weapon
{
    [SerializeField]
    private string name;
    [SerializeField]
    private int index;
    [SerializeField]
    private float timePerShooting;
    [SerializeField]
    private float overhead;
    [SerializeField]
    private float weight;
    [SerializeField]
    private float price;
    [SerializeField]
    private bool isBought = false;
    [SerializeField]
    private Transform exitPoint;
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private Sprite sprite;

    public string Name { get => name; }
    public int Index { get => index; }
    public float TimePerShooting { get => timePerShooting;}
    public float Overhead { get => overhead; set => overhead = value; }
    public float Weight { get => weight;}
    public float Price { get => price; }
    public bool IsBought { get => isBought; set => isBought = value; }
    public Transform ExitPoint { get => exitPoint; }
    public Bullet Bullet { get => bullet; }
    public Sprite Sprite { get => sprite; }
}
