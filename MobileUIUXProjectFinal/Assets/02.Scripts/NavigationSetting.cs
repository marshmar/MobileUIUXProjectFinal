using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSetting : MonoBehaviour
{
    private RectTransform nextViewRect;     // �������� �� view
    private NavigationView navigationView;  // navigation view ��ũ��Ʈ
    private Panel_Pomodoro_Setting panel_Pomodoro_Setting;

    // Start is called before the first frame update
    void Awake()
    {

        panel_Pomodoro_Setting = GetComponentInParent<Panel_Pomodoro_Setting>();
        navigationView = GetComponentInParent<NavigationView>();
        nextViewRect = panel_Pomodoro_Setting.pomodoroDataPanel.GetComponent<RectTransform>();
    }

    public void PushNavigation(bool value)
    {
        navigationView.Push(nextViewRect);
        panel_Pomodoro_Setting.setCreatingPomodoro(value);
        panel_Pomodoro_Setting.EnablePomodoroDataPanel();
    }

}
