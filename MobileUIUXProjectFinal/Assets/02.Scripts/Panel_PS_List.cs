using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PS_List : MonoBehaviour
{
    // 뽀모도로 데이터 생성 프리팹
    [SerializeField] private GameObject pomodoroDataPrefab;
    // 데이터를 생성할 content Transform
    [SerializeField] private Transform contentPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePomodoroData()
    {
        // 데이터 오브젝트 생성
        GameObject createdData = Instantiate(pomodoroDataPrefab, contentPanel);
        // 생성한 데이터를 가장 최상단으로 옮기기.
        createdData.transform.SetSiblingIndex(0);
    }
}
