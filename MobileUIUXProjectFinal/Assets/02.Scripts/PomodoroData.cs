using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PomodoroData : MonoBehaviour
{
    public List<Data> dataList = new List<Data>();
    private string pomodoroName;
    private PomodoroDataManager pomodoroDataManager;
    // content의 토글 그룹
    [SerializeField] private ToggleGroup contentToggleGroup;
    // Start is called before the first frame update
    void Start()
    {
        pomodoroDataManager = PomodoroDataManager.Instance;
        contentToggleGroup = GetComponentInParent<ToggleGroup>();
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

    public void AddPomodoroDataInManager()
    {
        pomodoroDataManager.AddPomodoroData(this);
        contentToggleGroup.allowSwitchOff = false;
    }

    public void RemovePomodoroDataInManger()
    {
        pomodoroDataManager.RemovePomodoroData(this);
        if(pomodoroDataManager.GetPomodoroDataCount() == 0)
        {
            contentToggleGroup.allowSwitchOff = true;
        }
        Destroy(this.gameObject);
    }

    
}
