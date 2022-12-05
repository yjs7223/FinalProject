using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gm;
    //체력
    public float hp;
    //공격력
    public float att;
    //리스트 인덱스
    public int enemynum;
    public bool isDie;
    //적타입
    public enum EnemyType
    {
        Normal,
        Small,
        Large
    }
    EnemyType enemytype;
    //이동속도
    float speed;
    //따라다닐 플레이어
    public Transform target = null;
    public Rigidbody2D rb;

    //적 이동(플레이어 따라다니기)
    public void EnemyMove()
    {
        Vector3 targetpos = target.position - transform.position;
        //transform.LookAt(target);
        targetpos.Normalize();
        rb.MovePosition(transform.position + (targetpos * speed * Time.deltaTime));

    }

    //사망처리
    public void Die()
    {
        if(isDie)
        {
            //본인 위치에 경험치 아이템 드롭
            GameObject exp = Instantiate(Resources.Load<GameObject>("Prefabs/Item/ExpItem"));
            exp.transform.position = transform.position;

            //리스트의 인덱스와 본인 인덱스가 맞지 않을때 리스트를 다시 확인하여 삭제처리
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
