using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int Weapon = 0;
    
    private Animator anim;

    private Weapon currentWeapon;
    private float timePerShooting = 0.1f;
    private bool canShooting = true;
    private MagmaShooting magmaBullet;
    private Weapons weapons;

    private Player player;

    [SerializeField]
    private Transform[] exitPoints;
    void Start()
    {
        weapons = GetComponent<Weapons>();
        anim = GetComponent<Animator>();
        player = Player.instance;

        Weapon = 0;
        currentWeapon = weapons.TakeWeapon(0);
        timePerShooting = currentWeapon.TimePerShooting;
        player.Weapon.sprite = currentWeapon.Sprite;
    }
    public void ChangeWeapon(int index)
    {
        if (!canShooting)
            return;
        Weapon = index;
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
            bs.Initialize(bullet.Damage);
            Rigidbody2D rb = bs.GetComponent<Rigidbody2D>();
            rb.AddForce(currentWeapon.ExitPoint.up * bullet.Speed, ForceMode2D.Impulse);
            Destroy(bs, 10f);
        }
        if(index == 3)
        {
            if (canShooting)
            {
                currentWeapon = weapons.TakeWeapon(index);
                Bullet bullet = currentWeapon.Bullet;
                magmaBullet = Instantiate(bullet.Prefab, currentWeapon.ExitPoint.position, currentWeapon.ExitPoint.rotation).GetComponent<MagmaShooting>();
                magmaBullet.speed = bullet.Speed;
                canShooting = false;
            }
        }
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            timePerShooting -= Time.deltaTime;
            if(timePerShooting <= 0)
            {
                Shot(Weapon);
                anim.Play("Shooting", 0);
                timePerShooting = currentWeapon.TimePerShooting;
            }
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
