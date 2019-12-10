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
    private AudioClip[] audioClipShots;
    [SerializeField]
    private AudioSource audioSource;

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
    public Weapon GetCurrentWeapon()
    {
        return currentWeapon;
    }
    public Weapon GetWeapon(int index)
    {
        return _weapons[index];
    }
    private void Shot(int index)
    {
        if (index != 3 && index != 4)
        {
            audioSource.Play();
            currentWeapon = weapons.TakeWeapon(index);
            Bullet bullet = currentWeapon.Bullet;
            BulletScript bs = Instantiate(bullet.Prefab, currentWeapon.ExitPoint.position, currentWeapon.ExitPoint.rotation).GetComponent<BulletScript>();
            bs.Initialize(bullet.Damage, bullet.Speed);
            Destroy(bs, 10f);
        }
        if(index == 3)
        {
            if (canShooting)
            {
                audioSource.Play();
                currentWeapon = weapons.TakeWeapon(index);
                Bullet bullet = currentWeapon.Bullet;
                magmaBullet = Instantiate(bullet.Prefab, currentWeapon.ExitPoint.position, currentWeapon.ExitPoint.rotation).GetComponent<MagmaShooting>();
                magmaBullet.Initialize(bullet.Speed);
                canShooting = false;
            }
        }
        if (index == 4)
        {
            if (canShooting)
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
                currentWeapon = weapons.TakeWeapon(index);
                Bullet bullet = currentWeapon.Bullet;
                BulletScript bs = Instantiate(bullet.Prefab, currentWeapon.ExitPoint.position, currentWeapon.ExitPoint.rotation).GetComponent<BulletScript>();
                bs.Initialize(bullet.Damage, bullet.Speed);
                Destroy(bs, 10f);
            }
        }
    }
    void Update()
    {
        _weapons = weapons.GetWeapons();
        foreach (var item in _weapons)
        {
            if (item != currentWeapon)
            {
                item.Overhead -= Time.deltaTime * 0.2f;
                if (item.Overhead < 0f)
                {
                    item.Overhead = 0f;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            timePerShooting -= Time.deltaTime;
            if (timePerShooting <= 0f)
            {
                currentWeapon.Overhead += Time.deltaTime;
                if (currentWeapon.Overhead > 1f)
                    currentWeapon.Overhead = 1f;
                if (currentWeapon.Overhead < 1f)
                {
                    Shot(currentWeapon.Index);
                    audioSource.clip = audioClipShots[currentWeapon.Index];
                    anim.Play("Shooting", 0);
                    timePerShooting = currentWeapon.TimePerShooting;
                }
            }
        }
        else
        {
            currentWeapon.Overhead -= Time.deltaTime * 0.2f;
            if (currentWeapon.Overhead < 0f)
            {
                currentWeapon.Overhead = 0f;
            }
            audioSource.Stop();
        }
        overheadImage.fillAmount = currentWeapon.Overhead;
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
