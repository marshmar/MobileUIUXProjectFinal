using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ���� �г��� Ÿ�̸ӿ� ���õ� �κ��� ����ϴ� Ŭ����, Ÿ�̸� �ؽ�Ʈ�� �����Ѵ�.
public class Panel_Main_Timer : MonoBehaviour
{
    [SerializeField] private Timer timerScr;        // Ÿ�̸� ��ũ��Ʈ

    [Header("TimerText")]
    [SerializeField] private TMP_Text Timertext;    // Ÿ�̸� �ؽ�Ʈ 

    private void Update()
    {
        // Ÿ�̸Ӱ� �������� ���
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
