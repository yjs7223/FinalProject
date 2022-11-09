using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{


    public override void BulletMove()
    {
        Vector3 targetpos = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion r = Quaternion.Slerp(transform.rotation, angleAxis, rspeed * Time.deltaTime);
        transform.rotation = r;
        targetpos.Normalize();
        rb.MovePosition(transform.position + (targetpos * speed * Time.deltaTime));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Normal;
        target = GameObject.FindWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;
        rspeed = 10f;

        //미리 회전시키기
        Vector3 targetpos = target.transform.position - transform.position;
        float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion r = Quaternion.Slerp(transform.rotation, angleAxis, rspeed * Time.deltaTime);
        transform.rotation = r;
    }


    void Update()
    {
        BulletMove();
    }
}
