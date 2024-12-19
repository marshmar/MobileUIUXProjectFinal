using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroDataManager : MonoBehaviour
{
    public PomodoroData currPomodoroData;          // ���� ����ϴ� �Ǹ𵵷� ������
    public List<PomodoroData> pomodoroDataList = new List<PomodoroData>();    // ��ü �Ǹ𵵷� ������ ����Ʈ
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
