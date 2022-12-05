using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWeapon : Weapon
{
    public override void Attack()
    {
        attDelay += Time.deltaTime;
        if (attDelay >= attSpeed)
        {
            for (int i = 0; i < bulletnum; i++)
            {
                Debug.Log("floor attack");
                Bullet b = Instantiate(bullet);
                Vector3 temppos = transform.position;
                temppos.z = 0.1f;
                b.transform.position = temppos;
                b.GetComponent<FloorBullet>().fAtt = weaponAtt;
            }
            attDelay = 0;
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
                bulletnum = 2;
                break;
            case 3:
                weaponAtt = 9;
                break;
            case 4:
                bulletnum = 3;
                break;
            case 5:
                weaponAtt = 15;
                break;
            case 6:
                bulletnum = 4;
                break;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        if(bullet == null) 
        {
            bullet = Resources.Load<Bullet>("Prefabs/Bullet/FloorBullet");
        }
        
        type = WeaponType.Floor;
        
        attSpeed = 4f;
        attDelay = 0;
        bulletnum = 1;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
