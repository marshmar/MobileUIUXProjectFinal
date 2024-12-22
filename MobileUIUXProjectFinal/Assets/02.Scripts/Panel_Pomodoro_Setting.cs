using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Panel_Pomodoro_Setting : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject pomodoroSettingTopPanel;
    [SerializeField] private GameObject pomodoroListPanel;
    [SerializeField] public GameObject pomodoroDataPanel;
    [SerializeField] private Transform pomodoroSequencePanel;

    [Header("Top Texts")]
    [SerializeField] private TMP_Text titleText;

    [Header("Buttons")]
    [SerializeField] private GameObject createButton;
    [SerializeField] private GameObject saveButton;

    private bool isCreatingPomodoro;
    // Start is called before the first frame update
    void Awake()
    {
        pomodoroListPanel.SetActive(true);
        pomodoroDataPanel.SetActive(false);
        isCreatingPomodoro = false;
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

        // 상단 텍스트 설정
        if (isCreatingPomodoro) // 뽀모도로 생성 창일 경우
        {
            SetTitleText("뽀모도로 생성");
            createButton.SetActive(true);
            saveButton.SetActive(false);
        }
        else
        {
            SetTitleText("뽀모도로 설정");
            createButton.SetActive(false);
            saveButton.SetActive(true);
        }


    }

    public void SetTitleText(string text)
    {
        titleText.text = text;
    }

    public void setCreatingPomodoro(bool value)
    {
        isCreatingPomodoro = value;
    }

    public void ClearPomodoroDataPanel()
    {
        foreach (Transform child in pomodoroSequencePanel)
        {
            Destroy(child.gameObject);
        }
    }

}
