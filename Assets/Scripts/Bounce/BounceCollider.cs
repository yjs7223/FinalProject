using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCollider : MonoBehaviour
{
    public GameObject top, bottom, left, right;
    GameManager gm;
    public void FollowPlayer()
    {
        transform.position = gm.player.transform.position;
        top.transform.position = gm.player.transform.position;
        bottom.transform.position = gm.player.transform.position;
        left.transform.position = gm.player.transform.position; 
        right.transform.position = gm.player.transform.position;    
    }
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }
}
