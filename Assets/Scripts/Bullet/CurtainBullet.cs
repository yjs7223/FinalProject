using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainBullet : Bullet
{
    public float damageDelay;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            damageDelay += Time.deltaTime;
            if (damageDelay > 1)
            {
                damageDelay = 0;
                collision.GetComponent<Enemy>().hp -= att;
                if (collision.GetComponent<Enemy>().hp <= 0)
                {
                    collision.GetComponent<Enemy>().isDie = true;
                }
                Debug.Log($"curtain bullet att | Enemy Hp : {collision.GetComponent<Enemy>().hp}");
            }
        }
    }

    public override void BulletMove()
    {
        transform.position = gm.player.transform.position;
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        btype = Weapon.WeaponType.Curtain;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        damageDelay = 1;
    }

    // Update is called once per frame
    void Update()
    {
        BulletMove();
    }
}
