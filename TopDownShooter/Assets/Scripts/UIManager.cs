using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button[] weaponButtons;

    private KeyCode standart, speedy, happy, magma, fire;
    private Player player;
    void Start()
    {
        standart = KeyCode.Alpha1;
        speedy = KeyCode.Alpha2;
        happy = KeyCode.Alpha3;
        magma = KeyCode.Alpha4;
        fire = KeyCode.Alpha5;
        player = Player.instance;
    }

    void Update()
    {
        if(Input.GetKeyDown(standart))
        {
            WeaponButtonOnClick(0);
        }
        if (Input.GetKeyDown(speedy))
        {
            WeaponButtonOnClick(1);

        }
        if (Input.GetKeyDown(happy))
        {
            WeaponButtonOnClick(2);
        }
        if (Input.GetKeyDown(magma))
        {
            WeaponButtonOnClick(3);
        }
        if (Input.GetKeyDown(fire))
        {
            WeaponButtonOnClick(4);
        }
    }
    private void WeaponButtonOnClick(int btnIndex)
    {
        player.GetComponent<Shooting>().ChangeWeapon(btnIndex);
    }
}
