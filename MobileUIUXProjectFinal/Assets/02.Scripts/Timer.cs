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
                // ���� �ð� ����
                limitedTime -= Time.deltaTime;
                // Ÿ�̸Ӱ� ������ ����
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
}
