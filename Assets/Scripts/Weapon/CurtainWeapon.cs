using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainWeapon : Weapon
{
    public bool isCurtain;
    Bullet b;
    public float cScale;

    public override void Attack()
    {
        if(!isCurtain)
        {
            isCurtain = true;
            b = Instantiate(bullet, gm.player.transform);
            Vector3 temppos = gm.player.transform.position;
            b.att = weaponAtt;
            b.transform.position = temppos;
        }

    }
    public override void WeaponLevelUp()
    {
        level++;
        if (level >= 6)
        {
            level = 6;
        }
        switch (level)
        {
            case 2:
                cScale = 4;
                b.transform.localScale = new Vector3(cScale, cScale, 1);
                break;
            case 3:
                weaponAtt = 12;
                b.att = weaponAtt;
                break;
            case 4:
                cScale = 5;
                b.transform.localScale = new Vector3(cScale, cScale, 1);
                break;
            case 5:
                weaponAtt = 20;
                b.att = weaponAtt;
                break;
            case 6:
                cScale = 6;
                b.transform.localScale = new Vector3(cScale, cScale, 1);
                break;

        }
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/CurtainBullet");
        type = WeaponType.Curtain;
        isCurtain = false;
        level = 1;
        weaponAtt = 4;
        cScale = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
