using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameManager gm;
    /// <summary>
    /// ≈∫∏∑¿« ¡æ∑˘
    /// 0¿œπ›,1∆¯∆»,2∞¸≈Î,3¿Â∏∑,4¿Â∆«
    /// </summary>
    public enum WeaponType
    {
        Normal = 1,
        Explosion,
        Pierce,
        Curtain,
        Floor,

        MAX
    }

    public Bullet bullet;
    public WeaponType type;
    public float attSpeed;
    public float attDelay;
    public int level;

    public virtual void Attack()
    {
        Debug.Log("attack");
    }

    public static void AddWeapon(WeaponType t)
    {
        switch (t)
        {
            case WeaponType.Normal:
                GameManager.GetInstance().player.weapons.Add(
            Instantiate(Resources.Load<Weapon>("Prefabs/Weapon/NormalWeapon"),
            GameManager.GetInstance().player.transform));
                break;
            case WeaponType.Explosion:
                GameManager.GetInstance().player.weapons.Add(
            Instantiate(Resources.Load<Weapon>("Prefabs/Weapon/ExplosionWeapon"),
            GameManager.GetInstance().player.transform));
                break;
            case WeaponType.Pierce:
                GameManager.GetInstance().player.weapons.Add(
            Instantiate(Resources.Load<Weapon>("Prefabs/Weapon/PierceWeapon"),
            GameManager.GetInstance().player.transform));
                break;
            case WeaponType.Curtain:
                GameManager.GetInstance().player.weapons.Add(
            Instantiate(Resources.Load<Weapon>("Prefabs/Weapon/CurtainWeapon"),
            GameManager.GetInstance().player.transform));
                break;
            case WeaponType.Floor:
                GameManager.GetInstance().player.weapons.Add(
            Instantiate(Resources.Load<Weapon>("Prefabs/Weapon/FloorWeapon"),
            GameManager.GetInstance().player.transform));
                break;
        }
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
