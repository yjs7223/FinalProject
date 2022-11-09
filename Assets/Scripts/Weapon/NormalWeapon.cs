using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalWeapon : Weapon
{
    public float attSpeed;
    public float attTerm;

    public override void Attack()
    {
        attTerm +=Time.deltaTime;
        if(attTerm >= attSpeed)
        {
            Debug.Log("normal attack");
            Bullet b = Instantiate(bullet);
            Vector3 temppos = transform.position;
            temppos.z = 0.1f;
            b.transform.position = temppos;
            attTerm = 0;
        }
    }

    void Start()
    {
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/NormalBullet");
        attSpeed = 3f;
        attTerm = 0;
    }

    void Update()
    {
        
    }
}
