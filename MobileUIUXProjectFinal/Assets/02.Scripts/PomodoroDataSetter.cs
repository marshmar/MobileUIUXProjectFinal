using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroDataSetter : MonoBehaviour
{
    [SerializeField] private RectTransform contentPanel;   // ������ ������ �ִ� content �г��� rectTransform

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddAllDataToPomodoroData(PomodoroData pomodoroData)
    {
        int childCount = contentPanel.childCount;
        for(int i = 0; i < childCount; i++)
        {
            // ������ �޾ƿ���
            Data originalData = contentPanel.GetChild(i).GetComponent<Data>();
            // Ŭ�� �Լ��� ���� ���纻 ����
            Data copiedData = originalData.Clone();

            pomodoroData.AddData(copiedData);
        }
    }
}
