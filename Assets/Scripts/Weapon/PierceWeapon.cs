using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceWeapon : Weapon
{
    public int pNum;
    public override void Attack()
    {
        attDelay += Time.deltaTime;
        if (attDelay >= attSpeed)
        {
            for (int i = 0; i < bulletnum; i++)
            {
                Debug.Log("pierce attack");
                Bullet b = Instantiate(bullet);
                Vector3 temppos = transform.position;
                temppos.z = 0.1f;
                b.att = weaponAtt;
                b.GetComponent<PierceBullet>().pierceNum = pNum;
                b.transform.position = temppos;
            }
            attDelay = 0;
        }
    }

    public override void WeaponLevelUp()
    {
        level++;
        if (level >= 6)
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
                pNum = 3;
                break;
            case 4:
                bulletnum = 3;
                break;
            case 5:
                weaponAtt = 15;
                pNum = 4;
                break;
            case 6:
                bulletnum = 4;
                break;

        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/PierceBullet");
        type = WeaponType.Pierce;
        attSpeed = 3f;
        attDelay = 0;
        pNum = 2;
        bulletnum = 1;
        level = 1;
    }


    void Update()
    {
        
    }
}
