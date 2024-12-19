using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroDataManager : Singleton<PomodoroDataManager>
{
    public PomodoroData currPomodoroData;          // ���� ����ϴ� �Ǹ𵵷� ������
    public PomodoroData settingData;               // �����ϰ� �ִ� ������
    public List<PomodoroData> pomodoroDataList = new List<PomodoroData>();    // ��ü �Ǹ𵵷� ������ ����Ʈ

    public void AddPomodoroData(PomodoroData pomodoroData)
    {
        pomodoroDataList.Add(pomodoroData);
    }

    public void RemovePomodoroData(PomodoroData pomodoroData)
    {
        pomodoroDataList.Remove(pomodoroData);
    }

    public void ClearPomodoroData()
    {
        pomodoroDataList.Clear();
    }

    public int GetPomodoroDataCount()
    {
        return pomodoroDataList.Count;
    }
}
