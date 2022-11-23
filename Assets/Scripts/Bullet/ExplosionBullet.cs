using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : Bullet
{
    public float explostionAtt;
    //폭발처리 추가
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //collision.GetComponent<Enemy>().hp -= att;
            if (collision.GetComponent<Enemy>().hp <= 0)
            {
                collision.GetComponent<Enemy>().isDie = true;
            }
            Debug.Log($"explosion bullet att ");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Explosion;

        //가까운적 찾기
        FindTarget();
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;
        rspeed = 10f;
        att = 10;
        explostionAtt = 5f;

        //탄막의 방향 설정
        BulletRotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
