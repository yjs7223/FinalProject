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
                            fItemName.text = "�Ϲ� ź��";
                            fItemDemo.text = "����ӵ��� ���� �Ϲ����� ź���̴�";
                            break;
                        case Weapon.WeaponType.Explosion:
                            fItemName.text = "���� ź��";
                            fItemDemo.text = "������ �����ϸ� ������ �����Ѵ�";
                            break;
                        case Weapon.WeaponType.Pierce:
                            fItemName.text = "���� ź��";
                            fItemDemo.text = "���� �����ϰ� ȭ�鿡 �ε����� ƨ���";
                            break;
                        case Weapon.WeaponType.Curtain:
                            fItemName.text = "�帷";
                            fItemDemo.text = "���� �帷�� ������ ������ �������� �Դ´�";
                            break;
                        case Weapon.WeaponType.Floor:
                            fItemName.text = "���� ź��";
                            fItemDemo.text = "�ٴڿ� ������ �������� �ִ� ������ �����Ѵ�";
                            break;
                    }
                    break;
                case 1:
                    switch (second)
                    {
                        case Weapon.WeaponType.Normal:
                            sItemName.text = "�Ϲ� ź��";
                            sItemDemo.text = "����ӵ��� ���� �Ϲ����� ź���̴�";
                            break;
                        case Weapon.WeaponType.Explosion:
                            sItemName.text = "���� ź��";
                            sItemDemo.text = "������ �����ϸ� ������ �����Ѵ�";
                            break;
                        case Weapon.WeaponType.Pierce:
                            sItemName.text = "���� ź��";
                            sItemDemo.text = "���� �����ϰ� ȭ�鿡 �ε����� ƨ���";
                            break;
                        case Weapon.WeaponType.Curtain:
                            sItemName.text = "�帷";
                            sItemDemo.text = "���� �帷�� ������ ������ �������� �Դ´�";
                            break;
                        case Weapon.WeaponType.Floor:
                            sItemName.text = "���� ź��";
                            sItemDemo.text = "�ٴڿ� ������ �������� �ִ� ������ �����Ѵ�";
                            break;
                    }
                    break;
                case 2:
                    switch (third)
                    {
                        case Weapon.WeaponType.Normal:
                            tItemName.text = "�Ϲ� ź��";
                            tItemDemo.text = "����ӵ��� ���� �Ϲ����� ź���̴�";
                            break;
                        case Weapon.WeaponType.Explosion:
                            tItemName.text = "���� ź��";
                            tItemDemo.text = "������ �����ϸ� ������ �����Ѵ�";
                            break;
                        case Weapon.WeaponType.Pierce:
                            tItemName.text = "���� ź��";
                            tItemDemo.text = "���� �����ϰ� ȭ�鿡 �ε����� ƨ���";
                            break;
                        case Weapon.WeaponType.Curtain:
                            tItemName.text = "�帷";
                            tItemDemo.text = "���� �帷�� ������ ������ �������� �Դ´�";
                            break;
                        case Weapon.WeaponType.Floor:
                            tItemName.text = "���� ź��";
                            tItemDemo.text = "�ٴڿ� ������ �������� �ִ� ������ �����Ѵ�";
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
