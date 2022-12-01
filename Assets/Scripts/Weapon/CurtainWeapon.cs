using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainWeapon : Weapon
{
    public bool isCurtain;


    public override void Attack()
    {
        if(!isCurtain)
        {
            isCurtain = true;
            Bullet b = Instantiate(bullet, gm.player.transform);
            Vector3 temppos = gm.player.transform.position;

            b.transform.position = temppos;
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/CurtainBullet");
        type = WeaponType.Curtain;
        isCurtain = false;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
