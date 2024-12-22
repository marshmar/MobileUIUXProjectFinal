using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PomodoroDataSetter : MonoBehaviour
{
    [SerializeField] private RectTransform contentPanel;   // 데이터 정보가 있는 content 패널의 rectTransform

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
            // 데이터 받아오기
            Data originalData = contentPanel.GetChild(i).GetComponent<Data>();
            // 클론 함수를 통해 복사본 생성
            Data copiedData = originalData.Clone();

            pomodoroData.AddData(copiedData);
        }
    }
}
