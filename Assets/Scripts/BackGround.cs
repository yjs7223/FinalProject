using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    GameManager gm;
    public List<GameObject> BgObjList;

    public void BackGroundSet()
    {
        BgObjList[0].transform.localPosition = new Vector3(-15, 15, 0);
        BgObjList[1].transform.localPosition = new Vector3( 0, 15, 0);
        BgObjList[2].transform.localPosition = new Vector3(15, 15, 0);
        BgObjList[3].transform.localPosition = new Vector3(-15, 0, 0);
        BgObjList[4].transform.localPosition = new Vector3(0, 0, 0);
        BgObjList[5].transform.localPosition = new Vector3(15, 0, 0);
        BgObjList[6].transform.localPosition = new Vector3(-15, -15, 0);
        BgObjList[7].transform.localPosition = new Vector3(0, -15, 0);
        BgObjList[8].transform.localPosition = new Vector3(15, -15, 0);
    }

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
        gm.bg = this;
        BackGroundSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
