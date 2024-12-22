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

        // ��� �ؽ�Ʈ ����
        if (isCreatingPomodoro) // �Ǹ𵵷� ���� â�� ���
        {
            SetTitleText("�Ǹ𵵷� ����");
            createButton.SetActive(true);
            saveButton.SetActive(false);
        }
        else
        {
            SetTitleText("�Ǹ𵵷� ����");
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
