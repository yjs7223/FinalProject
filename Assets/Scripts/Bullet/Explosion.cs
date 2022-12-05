using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explostionAtt;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().hp -= explostionAtt;
            if (collision.GetComponent<Enemy>().hp <= 0)
            {
                collision.GetComponent<Enemy>().isDie = true;
            }
            Debug.Log($"explosion | Enemy Hp : {collision.GetComponent<Enemy>().hp}");
        }
    }


    void Start()
    {
        Destroy(gameObject, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
