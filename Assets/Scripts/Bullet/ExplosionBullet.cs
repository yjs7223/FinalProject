using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : Bullet
{
    public GameObject explosion;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().hp -= att;
            if (collision.GetComponent<Enemy>().hp <= 0)
            {
                collision.GetComponent<Enemy>().isDie = true;
            }
            Debug.Log($"explosion bullet att | Enemy Hp : {collision.GetComponent<Enemy>().hp}");
            GameObject e = Instantiate(explosion);
            e.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Explosion;

        //가까운적 찾기
        FindTarget();
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        if(explosion == null)
        {
            explosion = Resources.Load<GameObject>("Prefabs/Bullet/Explosion");
        }
        speed = 10f;
        rspeed = 10f;
        att = 10;

        //탄막의 방향 설정
        BulletRotate();
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
}
