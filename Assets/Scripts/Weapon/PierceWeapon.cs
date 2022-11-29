using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceWeapon : Weapon
{
    public override void Attack()
    {
        attDelay += Time.deltaTime;
        if (attDelay >= attSpeed)
        {
            Debug.Log("pierce attack");
            Bullet b = Instantiate(bullet);
            Vector3 temppos = transform.position;
            temppos.z = 0.1f;
            b.transform.position = temppos;
            attDelay = 0;
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/PierceBullet");
        type = WeaponType.Pierce;
        attSpeed = 3f;
        attDelay = 0;
    }


    void Update()
    {
        
    }
}
