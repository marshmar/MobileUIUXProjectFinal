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
        // 앱 시작시 무한 공부 대기 화면만 액티브 설정, 나머지 패널은 인액티브로
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

    // 무한 공부 대기 화면으로 세팅
    public void EnalbeBeforeInfinityStudyPanel()
    {
        // 무한 공부 대기 화면 액티브
        beforeInfinityStudyPanel.SetActive(true);

        // 나머지 패널들 인액티브
        infinityStudyPanel.SetActive(false);        
        beforePomodoroPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);
    }

    // 무한 공부 화면으로 세팅
    public void EnableInfinityStudyPanel()
    {
        // 무한 공부 화면 액티브
        infinityStudyPanel.SetActive(true);

        // 나머지 패널들 인액티브
        beforeInfinityStudyPanel.SetActive(false);   
        beforePomodoroPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);
    }

    // 뽀모도로 대기화면으로 세팅
    public void EnableBeforePomodoroStudyPanel()
    {
        // 뽀모도로 대기 화면 액티브
        beforePomodoroPanel.SetActive(true);   
        
        // 나머지 패널들 인액티브
        infinityStudyPanel.SetActive(false);        
        beforeInfinityStudyPanel.SetActive(false);   
        pomodoroStudyPanel.SetActive(false);
        pomodoroSettingPanel.SetActive(false);

        // 상단, 중간 컨텐츠 활성화
        mainTopPanel.SetActive(true);
        mainMiddlePanel.SetActive(true);
        panelMusic.SetActive(true);
    }

    // 뽀모도로 설정화면으로 세팅
    public void EnablePomodoroSettingPanel()
    {
        // 뽀모도로 설정 화면 액티브
        pomodoroSettingPanel.SetActive(true);       
        
        // 나머지 패널들 인액티브
        beforePomodoroPanel.SetActive(false);
        infinityStudyPanel.SetActive(false);
        beforeInfinityStudyPanel.SetActive(false);
        pomodoroStudyPanel.SetActive(false);

        // 상단, 중간 컨텐츠 비활성화
        mainTopPanel.SetActive(false);
        mainMiddlePanel.SetActive(false);
        panelMusic.SetActive(false);
    }
}
