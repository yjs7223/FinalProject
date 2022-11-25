using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameManager gm;
    /// <summary>
    /// ź���� ����
    /// 0�Ϲ�,1����,2����,3�帷,4����
    /// </summary>
    public enum WeaponType
    {
        Normal,
        Explosion,
        pierce,
        Curtain,
        Floor,

        MAX
    }

    public Bullet bullet;

    public virtual void Attack()
    {
        Debug.Log("attack");
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
