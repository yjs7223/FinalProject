using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public float floorAtt;
    public float delay;
    public float a;
    public bool isupa;
    public SpriteRenderer r;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            delay += Time.deltaTime;
            if(delay > 1f)
            {
                delay = 0f;
                collision.GetComponent<Enemy>().hp -= floorAtt;
                if (collision.GetComponent<Enemy>().hp <= 0)
                {
                    collision.GetComponent<Enemy>().isDie = true;
                }
                Debug.Log($"floor att | Enemy HP : {collision.GetComponent<Enemy>().hp}");
            }
        }
    }

    public void ColorChange()
    {
        if(a >= 1)
        {
            isupa = false;
        }
        else if(a < 0.47)
        {
            isupa = true;
        }

        if(isupa)
        {
            a += 0.003f;
        }
        else
        {
            a -= 0.003f;
        }

        r.color = new Color(0.352f,0.862f,1f,a);
    }

    void Start()
    {
        if (r == null)
        {
            r = GetComponent<SpriteRenderer>();
        }
            
        Destroy(gameObject, 6f);
        a = 1;
        isupa = false;
    }

    void Update()
    {
        ColorChange();
    }
}
