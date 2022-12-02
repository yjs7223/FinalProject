using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PierceBullet : Bullet
{
    public int pierceNum;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            pierceNum--;
            collision.GetComponent<Enemy>().hp -= att;
            if (collision.GetComponent<Enemy>().hp <= 0)
            {
                collision.GetComponent<Enemy>().isDie = true;
            }
            Debug.Log($"pierce bullet att | Enemy Hp : {collision.GetComponent<Enemy>().hp}");
            if (pierceNum <= 0)
            {
                Destroy(gameObject);
            }
        }

        if(collision.tag == "Vertical")
        {
            Debug.Log("vertical bounce");
            targetpos.x *= -1;
        }

        if(collision.tag == "Horizontal")
        {
            Debug.Log("horizontal bounce");
            targetpos.y *= -1;
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Pierce;

        //가까운적 찾기
        FindTarget();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        speed = 20f;
        rspeed = 10f;
        att = 5;
        pierceNum = 2;
        //탄막의 방향 설정
        BulletRotate();

        Destroy(gameObject, 8f);
    }


    void Update()
    {
        BulletMove();
    }
}
