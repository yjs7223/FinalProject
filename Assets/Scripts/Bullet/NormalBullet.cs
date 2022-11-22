using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalBullet : Bullet
{
    Vector3 targetpos;
    float angle;

    public override void BulletMove()
    {
        /*float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion r = Quaternion.Slerp(transform.rotation, angleAxis, rspeed * Time.deltaTime);
        transform.rotation = r;*/
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

    public void FindTarget()
    {
        if (gm.ec.enemyList[0] == null)
        {
            return;
        }

        float dis1 = Vector3.Distance(gm.player.transform.position, gm.ec.enemyList[0].transform.position);
        target = gm.ec.enemyList[0];

        if (gm.ec.enemyList[1] == null)
        {
            return;
        }

        float dis2 = 0;
        for(int i = 1; i<gm.ec.enemyList.Count; i++)
        {
            if (gm.ec.enemyList[i] == null)
            {
                i++;
                if(i >= gm.ec.enemyList.Count)
                {
                    return;
                }
            }

            dis2 = Vector3.Distance(gm.player.transform.position, gm.ec.enemyList[i].transform.position);
            if(dis1 > dis2)
            {
                target = gm.ec.enemyList[i];
                dis1 = dis2;
            }
        }

    }
    public void BulletRotate()
    {
        if (target == null)
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

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Normal;

        //가까운적 찾기
        FindTarget();
        rb = GetComponent<Rigidbody2D>();
        speed = 10f;
        rspeed = 10f;

        //탄막의 방향 설정
        BulletRotate();
    }


    void Update()
    {
        BulletMove();
    }
}
