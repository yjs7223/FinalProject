using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ExplosionWeapon : Weapon
{
    public override void Attack()
    {
        attDelay += Time.deltaTime;
        if (attDelay >= attSpeed)
        {
            for (int i = 0; i < bulletnum; i++)
            {
                Debug.Log("explosion attack");
                Bullet b = Instantiate(bullet);
                Vector3 temppos = transform.position;
                temppos.z = 0.1f;
                b.transform.position = temppos;
                b.att = weaponAtt;
                b.GetComponent<ExplosionBullet>().exAtt = weaponAtt / 3;
            }
            attDelay = 0;
            
        }
    }

    public override void WeaponLevelUp()
    {
        level++;
        switch (level)
        {
            case 2:
                bulletnum = 2;
                break;
            case 3:
                weaponAtt = 20;
                break;
            case 4:
                bulletnum = 3;
                break;
            case 5:
                weaponAtt = 30;
                break;
            case 6:
                bulletnum = 4;
                break;

        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/ExplosionBullet");
        type = WeaponType.Explosion;
        attSpeed = 4f;
        attDelay = 0;
        weaponAtt = 10;
        bulletnum = 1;
        level = 1;
    }

    void Update()
    {

    }
}

