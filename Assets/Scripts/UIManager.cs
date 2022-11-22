using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameManager gm;
    public TextMeshProUGUI levelText;
    public Slider expSlider;
    public TextMeshProUGUI TimerText;

    public void UIUpdate()
    {
        levelText.text = gm.player.level.ToString();
        if(gm.player.exp == 0)
        {
            expSlider.fillRect.gameObject.SetActive(false);
        }
        else
        {
            expSlider.fillRect.gameObject.SetActive(true);
        }
        expSlider.value = gm.player.exp / 10;

        //시간만들기
    }

    void Start()
    {
        gm = GameManager.GetInstance();
        gm.uim = this;
    }

    void Update()
    {
        UIUpdate();
    }
}
