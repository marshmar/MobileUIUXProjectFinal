using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroDataManager : Singleton<PomodoroDataManager>
{
    public PomodoroData currPomodoroData;          // 현재 사용하는 뽀모도로 데이터
    public PomodoroData settingData;               // 편집하고 있는 데이터
    public List<PomodoroData> pomodoroDataList = new List<PomodoroData>();    // 전체 뽀모도로 데이터 리스트

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
