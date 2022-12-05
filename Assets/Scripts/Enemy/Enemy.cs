using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gm;
    //ü��
    public float hp;
    //���ݷ�
    public float att;
    //����Ʈ �ε���
    public int enemynum;
    public bool isDie;
    //��Ÿ��
    public enum EnemyType
    {
        Normal,
        Small,
        Large
    }
    EnemyType enemytype;
    //�̵��ӵ�
    float speed;
    //����ٴ� �÷��̾�
    public Transform target = null;
    public Rigidbody2D rb;

    //�� �̵�(�÷��̾� ����ٴϱ�)
    public void EnemyMove()
    {
        Vector3 targetpos = target.position - transform.position;
        //transform.LookAt(target);
        targetpos.Normalize();
        rb.MovePosition(transform.position + (targetpos * speed * Time.deltaTime));

    }

    //���ó��
    public void Die()
    {
        if(isDie)
        {
            //���� ��ġ�� ����ġ ������ ���
            GameObject exp = Instantiate(Resources.Load<GameObject>("Prefabs/Item/ExpItem"));
            exp.transform.position = transform.position;

            //����Ʈ�� �ε����� ���� �ε����� ���� ������ ����Ʈ�� �ٽ� Ȯ���Ͽ� ����ó��
            if (gm.ec.enemyList.Count <= enemynum || gm.ec.enemyList[enemynum] != gameObject)
            {
                for (int i = 0; i < gm.ec.enemyList.Count; i++)
                {
                    if (gm.ec.enemyList[i] == gameObject)
                    {
                        gm.ec.enemyList.RemoveAt(i);
                        Destroy(gameObject);
                    }
                }
            }
            else
            {
                gm.ec.enemyList.RemoveAt(enemynum);
                Destroy(gameObject);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        target = gm.player.transform;
        speed = 5;
        att = 1;
        isDie = false;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
        Die();
    }
}
