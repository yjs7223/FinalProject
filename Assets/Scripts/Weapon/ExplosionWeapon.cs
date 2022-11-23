using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ExplosionWeapon : Weapon
{
    public float attSpeed;
    public float attDelay;

    public override void Attack()
    {
        attDelay += Time.deltaTime;
        if (attDelay >= attSpeed)
        {
            Debug.Log("explosion attack");
            Bullet b = Instantiate(bullet);
            Vector3 temppos = transform.position;
            temppos.z = 0.1f;
            b.transform.position = temppos;
            attDelay = 0;
        }
    }

    void Start()
    {
        //��������ü ���������� ����
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/ExplosionBullet");
        attSpeed = 4f;
        attDelay = 0;
    }

    void Update()
    {
        
    }
}
