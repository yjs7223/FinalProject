using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    GameManager gm;

    public void BackgroundMove()
    {
        if (gm.player.transform.position.x - transform.position.x > 5)
        {
            Vector3 temppos = transform.position;
            temppos.x += 5;
            transform.position = temppos;
        }
        else if (gm.player.transform.position.x - transform.position.x < -5)
        {
            Vector3 temppos = transform.position;
            temppos.x -= 5;
            transform.position = temppos;
        }

        if (gm.player.transform.position.y - transform.position.y > 5)
        {
            Vector3 temppos = transform.position;
            temppos.y += 5;
            transform.position = temppos;
        }
        else if (gm.player.transform.position.y - transform.position.y < -5)
        {
            Vector3 temppos = transform.position;
            temppos.y -= 5;
            transform.position = temppos;
        }
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
