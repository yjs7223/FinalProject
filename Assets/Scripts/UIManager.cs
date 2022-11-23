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

    public float nowtime;
    public float oldtime;
    public int second;
    public int minute;

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

        //�ð������
        TimeCheck();
        //�ؽ�Ʈ ����(���� ����(00:00))
        if(second < 10)
        {
            if(minute < 10)
            {
                TimerText.text = $"0{minute}:0{second}";
            }
            else
            {
                TimerText.text = $"{minute}:0{second}";
            }
        }
        else
        {
            if (minute < 10)
            {
                TimerText.text = $"0{minute}:{second}";
            }
            else
            {
                TimerText.text = $"{minute}:{second}";
            }
        }
    }

    public void TimeCheck()
    {
        nowtime += Time.deltaTime;
        if((nowtime - oldtime) > 1)
        {
            oldtime = nowtime;
            second++;
            if(second == 60)
            {
                minute++;
                second = 0;
            }
        }

    }

    void Start()
    {
        gm = GameManager.GetInstance();
        gm.uim = this;
        nowtime = 0;
        oldtime = 0;
        second = 0;
        minute = 0;
    }

    void Update()
    {
        UIUpdate();
    }
}
