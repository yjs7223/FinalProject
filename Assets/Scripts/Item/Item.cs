using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public enum ItemType
    {
        EXP,


        MAX
    }

    public ItemType Itype;
    public Rigidbody2D rb;
    public GameManager gm;
    public float dragRange;

    public void DraggedItem()
    {
        if(Vector3.Distance(transform.position, gm.player.transform.position) <= dragRange)
        {
            Vector3 targetpos = gm.player.transform.position - transform.position;
            targetpos.Normalize();
            rb.MovePosition(transform.position + (targetpos * 20 * Time.deltaTime));
        }
    }

    void Start()
    {
        dragRange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
