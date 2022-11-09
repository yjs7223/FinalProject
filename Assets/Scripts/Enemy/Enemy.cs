using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameManager gm;

    public enum EnemyType
    {
        Normal,
        Small,
        Large
    }

    float speed;
    public Transform target = null;
    public Rigidbody2D rb;

    public void EnemyMove()
    {
        Vector3 targetpos = target.position - transform.position;
        //transform.LookAt(target);
        targetpos.Normalize();
        rb.MovePosition(transform.position + (targetpos * speed * Time.deltaTime));

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        target = gm.player.transform;
        speed = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
