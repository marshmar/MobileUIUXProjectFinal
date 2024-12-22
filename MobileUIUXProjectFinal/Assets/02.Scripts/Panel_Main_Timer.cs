using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 메인 패널의 타이머와 관련된 부분을 담당하는 클래스, 타이머 텍스트를 설정한다.
public class Panel_Main_Timer : MonoBehaviour
{
    [SerializeField] private Timer timerScr;        // 타이머 스크립트

    [Header("TimerText")]
    [SerializeField] private TMP_Text Timertext;    // 타이머 텍스트 

    private void Update()
    {
        // 타이머가 켜져있을 경우
        if (timerScr.IsOnTimer)
        {
            if (timerScr.StopWatchMode)
            {
                SetAccoumText();
            }

            else
            {
                SetStopWatchText();
            }
        }
    }

    public void SetAccoumText()
    {
        Timertext.text = timerScr.CauculateTime(timerScr.AccumulatedTime);
        if (ColorUtility.TryParseHtmlString("#D58936", out Color color))
        {
            Timertext.color = color;
        }
    }

    public void SetStopWatchText()
    {
        Timertext.text = timerScr.CauculateTime(timerScr.LimitedTime);
        if (timerScr.LimitedTime >= 60.0f)
        {
            if (ColorUtility.TryParseHtmlString("#f2f3ae", out Color color1))
            {
                Timertext.color = color1;
            }
        }
        else
        {
            if (ColorUtility.TryParseHtmlString("#69140e", out Color color2))
            {
                Timertext.color = color2;
            }
        }
    }
}
