using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 스톱워치와 타이머를 가지고 있는 타이머 클래스
public class Timer : MonoBehaviour
{
    private bool isOnTimer;         // 타이머가 켜져 있는지에 대한 여부
    private bool stopWatchMode;     // 스톱워치 모드(무한모드)인지에 대한 여부, false일시 타이머 모드
    private float accumulatedTime;  // 총 누적 시간
    private float limitedTime;        // 타이머모드에서의 제한 시간
    
    public float AccumulatedTime { get => accumulatedTime; set => accumulatedTime = value; }
    public bool IsOnTimer { get => isOnTimer; set => isOnTimer = value; }
    public float LimitedTime { get => limitedTime; set => limitedTime = value; }


    // Start is called before the first frame update
    void Awake()
    {
        isOnTimer = false;
        stopWatchMode = true;
        accumulatedTime = 0.0f;
        limitedTime = 500.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // 타이머가 켜져있을 경우
        if (isOnTimer)
        {
            // 스톱워치 모드가 활성화 상태일 경우, 즉 무한 공부 모드일 경우
            if (stopWatchMode)
            {
                // 누적 시간에 시간 추가
                accumulatedTime += Time.deltaTime;
            }
            // 타이머 모드일 경우
            else
            {
                // 제한 시간 감소
                limitedTime -= Time.deltaTime;
                // 타이머가 끝나면 종료
                if(limitedTime <= 0)
                {
                    limitedTime = 0;
                    isOnTimer = false;
                }
            }
        }
    }

    public void StartTimer()
    {
        isOnTimer = true;
    }

    public void StopTimer()
    {
        isOnTimer = false;
    }

    public void SetTimerMode()
    {
        stopWatchMode = false;
    }

    public void SetStopWatchMode()
    {
        stopWatchMode = true;
    }


    public string CauculateTime(float time)
    {
        // 전체 초에서 시간 계산
        int hours = (int)(time / 3600);
        // 나머지 초에서 분 계산
        int minutes = (int)((time % 3600) / 60);
        // 초 계산
        int seconds = (int)(time % 60);


        // 문자열 보간
        // D2: 숫자 서식화, 2자리만 보여주기
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
}
