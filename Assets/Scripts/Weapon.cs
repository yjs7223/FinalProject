using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    GameManager gm;
    /// <summary>
    /// ź���� ����
    /// 0�Ϲ�,1����,2����,3�帷,4����
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
