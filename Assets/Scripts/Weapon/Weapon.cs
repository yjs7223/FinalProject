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
    public float weaponAtt;
    public int level;
    public int bulletnum;

    /// <summary>
    /// 레벨업 후 수치변경을 위한 함수
    /// </summary>
    public virtual void WeaponLevelUp()
    {
        Debug.Log("WeaponLevelUp");
    }

    /// <summary>
    /// 공격처리를 위한 함수
    /// </summary>
    public virtual void Attack()
    {
        Debug.Log("attack");
    }

    /// <summary>
    /// 무기추가를 위한 함수
    /// </summary>
    /// <param name="t">추가할 무기의 종류</param>
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
