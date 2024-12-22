using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LottiePlugin.UI;

public class PomodoroData : MonoBehaviour
{
    public List<Data> dataList = new List<Data>();
    public string pomodoroName;
    private NavigationView navigationView;

    [Header("Components")]
    [SerializeField] private ToggleGroup contentToggleGroup;     // content�� ��� �׷�
    [SerializeField] private ScaledToggle scaledToggle;
    [SerializeField] private TMP_Text text;         // ���� �ؽ�Ʈ
    [SerializeField] private Transform iconPanel;   // �������� �ִ� iconPanel
    [SerializeField] private Panel_Pomodoro_Setting PPS;
    [SerializeField] private RectTransform pomodoroDataPanel;
    // Start is called before the first frame update

    [Header("Icons")]
    // 0: shortStudy, 1: longStudy, 2: shortRest, 3: longRest
    public GameObject[] animatedImages; 
    void Awake()
    {
        contentToggleGroup = GetComponentInParent<ToggleGroup>();
        //scaledToggle = GetComponentInChildren<ScaledToggle>();
        navigationView = GetComponentInParent<NavigationView>();
        PPS = GetComponentInParent<Panel_Pomodoro_Setting>();

        scaledToggle.group = contentToggleGroup;
    }

    private void Start()
    {
        PlayAnimationAllIcons();
        scaledToggle.isOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayAnimationAllIcons();
    }
    public void AddData(Data data)
    {
        dataList.Add(data);
    }

    public void ClearData()
    {
        dataList.Clear();
    }

    public void RemoveData(Data data)
    {
        dataList.Remove(data);
    }
    public void SetName(string text)
    {
        pomodoroName = text;
    }


    public void RemovePomodoroDataInManger()
    {
        PomodoroDataManager.Instance.RemovePomodoroData(this);
        Destroy(this.gameObject);
    }

    public void SetText()
    {
        text.text = pomodoroName;
    }

    public void CreateSubIcons()
    {
        foreach (Data data in dataList)
        {
            switch (data.type)
            {
                case TYPE.SHORTSTUDY:
                    Instantiate(animatedImages[0], iconPanel);
                    break;
                case TYPE.LONGSTUDY:
                    Instantiate(animatedImages[1], iconPanel);
                    break;
                case TYPE.SHORTREST:
                    Instantiate(animatedImages[2], iconPanel);
                    break;
                case TYPE.LONGREST:
                    Instantiate(animatedImages[3], iconPanel);
                    break;
            }
        }
    }

    public void EnablePanelDataSetting()
    {
        // �Ǹ𵵷� ������ �޴����� ���� ����� �ڽ����� ����
        PomodoroDataManager.Instance.settingData = this;
        // ������̼� �信 �Ǹ𵵷� ������ �г� ����ֱ�
        navigationView.Push(PPS.pomodoroDataPanel.GetComponent<RectTransform>());
        // ����â�� �ƴ� ����â���� ����
        PPS.setCreatingPomodoro(false);
        // �Ǹ𵵷� ������ �г� Ȱ��ȭ
        PPS.EnablePomodoroDataPanel();
    }

    public void PlayAnimationAllIcons()
    {
        AnimatedImage[] anims = iconPanel.GetComponentsInChildren<AnimatedImage>();
        if (anims.Length < 1) return;

        foreach(AnimatedImage anim in anims)
        {
            anim.Play();
        }
    }

    public void DeleteSubIcons()
    {
        foreach (Transform child in iconPanel)
        {
            Destroy(child.gameObject);
        }
    }

    public void EquipPomodoroData()
    {
        if(scaledToggle.isOn)
            PomodoroDataManager.Instance.CurrPomodoroData = this;
    }
}
