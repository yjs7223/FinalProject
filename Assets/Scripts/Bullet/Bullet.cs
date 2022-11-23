using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 총알의 부모클래스
/// </summary>
public class Bullet : MonoBehaviour
{
    public GameManager gm;
    public Weapon.WeaponType btype;
    public GameObject target = null;
    public Vector3 targetpos;
    public Rigidbody2D rb;
    public float att;
    public float speed;
    public float rspeed;

    public void BulletMove()
    {
        /*float angle = Mathf.Atan2(targetpos.y, targetpos.x) * Mathf.Rad2Deg;
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        Quaternion r = Quaternion.Slerp(transform.rotation, angleAxis, rspeed * Time.deltaTime);
        transform.rotation = r;*/
        targetpos.Normalize();
        rb.MovePosition(transform.position + (targetpos * speed * Time.deltaTime));

        if (transform.position == targetpos)
        {
            Destroy(gameObject);
        }

        if (transform.position.x > gm.player.transform.position.x + 25)
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
        for (int i = 1; i < gm.ec.enemyList.Count; i++)
        {
            if (gm.ec.enemyList[i] == null)
            {
                i++;
                if (i >= gm.ec.enemyList.Count)
                {
                    return;
                }
            }

            dis2 = Vector3.Distance(gm.player.transform.position, gm.ec.enemyList[i].transform.position);
            if (dis1 > dis2)
            {
                target = gm.ec.enemyList[i];
                dis1 = dis2;
            }
        }

    }

    //적위치를 바라보기 (수정 해야함)
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
        Quaternion angleAxis = Quaternion.AngleAxis(angle - 90f, Vector3.right);
        Quaternion r = Quaternion.Slerp(transform.rotation, angleAxis, rspeed * Time.deltaTime);
        transform.rotation = r;
    }

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
