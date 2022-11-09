using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameManager gm;
    public Weapon.WeaponType btype;
    public GameObject target = null;
    public Rigidbody2D rb;
    public float speed;
    public float rspeed;

    public virtual void BulletMove()
    {
        rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime);
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
