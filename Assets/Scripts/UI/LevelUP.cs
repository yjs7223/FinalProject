using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUP : MonoBehaviour
{
    GameManager gm;
    public GameObject levelUpUi;

    public Weapon.WeaponType first;
    public Weapon.WeaponType second;
    public Weapon.WeaponType third;

    public TextMeshProUGUI fItemName;
    public TextMeshProUGUI sItemName;
    public TextMeshProUGUI tItemName;

    public TextMeshProUGUI fItemDemo;
    public TextMeshProUGUI sItemDemo;
    public TextMeshProUGUI tItemDemo;

    public bool isLevelUp;

    public void levelUp()
    {
        Time.timeScale = 0;
        levelUpUi.SetActive(true);
        isLevelUp = true;
        gm.ec.createDelay = (30 - gm.player.level) / 10;

        first = (Weapon.WeaponType)Random.Range(1, 6);

        second = (Weapon.WeaponType)Random.Range(1, 6);
        while (first == second)
        {
            second = (Weapon.WeaponType)Random.Range(1, 6);
        }

        third = (Weapon.WeaponType)Random.Range(1, 6);
        while(first == third || second == third)
        {
            third = (Weapon.WeaponType)Random.Range(1, 6);
        }

        for(int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    switch (first)
                    {
                        case Weapon.WeaponType.Normal:
                            fItemName.text = "일반 탄막";
                            fItemDemo.text = "연사속도가 빠른 \n일반적인 탄막이다";
                            break;
                        case Weapon.WeaponType.Explosion:
                            fItemName.text = "폭발 탄막";
                            fItemDemo.text = "적에게 적중하면 \n주위에 폭발데미지를 준다";
                            break;
                        case Weapon.WeaponType.Pierce:
                            fItemName.text = "관통 탄막";
                            fItemDemo.text = "적을 관통하고 \n화면에 부딛히면 튕긴다";
                            break;
                        case Weapon.WeaponType.Curtain:
                            fItemName.text = "장막";
                            fItemDemo.text = "적이 장막의 범위에 들어오면 \n데미지를 입는다";
                            break;
                        case Weapon.WeaponType.Floor:
                            fItemName.text = "장판 탄막";
                            fItemDemo.text = "바닥에 범위형 데미지를 주는 \n장판을 생성한다";
                            break;
                    }
                    break;
                case 1:
                    switch (second)
                    {
                        case Weapon.WeaponType.Normal:
                            sItemName.text = "일반 탄막";
                            sItemDemo.text = "연사속도가 빠른 \n일반적인 탄막이다";
                            break;
                        case Weapon.WeaponType.Explosion:
                            sItemName.text = "폭발 탄막";
                            sItemDemo.text = "적에게 적중하면 \n주위에 폭발데미지를 준다";
                            break;
                        case Weapon.WeaponType.Pierce:
                            sItemName.text = "관통 탄막";
                            sItemDemo.text = "적을 관통하고 \n화면에 부딛히면 튕긴다";
                            break;
                        case Weapon.WeaponType.Curtain:
                            sItemName.text = "장막";
                            sItemDemo.text = "적이 장막의 범위에 들어오면 \n데미지를 입는다";
                            break;
                        case Weapon.WeaponType.Floor:
                            sItemName.text = "장판 탄막";
                            sItemDemo.text = "바닥에 범위형 데미지를 주는 \n장판을 생성한다";
                            break;
                    }
                    break;
                case 2:
                    switch (third)
                    {
                        case Weapon.WeaponType.Normal:
                            tItemName.text = "일반 탄막";
                            tItemDemo.text = "연사속도가 빠른 \n일반적인 탄막이다";
                            break;
                        case Weapon.WeaponType.Explosion:
                            tItemName.text = "폭발 탄막";
                            tItemDemo.text = "적에게 적중하면 \n주위에 폭발데미지를 준다";
                            break;
                        case Weapon.WeaponType.Pierce:
                            tItemName.text = "관통 탄막";
                            tItemDemo.text = "적을 관통하고 \n화면에 부딛히면 튕긴다";
                            break;
                        case Weapon.WeaponType.Curtain:
                            tItemName.text = "장막";
                            tItemDemo.text = "적이 장막의 범위에 들어오면 \n데미지를 입는다";
                            break;
                        case Weapon.WeaponType.Floor:
                            tItemName.text = "장판 탄막";
                            tItemDemo.text = "바닥에 범위형 데미지를 주는 \n장판을 생성한다";
                            break;
                    }
                    break;
            }
        }

    }

    /// <summary>
    /// 첫번째 버튼 클릭
    /// </summary>
    public void onClickfiButton()
    {
        bool ishave = false;
        int wpnum = -1;
        for(int i = 0; i < gm.player.weapons.Count; i++)
        {
            if(gm.player.weapons[i].type == first)
            {
                ishave = true;
                wpnum = i;
            }
        }

        if(ishave)
        {
            gm.player.weapons[wpnum].WeaponLevelUp();
        }
        else
        {
            Weapon.AddWeapon(first);
        }
        levelUpUi.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        isLevelUp = false;
    }

    /// <summary>
    /// 두번째 버튼 클릭
    /// </summary>
    public void onClicksiButton()
    {
        bool ishave = false;
        int wpnum = -1;
        for (int i = 0; i < gm.player.weapons.Count; i++)
        {
            if (gm.player.weapons[i].type == second)
            {
                ishave = true;
                wpnum = i;
            }
        }

        if (ishave)
        {
            gm.player.weapons[wpnum].WeaponLevelUp();
        }
        else
        {
            Weapon.AddWeapon(second);
        }
        levelUpUi.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        isLevelUp = false;
    }

    /// <summary>
    /// 세번째 버튼 클릭
    /// </summary>
    public void onClicktiButton()
    {
        bool ishave = false;
        int wpnum = -1;
        for (int i = 0; i < gm.player.weapons.Count; i++)
        {
            if (gm.player.weapons[i].type == third)
            {
                ishave = true;
                wpnum = i;
            }
        }

        if (ishave)
        {
            gm.player.weapons[wpnum].WeaponLevelUp();
        }
        else
        {
            Weapon.AddWeapon(third);
        }
        levelUpUi.SetActive(false);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
        isLevelUp = false;
    }

    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        
    }
}
