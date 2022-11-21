using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    Vector3 targetpos;

    public override void BulletMove()
    { 
        if(target != null)
        {
            targetpos = target.transform.position - transform.position;
        }
        float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion r = Quaternion.Slerp(transform.rotation, angleAxis, rspeed * Time.deltaTime);
        transform.rotation = r;
        targetpos.Normalize();
        rb.MovePosition(transform.position + (targetpos * speed * Time.deltaTime));

        if(transform.position == targetpos)
        {
            Destroy(gameObject);
        }

        if(transform.position.x > gm.player.transform.position.x + 25)
        {
            if (transform.position.y > gm.player.transform.position.y + 25)
            {
                Destroy(gameObject);
            }
            else if (transform.position.y < gm.player.transform.position.y - 25)
            {
                Destroy(gameObject);
            }
        }
        else if (transform.position.y < gm.player.transform.position.y - 25)
        {
            if (transform.position.y > gm.player.transform.position.y + 25)
            {
                Destroy(gameObject);
            }
            else if (transform.position.y < gm.player.transform.position.y - 25)
            {
                Destroy(gameObject);
            }
        }
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
        //가장가까운적찾기로변경
        target = GameObject.FindWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;
        rspeed = 10f;

        //미리 회전시키기
        if(target == null)
        {
            targetpos = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
        }
        else
        {
            targetpos = target.transform.position - transform.position;
        }
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
