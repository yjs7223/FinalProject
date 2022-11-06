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

    public void EnemyMove()
    {
        Vector3 ptemppos;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
