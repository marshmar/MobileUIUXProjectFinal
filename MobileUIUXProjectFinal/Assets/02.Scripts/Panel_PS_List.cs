using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel_PS_List : MonoBehaviour
{
    [SerializeField] private Panel_Pomodoro_Setting panel_Pomodoro_Setting;

    private void OnEnable()
    {
        panel_Pomodoro_Setting.SetTitleText("�Ǹ𵵷� ���");
        PomodoroDataManager.Instance.settingData = null;
    }
}
