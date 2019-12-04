using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField]
    private Weapon[] weapons;

    public Weapon TakeWeapon(int index)
    {
        return weapons[index];
    }
}
