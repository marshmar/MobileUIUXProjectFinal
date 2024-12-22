using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// �����ġ�� Ÿ�̸Ӹ� ������ �ִ� Ÿ�̸� Ŭ����
public class Timer : MonoBehaviour
{
    private bool isOnTimer;         // Ÿ�̸Ӱ� ���� �ִ����� ���� ����
    private bool stopWatchMode;     // �����ġ ���(���Ѹ��)������ ���� ����, false�Ͻ� Ÿ�̸� ���
    private float accumulatedTime;  // �� ���� �ð�
    private float limitedTime;        // Ÿ�̸Ӹ�忡���� ���� �ð�
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
        // Ÿ�̸Ӱ� �������� ���
        if (isOnTimer)
        {
            // �����ġ ��尡 Ȱ��ȭ ������ ���, �� ���� ���� ����� ���
            if (stopWatchMode)
            {
                // ���� �ð��� �ð� �߰�
                accumulatedTime += Time.deltaTime;
            }
            // Ÿ�̸� ����� ���
            else
            {
                if (PomodoroDataManager.Instance.CurrPomodoroData == null) return;
                // ���� �ð� ����
                limitedTime -= Time.deltaTime;
                accumulatedTime += Time.deltaTime;



                // Ÿ�̸Ӱ� ������ ����
                if (limitedTime <= 0)
                {
                    index++;    // ���� �ܰ�� ����
                    // ������ �ܰ谡 ���� �Ǿ��� ���
                    if (index > PomodoroDataManager.Instance.CurrPomodoroData.dataList.Count-1)
                    {
                        index = 0;
                        isOnTimer = false;
                        ClearTime();
                        // ���� �ܰ� �ִϸ��̼� ����
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

                    // ���� �ܰ� �ִϸ��̼� ���
                    panelMainScr.PlayCarouselAnim(index);
                    // ���� �ܰ� �ִϸ��̼� ����
                    int tempIndex = index - 1;
                    if (tempIndex < 0) tempIndex = PomodoroDataManager.Instance.CurrPomodoroData.dataList.Count-1;
                    panelMainScr.StopCarouselAnim(tempIndex);


                }
                // �̴� ������ ���� ����
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
        // ��ü �ʿ��� �ð� ���
        int hours = (int)(time / 3600);
        // ������ �ʿ��� �� ���
        int minutes = (int)((time % 3600) / 60);
        // �� ���
        int seconds = (int)(time % 60);


        // ���ڿ� ����
        // D2: ���� ����ȭ, 2�ڸ��� �����ֱ�
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
