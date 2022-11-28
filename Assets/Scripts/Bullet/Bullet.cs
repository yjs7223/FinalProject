using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ѿ��� �θ�Ŭ����
/// </summary>
public class Bullet : MonoBehaviour
{
    public GameManager gm;
    /// <summary>
    /// ������ Ÿ��
    /// </summary>
    public Weapon.WeaponType btype;
    /// <summary>
    /// ������ ��
    /// </summary>
    public GameObject target = null;
    //���� ��ġ��
    public Vector3 targetpos;
    //���������� ����ϱ����� ������ٵ�
    public Rigidbody2D rb;

    /// <summary>
    /// ź���� ���ݷ�
    /// </summary>
    public float att;
    /// <summary>
    /// ź���� �̵��ӵ�
    /// </summary>
    public float speed;
    /// <summary>
    /// ź���� ȸ���ӵ�
    /// </summary>
    public float rspeed;

    /// <summary>
    /// ź���� ����
    /// </summary>
    public int bnum;

    /// <summary>
    /// ź���� �̵��Լ�(�⺻��)
    /// </summary>
    public virtual void BulletMove()
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

    /// <summary>
    /// ������ �� ����(����� �� �켱 Ÿ����)
    /// </summary>
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

    //ź���� �� ��ġ �������� ȸ�� (���ļ���)
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


    void Update()
    {
        
    }
}
