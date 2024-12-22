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
    private int index;
    private int lastIndex;
    public float AccumulatedTime { get => accumulatedTime; set => accumulatedTime = value; }
    public bool IsOnTimer { get => isOnTimer; set => isOnTimer = value; }
    public float LimitedTime { get => limitedTime; set => limitedTime = value; }
    public bool StopWatchMode { get => stopWatchMode; set => stopWatchMode = value; }

    [SerializeField] private Panel_Main panelMainScr;
    [SerializeField] private Panel_Main_Timer panel_Main_Timer;
    [SerializeField] private PanelMainTopController panelMainTopController;
    [SerializeField] private FadeOnIdle panelMusicIdle;
    // Start is called before the first frame update
    void Awake()
    {
        isOnTimer = false;
        stopWatchMode = true;
        accumulatedTime = 0.0f;
        limitedTime = 0.0f;
        index = 0;
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
                if (PomodoroDataManager.Instance.CurrPomodoroData == null) return;
                // 제한 시간 감소
                limitedTime -= Time.deltaTime;
                accumulatedTime += Time.deltaTime;



                // 타이머가 끝나면 종료
                if (limitedTime <= 0)
                {
                    index++;    // 다음 단계로 변경
                    // 마지막 단계가 종료 되었을 경우
                    if (index > PomodoroDataManager.Instance.CurrPomodoroData.dataList.Count-1)
                    {
                        index = 0;
                        isOnTimer = false;
                        ClearTime();
                        // 이전 단계 애니메이션 끄기
                        int tmpIndex = index - 1;
                        if (tmpIndex < 0) tmpIndex = PomodoroDataManager.Instance.CurrPomodoroData.dataList.Count - 1;
                        panelMainScr.StopCarouselAnim(tmpIndex);
                        panelMainScr.SetCarouselIndex(index);
                        panelMusicIdle.SetFadable(false);
                        panelMusicIdle.OnClickDetected();
                        panelMainTopController.EnableStudyModeButton();
                        panelMainScr.EnableBeforePomodoroStudyPanel();
                        panelMainScr.ResetMiniIconTransparency();
                        return;
                    }
                    limitedTime = PomodoroDataManager.Instance.CurrPomodoroData.dataList[index].time;
                    panelMainScr.SetCarouselIndex(index);

                    // 현재 단계 애니메이션 재생
                    panelMainScr.PlayCarouselAnim(index);
                    // 이전 단계 애니메이션 끄기
                    int tempIndex = index - 1;
                    if (tempIndex < 0) tempIndex = PomodoroDataManager.Instance.CurrPomodoroData.dataList.Count-1;
                    panelMainScr.StopCarouselAnim(tempIndex);


                }
                // 미니 아이콘 투명도 설정
                float alpha = Mathf.Max(0.15f, 1 - (limitedTime / PomodoroDataManager.Instance.CurrPomodoroData.dataList[index].time));
                panelMainScr.SetMiniIconTransparency(index, alpha);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                limitedTime -= 10.0f;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                limitedTime -= 60.0f;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                limitedTime -= 300.0f;
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
        if (PomodoroDataManager.Instance.CurrPomodoroData == null) return;
        limitedTime = PomodoroDataManager.Instance.CurrPomodoroData.dataList[index].time;
        panel_Main_Timer.SetStopWatchText();
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

    public void ClearIndex()
    {
        index = 0;
    }

    public void PlayAnimInIndex()
    {
        panelMainScr.PlayCarouselAnim(index);
    }

    public void StopAnimInIndex()
    {
        panelMainScr.StopCarouselAnim(index);   
    }

    public void ClearTime()
    {
        limitedTime = limitedTime = PomodoroDataManager.Instance.CurrPomodoroData.dataList[index].time;
        panel_Main_Timer.SetStopWatchText();
    }
}
