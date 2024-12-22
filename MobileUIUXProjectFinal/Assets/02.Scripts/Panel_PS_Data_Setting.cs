using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LottiePlugin.UI;

public class Panel_PS_Data_Setting : MonoBehaviour
{
    [SerializeField] private Transform pomodoroSequencePanel;
    [SerializeField] private Transform pomodoroDatasPanel;
    [SerializeField] private GameObject[] pomodoroDataPrefabs;
    [SerializeField] private TMP_InputField titleText;
    [SerializeField] private GameObject descriptionText;
    [SerializeField] private GameObject bottomBar;
    private void OnEnable()
    {
        ClearPomodoroSequencePanel();
        SetPomodoroSequencePanel();
        SetTitleText();
        PlayAnim();
    }

    private void Update()
    {
        if(pomodoroSequencePanel.childCount > 0)
        {
            descriptionText.SetActive(false);
            bottomBar.SetActive(true);
        }
        else
        {
            descriptionText.SetActive(true);
            bottomBar.SetActive(false);
        }
    }
    private void PlayAnim()
    {
        AnimatedImage[] anims = pomodoroDatasPanel.GetComponentsInChildren<AnimatedImage>();
        if (anims.Length < 1) return;

        foreach (AnimatedImage anim in anims)
        {
            anim.Play();
        }
    }

    private void SetTitleText()
    {
        // settingData가 null이면 생성중이라는 이야기니까 기본적인 문자열로
        if (PomodoroDataManager.Instance.settingData == null) 
        {
            titleText.text = "";
        }
        else
        {
            titleText.text = PomodoroDataManager.Instance.settingData.pomodoroName;
        }

    }

    private void SetPomodoroSequencePanel()
    {
        if (PomodoroDataManager.Instance.settingData == null) return;
        foreach (Data data in PomodoroDataManager.Instance.settingData.dataList)
        {
            switch (data.type)
            {
                case TYPE.SHORTSTUDY:
                    Instantiate(pomodoroDataPrefabs[0], pomodoroSequencePanel);
                    break;
                case TYPE.LONGSTUDY:
                    Instantiate(pomodoroDataPrefabs[1], pomodoroSequencePanel);
                    break;
                case TYPE.SHORTREST:
                    Instantiate(pomodoroDataPrefabs[2], pomodoroSequencePanel);
                    break;
                case TYPE.LONGREST:
                    Instantiate(pomodoroDataPrefabs[3], pomodoroSequencePanel);
                    break;
            }
        }
    }

    // 뽀모도로 시퀀스창 비우기
    public void ClearPomodoroSequencePanel()
    {
        foreach (Transform child in pomodoroSequencePanel)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetDescriptionText()
    {

    }
}
