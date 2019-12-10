using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] shopButtons;

    [SerializeField]
    private Animator anim;

    private KeyCode standart, speedy, happy, magma, fire;
    private Player player;

    private Shooting shooting;
    private Weapon currentWeapon;

    private bool inventory = false;
    void Start()
    {
        standart = KeyCode.Alpha1;
        speedy = KeyCode.Alpha2;
        happy = KeyCode.Alpha3;
        magma = KeyCode.Alpha4;
        fire = KeyCode.Alpha5;
        player = Player.instance;
        shooting = player.GetComponent<Shooting>();
    }

    void Update()
    {
        currentWeapon = shooting.GetCurrentWeapon();
        if(Input.GetKeyDown(standart))
        {
            if(shooting.GetWeapon(0).IsBought && (currentWeapon != shooting.GetWeapon(0)))
                shooting.ChangeWeapon(0);
        }
        if (Input.GetKeyDown(speedy))
        {
            if (shooting.GetWeapon(1).IsBought && (currentWeapon != shooting.GetWeapon(1)))
                shooting.ChangeWeapon(1);
        }
        if (Input.GetKeyDown(happy))
        {
            if (shooting.GetWeapon(2).IsBought && (currentWeapon != shooting.GetWeapon(2)))
                shooting.ChangeWeapon(2);
        }
        if (Input.GetKeyDown(magma))
        {
            if (shooting.GetWeapon(3).IsBought && (currentWeapon != shooting.GetWeapon(3)))
                shooting.ChangeWeapon(3);
        }
        if (Input.GetKeyDown(fire))
        {
            if (shooting.GetWeapon(4).IsBought && (currentWeapon != shooting.GetWeapon(4)))
                shooting.ChangeWeapon(4);
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
    public void BuyWeapon(int index)
    {
        if(player.GetMoney() >= shooting.GetWeapon(index).Price && !shooting.GetWeapon(index).IsBought)
        {
            player.SubMoney(shooting.GetCurrentWeapon().Price);
            player.GetComponent<Shooting>().ChangeWeapon(index);
            shooting.GetWeapon(index).IsBought = true;
            shopButtons[index].transform.GetChild(1).gameObject.SetActive(false);
            shopButtons[index].transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
