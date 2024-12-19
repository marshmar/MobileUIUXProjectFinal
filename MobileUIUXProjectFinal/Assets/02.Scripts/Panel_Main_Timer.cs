using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ���� �г��� Ÿ�̸ӿ� ���õ� �κ��� ����ϴ� Ŭ����, Ÿ�̸� �ؽ�Ʈ�� �����Ѵ�.
public class Panel_Main_Timer : MonoBehaviour
{
    [SerializeField] private Timer timerScr;        // Ÿ�̸� ��ũ��Ʈ

    [Header("TimerText")]
    [SerializeField] private TMP_Text stopWatchText;    // ���� ���θ�� �ؽ�Ʈ 
    [SerializeField] private TMP_Text pomodoroText;     // �Ǹ𵵷� ��� �ؽ�Ʈ

    private void Update()
    {
        // Ÿ�̸Ӱ� �������� ���
        if (timerScr.IsOnTimer)
        {
            stopWatchText.text = timerScr.CauculateTime(timerScr.AccumulatedTime);
        }
    }
}
