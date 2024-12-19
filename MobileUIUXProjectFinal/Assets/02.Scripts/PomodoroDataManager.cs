using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroDataManager : MonoBehaviour
{
    public PomodoroData currPomodoroData;          // 현재 사용하는 뽀모도로 데이터
    public List<PomodoroData> pomodoroDataList = new List<PomodoroData>();    // 전체 뽀모도로 데이터 리스트
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
