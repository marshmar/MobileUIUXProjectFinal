using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PomodoroDataManager : Singleton<PomodoroDataManager>
{
    private PomodoroData currPomodoroData;          // 현재 사용하는 뽀모도로 데이터
    public PomodoroData settingData;               // 편집하고 있는 데이터
    public List<PomodoroData> pomodoroDataList = new List<PomodoroData>();    // 전체 뽀모도로 데이터 리스트
                                                                              // 뽀모도로 데이터 생성 프리팹
    [SerializeField] private GameObject pomodoroDataPrefab;
    // 데이터를 생성할 content Transform
    [SerializeField] private Transform contentPanel;
    // 데이터가 들어있는 PomodoroSequence 패널
    [SerializeField] private Transform pomodoroSequencePanel;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Panel_Main panelMainScr;
    public PomodoroData CurrPomodoroData { get => currPomodoroData; set
        {
            Debug.Log("뽀모도로 데이터 선택");
            currPomodoroData = value;
            panelMainScr.ClearCarouselContents();
            panelMainScr.CreateCarouselContents(currPomodoroData);
            panelMainScr.EndTutorial();
        } 
    }

    public void AddPomodoroData()
    {
        // 현재 세팅중인 뽀모도로 데이터를 리스트에 삽입
        pomodoroDataList.Add(settingData);
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

    public void CreatePomodoroData()
    {
        // 데이터 오브젝트 생성
        GameObject createdData = Instantiate(pomodoroDataPrefab, contentPanel);
        // 생성한 데이터를 가장 최상단으로 옮기기.
        createdData.transform.SetSiblingIndex(0);
        // 편집하고 있는 데이터 생성
        settingData = createdData.GetComponent<PomodoroData>();
    }

    public void SaveDataToPomodoroData()
    {
        // 현재 편집하고 있는 데이터가 없으면 return
        if (settingData == null) return;

        // 데이터 클리어 하고 다시 저장하기
        settingData.ClearData();

        // 시퀀스 패널의 자식수 만큼 반복
        int childCount = pomodoroSequencePanel.childCount;
        for (int i = 0; i < childCount; i++)
        {
            // 데이터 받아오기
            IconData originalData = pomodoroSequencePanel.GetChild(i).GetComponent<IconData>();
            // 클론 함수를 통해 복사본 생성
            Data copiedData = originalData.data.Clone();
            // 편집하고 있는 뽀모도로 데이터에 데이터 하나씩 추가
            settingData.AddData(copiedData);
        }

        // 제목 저장
        if(inputField.text != "")
        {
            settingData.SetName(inputField.text);
            settingData.SetText();
        }

        // 미니 아이콘 초기화
        settingData.DeleteSubIcons();

        // 미니 아이콘 생성
        settingData.CreateSubIcons();
        // 전체 뽀모도로 데이터 리스트에 뽀모도로 데이터 추가
        pomodoroDataList.Add(settingData);
        //settingData.EquipPomodoroData();
        settingData = null;
    }
}
