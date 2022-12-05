using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseUI : MonoBehaviour
{
    GameManager gm;
    public GameObject pauseUi;
    public List<TextMeshProUGUI> levelText = new List<TextMeshProUGUI>();
    public void LevelUiUpdate()
    {
        int l = 0;
        for(int i = 0; i < gm.player.weapons.Count; i++)
        {
            switch (gm.player.weapons[i].type)
            {
                case Weapon.WeaponType.Normal:
                    l = gm.player.weapons[i].level;
                    levelText[0].text = $"Level {l}";
                    break;
                case Weapon.WeaponType.Explosion:
                    l = gm.player.weapons[i].level;
                    levelText[1].text = $"Level {l}";
                    break;
                case Weapon.WeaponType.Pierce:
                    l = gm.player.weapons[i].level;
                    levelText[2].text = $"Level {l}";
                    break;
                case Weapon.WeaponType.Curtain:
                    l = gm.player.weapons[i].level;
                    levelText[3].text = $"Level {l}";
                    break;
                case Weapon.WeaponType.Floor:
                    l = gm.player.weapons[i].level;
                    levelText[4].text = $"Level {l}";
                    break;
            }
        }
    }

    public void onClickPauseBtn()
    {
        pauseUi.SetActive(true);
        LevelUiUpdate();
        Time.timeScale = 0f;
    }

    public void onClickExitBtn()
    {
        //인트로씬으로 이동
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public void onClickCloseBtn()
    {
        pauseUi.SetActive(false);
        if (!gm.lu.isLevelUp)
        {
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
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
