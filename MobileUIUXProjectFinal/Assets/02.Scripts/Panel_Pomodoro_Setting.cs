using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Pomodoro_Setting : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pomodoroSettingTopPanel;
    [SerializeField] private GameObject pomodoroListPanel;
    [SerializeField] private GameObject pomodoroDataPanel;

    // Start is called before the first frame update
    void Awake()
    {
        pomodoroListPanel.SetActive(true);
        pomodoroDataPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnablePomodoroListPanel()
    {
        // �Ǹ𵵷� ����Ʈ �г� Ȱ��ȭ
        pomodoroListPanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        pomodoroDataPanel.SetActive(false);
    }

    public void EnablePomodoroDataPanel()
    {
        // �Ǹ𵵷� ������ �г� Ȱ��ȭ
        pomodoroDataPanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        pomodoroListPanel.SetActive(false);
    }
}
