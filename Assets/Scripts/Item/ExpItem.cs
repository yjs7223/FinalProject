using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpItem : Item
{
    public float exp;
    void Start()
    {
        exp = 1;
        gm = GameManager.GetInstance();
        rb = GetComponent<Rigidbody2D>();
        Itype = ItemType.EXP;
    }

    void Update()
    {
        DraggedItem();
    }
}
