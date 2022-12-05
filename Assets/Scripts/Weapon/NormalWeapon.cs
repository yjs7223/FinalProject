using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWeapon : Weapon
{   
    public override void Attack()
    {
        attDelay += Time.deltaTime;
        
        if(attDelay >= attSpeed)
        {
            for (int i = 0; i < bulletnum; i++)
            {
                Debug.Log("normal attack");
                Bullet b = Instantiate(bullet);
                Vector3 temppos = transform.position;
                temppos.z = 0.1f;
                b.transform.position = temppos;
                b.att = weaponAtt;
            }
            attDelay = 0;
        }
    }

    public override void WeaponLevelUp()
    {
        level++;
        if(level >= 6)
        {
            level = 6;
        }
        switch (level)
        {
            case 2:
                bulletnum = 2;
                break;
            case 3:
                weaponAtt = 10;
                break;
            case 4:
                bulletnum = 4;
                break;
            case 5:
                weaponAtt = 15;
                break;
            case 6:
                bulletnum = 6;
                break;

        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/NormalBullet");
        type = WeaponType.Normal;
        attSpeed = 1.5f;
        attDelay = 0;
        level = 1;
        weaponAtt = 5;
        bulletnum = 1;
    }

    void Update()
    {
        
    }
}
