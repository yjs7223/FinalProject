using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalBullet : Bullet
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().hp -= att;
            if(collision.GetComponent<Enemy>().hp <= 0)
            {
                collision.GetComponent<Enemy>().isDie = true;
            }
            Debug.Log($"normal bullet att | Enemy Hp : {collision.GetComponent<Enemy>().hp}");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Normal;

        //������� ã��
        FindTarget();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        speed = 30f;
        rspeed = 10f;
        att = 5;

        //ź���� ���� ����
        BulletRotate();
    }


    void Update()
    {
        BulletMove();
    }
}
