using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PS_List : MonoBehaviour
{
    // �Ǹ𵵷� ������ ���� ������
    [SerializeField] private GameObject pomodoroDataPrefab;
    // �����͸� ������ content Transform
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
        // ������ ������Ʈ ����
        GameObject createdData = Instantiate(pomodoroDataPrefab, contentPanel);
        // ������ �����͸� ���� �ֻ������ �ű��.
        createdData.transform.SetSiblingIndex(0);
    }
}
