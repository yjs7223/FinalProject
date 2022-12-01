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
            Debug.Log("floor attack");
            Bullet b = Instantiate(bullet);
            Vector3 temppos = transform.position;
            temppos.z = 0.1f;
            b.transform.position = temppos;
            attDelay = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
        bullet = Resources.Load<Bullet>("Prefabs/Bullet/FloorBullet");
        type = WeaponType.Floor;
        
        attSpeed = 4f;
        attDelay = 0;
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
