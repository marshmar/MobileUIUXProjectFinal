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
        // 뽀모도로 리스트 패널 활성화
        pomodoroListPanel.SetActive(true);

        // 나머지 패널들 비활성화
        pomodoroDataPanel.SetActive(false);
    }

    public void EnablePomodoroDataPanel()
    {
        // 뽀모도로 데이터 패널 활성화
        pomodoroDataPanel.SetActive(true);

        // 나머지 패널들 비활성화
        pomodoroListPanel.SetActive(false);
    }
}
