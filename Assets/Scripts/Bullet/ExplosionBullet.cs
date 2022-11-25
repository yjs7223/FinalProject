using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBullet : Bullet
{
    public float explostionAtt;

    public GameObject explosion;

    //����ó�� �߰�
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

        //������� ã��
        FindTarget();
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;
        rspeed = 10f;
        att = 10;
        explostionAtt = 5f;

        //ź���� ���� ����
        BulletRotate();
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
}
