using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 메인 패널의 타이머와 관련된 부분을 담당하는 클래스, 타이머 텍스트를 설정한다.
public class Panel_Main_Timer : MonoBehaviour
{
    [SerializeField] private Timer timerScr;        // 타이머 스크립트

    [Header("TimerText")]
    [SerializeField] private TMP_Text stopWatchText;    // 무한 공부모드 텍스트 
    [SerializeField] private TMP_Text pomodoroText;     // 뽀모도로 모드 텍스트

    private void Update()
    {
        // 타이머가 켜져있을 경우
        if (timerScr.IsOnTimer)
        {
            stopWatchText.text = timerScr.CauculateTime(timerScr.AccumulatedTime);
        }
    }
}
