using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameManager gm;
    /// <summary>
    /// 탄막의 종류
    /// 0일반,1폭팔,2관통,3장막,4장판
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
