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
    private Transform exitPoint;
    [SerializeField]
    private Bullet bullet;
    [SerializeField]
    private Sprite sprite;

    public string Name { get => name; }
    public int Index { get => index; }
    public float TimePerShooting { get => timePerShooting; }
    public float Overhead { get => overhead; set => overhead = value; }
    public Transform ExitPoint { get => exitPoint; }
    public Bullet Bullet { get => bullet; }
    public Sprite Sprite { get => sprite; }
}
