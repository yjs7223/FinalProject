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

    public void levelUp()
    {
        Time.timeScale = 0;
        levelUpUi.SetActive(true);

        first = (Weapon.WeaponType)Random.Range(1, 6);
        second = (Weapon.WeaponType)Random.Range(1, 6);
        while (first != second)
        {
            second = (Weapon.WeaponType)Random.Range(1, 6);
        }
        third = (Weapon.WeaponType)Random.Range(1, 6);
        while(first != third && second != third)
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
                            fItemDemo.text = "연사속도가 빠른 일반적인 탄막이다";
                            break;
                        case Weapon.WeaponType.Explosion:
                            fItemName.text = "폭발 탄막";
                            fItemDemo.text = "적에게 적중하면 주위에 폭발한다";
                            break;
                        case Weapon.WeaponType.Pierce:
                            fItemName.text = "관통 탄막";
                            fItemDemo.text = "적을 관통하고 화면에 부딛히면 튕긴다";
                            break;
                        case Weapon.WeaponType.Curtain:
                            fItemName.text = "장막";
                            fItemDemo.text = "적이 장막의 범위에 들어오면 데미지를 입는다";
                            break;
                        case Weapon.WeaponType.Floor:
                            fItemName.text = "장판 탄막";
                            fItemDemo.text = "바닥에 범위형 데미지를 주는 장판을 생성한다";
                            break;
                    }
                    break;
                case 1:
                    switch (second)
                    {
                        case Weapon.WeaponType.Normal:
                            sItemName.text = "일반 탄막";
                            sItemDemo.text = "연사속도가 빠른 일반적인 탄막이다";
                            break;
                        case Weapon.WeaponType.Explosion:
                            sItemName.text = "폭발 탄막";
                            sItemDemo.text = "적에게 적중하면 주위에 폭발한다";
                            break;
                        case Weapon.WeaponType.Pierce:
                            sItemName.text = "관통 탄막";
                            sItemDemo.text = "적을 관통하고 화면에 부딛히면 튕긴다";
                            break;
                        case Weapon.WeaponType.Curtain:
                            sItemName.text = "장막";
                            sItemDemo.text = "적이 장막의 범위에 들어오면 데미지를 입는다";
                            break;
                        case Weapon.WeaponType.Floor:
                            sItemName.text = "장판 탄막";
                            sItemDemo.text = "바닥에 범위형 데미지를 주는 장판을 생성한다";
                            break;
                    }
                    break;
                case 2:
                    switch (third)
                    {
                        case Weapon.WeaponType.Normal:
                            tItemName.text = "일반 탄막";
                            tItemDemo.text = "연사속도가 빠른 일반적인 탄막이다";
                            break;
                        case Weapon.WeaponType.Explosion:
                            tItemName.text = "폭발 탄막";
                            tItemDemo.text = "적에게 적중하면 주위에 폭발한다";
                            break;
                        case Weapon.WeaponType.Pierce:
                            tItemName.text = "관통 탄막";
                            tItemDemo.text = "적을 관통하고 화면에 부딛히면 튕긴다";
                            break;
                        case Weapon.WeaponType.Curtain:
                            tItemName.text = "장막";
                            tItemDemo.text = "적이 장막의 범위에 들어오면 데미지를 입는다";
                            break;
                        case Weapon.WeaponType.Floor:
                            tItemName.text = "장판 탄막";
                            tItemDemo.text = "바닥에 범위형 데미지를 주는 장판을 생성한다";
                            break;
                    }
                    break;
            }
        }

    }
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    void Update()
    {
        
    }
}
