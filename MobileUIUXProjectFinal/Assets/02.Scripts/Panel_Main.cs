using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Main : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject beforeInfinityStudyPanel;
    [SerializeField] private GameObject infinityStudyPanel;
    [SerializeField] private GameObject beforePomodoroPanel;
    [SerializeField] private GameObject pomodoroStudyPanel;
    [SerializeField] private GameObject pomodoroSettingPanel;

    [Header("Main Top Middle Bottm Contents")]
    [SerializeField] private GameObject mainTopPanel;
    [SerializeField] private GameObject mainMiddlePanel;
    [SerializeField] private GameObject panelMusic;
    [SerializeField] private GameObject mainBottomPanel;

    public void Awake()
    {
        // �� ���۽� ���� ���� ��� ȭ�鸸 ��Ƽ�� ����, ������ �г��� �ξ�Ƽ���
        beforeInfinityStudyPanel.SetActive(true);
        infinityStudyPanel.SetActive(false);
        beforePomodoroPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);
        panelMusic.SetActive(true);
        //pomodoroSettingPanel.SetActive(false);
        mainTopPanel.SetActive(true);
        mainMiddlePanel.SetActive(true);
        mainBottomPanel.SetActive(true);
    }

    // ���� ���� ��� ȭ������ ����
    public void EnalbeBeforeInfinityStudyPanel()
    {
        // ���� ���� ��� ȭ�� ��Ƽ��
        beforeInfinityStudyPanel.SetActive(true);

        // ������ �гε� �ξ�Ƽ��
        infinityStudyPanel.SetActive(false);        
        beforePomodoroPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);
    }

    // ���� ���� ȭ������ ����
    public void EnableInfinityStudyPanel()
    {
        // ���� ���� ȭ�� ��Ƽ��
        infinityStudyPanel.SetActive(true);

        // ������ �гε� �ξ�Ƽ��
        beforeInfinityStudyPanel.SetActive(false);   
        beforePomodoroPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);
    }

    // �Ǹ𵵷� ���ȭ������ ����
    public void EnableBeforePomodoroStudyPanel()
    {
        // �Ǹ𵵷� ��� ȭ�� ��Ƽ��
        beforePomodoroPanel.SetActive(true);   
        
        // ������ �гε� �ξ�Ƽ��
        infinityStudyPanel.SetActive(false);        
        beforeInfinityStudyPanel.SetActive(false);   
        pomodoroStudyPanel.SetActive(false);
        pomodoroSettingPanel.SetActive(false);

        // ���, �߰� ������ Ȱ��ȭ
        mainTopPanel.SetActive(true);
        mainMiddlePanel.SetActive(true);
        panelMusic.SetActive(true);
    }

    // �Ǹ𵵷� ����ȭ������ ����
    public void EnablePomodoroSettingPanel()
    {
        // �Ǹ𵵷� ���� ȭ�� ��Ƽ��
        pomodoroSettingPanel.SetActive(true);       
        
        // ������ �гε� �ξ�Ƽ��
        beforePomodoroPanel.SetActive(false);
        infinityStudyPanel.SetActive(false);
        beforeInfinityStudyPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);

        // ���, �߰� ������ ��Ȱ��ȭ
        mainTopPanel.SetActive(false);
        mainMiddlePanel.SetActive(false);
        panelMusic.SetActive(false);
    }
}
