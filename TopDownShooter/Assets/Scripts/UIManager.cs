using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Button[] weaponButtons;

    [SerializeField]
    private Animator anim;

    private KeyCode standart, speedy, happy, magma, fire;
    private Player player;

    private bool inventory = false;
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
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!inventory)
            {
                anim.Play("GunsUIOpen", 0);
                inventory = true;
            }
            else
            if(inventory)
            {
                anim.Play("GunsUIClose", 0);
                inventory = false;
            }
        }
    }
    private void WeaponButtonOnClick(int btnIndex)
    {
        player.GetComponent<Shooting>().ChangeWeapon(btnIndex);
    }
}
