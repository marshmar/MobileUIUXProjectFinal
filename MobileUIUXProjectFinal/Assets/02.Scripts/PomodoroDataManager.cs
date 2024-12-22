using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PomodoroDataManager : Singleton<PomodoroDataManager>
{
    private PomodoroData currPomodoroData;          // ���� ����ϴ� �Ǹ𵵷� ������
    public PomodoroData settingData;               // �����ϰ� �ִ� ������
    public List<PomodoroData> pomodoroDataList = new List<PomodoroData>();    // ��ü �Ǹ𵵷� ������ ����Ʈ
                                                                              // �Ǹ𵵷� ������ ���� ������
    [SerializeField] private GameObject pomodoroDataPrefab;
    // �����͸� ������ content Transform
    [SerializeField] private Transform contentPanel;
    // �����Ͱ� ����ִ� PomodoroSequence �г�
    [SerializeField] private Transform pomodoroSequencePanel;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private Panel_Main panelMainScr;
    public PomodoroData CurrPomodoroData { get => currPomodoroData; set
        {
            Debug.Log("�Ǹ𵵷� ������ ����");
            currPomodoroData = value;
            panelMainScr.ClearCarouselContents();
            panelMainScr.CreateCarouselContents(currPomodoroData);
            panelMainScr.EndTutorial();
        } 
    }

    public void AddPomodoroData()
    {
        // ���� �������� �Ǹ𵵷� �����͸� ����Ʈ�� ����
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
        // ������ ������Ʈ ����
        GameObject createdData = Instantiate(pomodoroDataPrefab, contentPanel);
        // ������ �����͸� ���� �ֻ������ �ű��.
        createdData.transform.SetSiblingIndex(0);
        // �����ϰ� �ִ� ������ ����
        settingData = createdData.GetComponent<PomodoroData>();
    }

    public void SaveDataToPomodoroData()
    {
        // ���� �����ϰ� �ִ� �����Ͱ� ������ return
        if (settingData == null) return;

        // ������ Ŭ���� �ϰ� �ٽ� �����ϱ�
        settingData.ClearData();

        // ������ �г��� �ڽļ� ��ŭ �ݺ�
        int childCount = pomodoroSequencePanel.childCount;
        for (int i = 0; i < childCount; i++)
        {
            // ������ �޾ƿ���
            IconData originalData = pomodoroSequencePanel.GetChild(i).GetComponent<IconData>();
            // Ŭ�� �Լ��� ���� ���纻 ����
            Data copiedData = originalData.data.Clone();
            // �����ϰ� �ִ� �Ǹ𵵷� �����Ϳ� ������ �ϳ��� �߰�
            settingData.AddData(copiedData);
        }

        // ���� ����
        if(inputField.text != "")
        {
            settingData.SetName(inputField.text);
            settingData.SetText();
        }

        // �̴� ������ �ʱ�ȭ
        settingData.DeleteSubIcons();

        // �̴� ������ ����
        settingData.CreateSubIcons();
        // ��ü �Ǹ𵵷� ������ ����Ʈ�� �Ǹ𵵷� ������ �߰�
        pomodoroDataList.Add(settingData);
        //settingData.EquipPomodoroData();
        settingData = null;
    }
}
