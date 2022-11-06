using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameManager gm;
    /// <summary>
    /// 탄막의 종류
    /// 0일반,1폭팔,2관통,3장막,4장판
    /// </summary>
    public enum BulletType
    {
        Normal,
        Explosion,
        Penetrate,
        Curtain,
        Floor,

        MAX
    }

    GameObject Bullet;
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
