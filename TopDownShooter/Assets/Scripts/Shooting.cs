using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{ 
    private Animator anim;
    private Vector2 mousePos;

    private Weapon currentWeapon;
    private float timePerShooting = 0.1f;
    private bool canShooting = true;
    private MagmaShooting magmaBullet;
    private Weapons weapons;
    private Weapon[] _weapons;

    [SerializeField]
    private Image overheadImage;
    private Player player;
    void Start()
    {
        weapons = GetComponent<Weapons>();
        anim = GetComponent<Animator>();
        player = Player.instance;

        currentWeapon = weapons.TakeWeapon(0);
        timePerShooting = currentWeapon.TimePerShooting;
        player.Weapon.sprite = currentWeapon.Sprite;
    }
    public void ChangeWeapon(int index)
    {
        if (!canShooting)
            return;
        currentWeapon = weapons.TakeWeapon(index);
        timePerShooting = currentWeapon.TimePerShooting;
        player.Weapon.sprite = currentWeapon.Sprite;
    }

    private void Shot(int index)
    {
        if (index != 3)
        {
            currentWeapon = weapons.TakeWeapon(index);
            Bullet bullet = currentWeapon.Bullet;
            BulletScript bs = Instantiate(bullet.Prefab, currentWeapon.ExitPoint.position, currentWeapon.ExitPoint.rotation).GetComponent<BulletScript>();
            bs.Initialize(bullet.Damage, bullet.Speed);
            //Rigidbody2D rb = bs.GetComponent<Rigidbody2D>();
            //rb.AddForce(mousePos * bullet.Speed, ForceMode2D.Impulse);
            Destroy(bs, 10f);
        }
        if(index == 3)
        {
            if (canShooting)
            {
                currentWeapon = weapons.TakeWeapon(index);
                Bullet bullet = currentWeapon.Bullet;
                magmaBullet = Instantiate(bullet.Prefab, currentWeapon.ExitPoint.position, currentWeapon.ExitPoint.rotation).GetComponent<MagmaShooting>();
                magmaBullet.Initialize(bullet.Speed);
                canShooting = false;
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timePerShooting -= Time.deltaTime;
            if(timePerShooting <= 0f)
            {
                currentWeapon.Overhead += Time.deltaTime;
                overheadImage.fillAmount = currentWeapon.Overhead;
                if (currentWeapon.Overhead > 1f)
                    currentWeapon.Overhead = 1f;
                if (currentWeapon.Overhead < 1f)
                {
                    Shot(currentWeapon.Index);
                    anim.Play("Shooting", 0);
                    timePerShooting = currentWeapon.TimePerShooting;
                }     
            }
        }
        else 
        {
            _weapons = weapons.GetWeapons();
            foreach (var item in _weapons)
            {
                item.Overhead -= Time.deltaTime;
                if (item.Overhead < 0f)
                {
                    item.Overhead = 0f;
                }
            }
            overheadImage.fillAmount = currentWeapon.Overhead;
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (magmaBullet == null)
                return;
            anim.Play("Shooting", 0);
            magmaBullet.getBack = true;
            canShooting = true;
        }       
    }
}
