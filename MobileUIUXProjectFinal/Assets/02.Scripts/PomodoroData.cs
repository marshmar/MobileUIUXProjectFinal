using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroData : MonoBehaviour
{
    private List<Data> dataList = new List<Data>();
    private string pomodoroName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddData(Data data)
    {
        dataList.Add(data);
    }

    public void ClearData()
    {
        dataList.Clear();
    }

    public void RemoveData(Data data)
    {
        dataList.Remove(data);
    }
    public void SetName(string text)
    {
        pomodoroName = text;
    }
}
