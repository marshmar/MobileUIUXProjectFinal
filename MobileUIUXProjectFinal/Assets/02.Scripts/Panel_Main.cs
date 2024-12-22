using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LottiePlugin.UI;

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

    [Header("Carousel")]
    public GameObject[] animatedImages;
    [SerializeField] private Carousel beforePomodoroCarousel;
    [SerializeField] private Carousel studyingPomodoroCarousel;
    [SerializeField] private Transform beforePomodoroCarouselContentPanel;
    [SerializeField] private Transform studyingPomodoroCarouselContentPanel;

    [SerializeField] private MiniIconPanel beforePomodoroMiniIconPanel;
    [SerializeField] private MiniIconPanel studyingPomodoroMiniIconPanel;

    [Header("BeforePomodoroTutorial")]
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private GameObject tutorialpomodoroSettingButton;
    [SerializeField] private GameObject buttonPanel;
    [SerializeField] private GameObject carouselObject;
    
    [SerializeField] private Timer timer;
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


    public void SetCarouselIndex(int index)
    {
        beforePomodoroCarousel.MoveToItem(index);
        studyingPomodoroCarousel.MoveToItem(index);
    }

    public void PlayCarouselAnim(int index)
    {
        studyingPomodoroCarousel.PlayAnimIndex(index);
    }

    public void ResetMiniIconTransparency()
    {
        beforePomodoroMiniIconPanel.ResetTransparency();
        studyingPomodoroMiniIconPanel.ResetTransparency();
    }

    public void SetMiniIconTransparency(int index, float alpha)
    {
        beforePomodoroMiniIconPanel.SetTransaprency(index, alpha);
        studyingPomodoroMiniIconPanel.SetTransaprency(index, alpha);
    }
    public void StopCarouselAnim(int index)
    {
        studyingPomodoroCarousel.StopAnimIndex(index);
    }

    public void CreateCarouselContents()
    {
        if (PomodoroDataManager.Instance.CurrPomodoroData == null) return;
        PomodoroData pomodoroData = PomodoroDataManager.Instance.CurrPomodoroData;
        foreach (Data data in pomodoroData.dataList)
        {
            GameObject tempObj1 = null, tempObj2 = null, tempObj3 = null, tempObj4 = null;

            // Ÿ�Կ� ���� �̹��� ����
            switch (data.type)
            {
                case TYPE.SHORTSTUDY:
                    tempObj1 = Instantiate(animatedImages[0], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[0], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[0], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[0], studyingPomodoroMiniIconPanel.transform);
                    break;
                case TYPE.LONGSTUDY:
                    tempObj1 = Instantiate(animatedImages[1], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[1], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[1], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[1], studyingPomodoroMiniIconPanel.transform);
                    break;
                case TYPE.SHORTREST:
                    tempObj1 = Instantiate(animatedImages[2], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[2], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[2], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[2], studyingPomodoroMiniIconPanel.transform);
                    break;
                case TYPE.LONGREST:
                    tempObj1 = Instantiate(animatedImages[3], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[3], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[3], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[3], studyingPomodoroMiniIconPanel.transform);
                    break;
            }
            //�ִϸ��̼� ��Ȱ��ȭ
            tempObj3.GetComponent<AnimatedImage>()._playOnAwake = false;
            tempObj4.GetComponent<AnimatedImage>()._playOnAwake = false;
            // ī�缿 ����Ʈ�� ������ �ֱ�
            beforePomodoroCarousel.items.Add(tempObj1.GetComponent<RectTransform>());
            studyingPomodoroCarousel.items.Add(tempObj2.GetComponent<RectTransform>());
            ResetMiniIconTransparency();
        }
    }
    public void CreateCarouselContents(PomodoroData pomodoroData)
    {
        if (pomodoroData == null) return;
        foreach (Data data in pomodoroData.dataList)
        {
            GameObject tempObj1 = null, tempObj2 = null, tempObj3 = null, tempObj4 = null;

            // Ÿ�Կ� ���� �̹��� ����
            switch (data.type)
            {
                case TYPE.SHORTSTUDY:
                    tempObj1 = Instantiate(animatedImages[0], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[0], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[0], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[0], studyingPomodoroMiniIconPanel.transform);
                    break;
                case TYPE.LONGSTUDY:
                    tempObj1 = Instantiate(animatedImages[1], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[1], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[1], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[1], studyingPomodoroMiniIconPanel.transform);
                    break;
                case TYPE.SHORTREST:
                    tempObj1 = Instantiate(animatedImages[2], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[2], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[2], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[2], studyingPomodoroMiniIconPanel.transform);
                    break;
                case TYPE.LONGREST:
                    tempObj1 = Instantiate(animatedImages[3], beforePomodoroCarouselContentPanel);
                    tempObj2 = Instantiate(animatedImages[3], studyingPomodoroCarouselContentPanel);
                    tempObj3 = Instantiate(animatedImages[3], beforePomodoroMiniIconPanel.transform);
                    tempObj4 = Instantiate(animatedImages[3], studyingPomodoroMiniIconPanel.transform);
                    break;
            }
            // �ִϸ��̼� ��Ȱ��ȭ
            tempObj3.GetComponent<AnimatedImage>()._playOnAwake = false;
            tempObj4.GetComponent<AnimatedImage>()._playOnAwake = false;
            // ī�缿 ����Ʈ�� ������ �ֱ�
            beforePomodoroCarousel.items.Add(tempObj1.GetComponent<RectTransform>());
            studyingPomodoroCarousel.items.Add(tempObj2.GetComponent<RectTransform>());
            ResetMiniIconTransparency();
        }
    }


    public void ClearCarouselContents()
    {
        // ��� �ڽİ�ü �����
        foreach (Transform child in beforePomodoroCarouselContentPanel)
        {
            Destroy(child.gameObject);

        }
        foreach (Transform child in studyingPomodoroCarouselContentPanel)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in beforePomodoroMiniIconPanel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in studyingPomodoroMiniIconPanel.transform)
        {
            Destroy(child.gameObject);
        }

        // item�� �ʱ�ȭ
        beforePomodoroCarousel.items.Clear();
        studyingPomodoroCarousel.items.Clear();
        timer.ClearIndex();
    }

    public void EndTutorial()
    {
        tutorialText.SetActive(false);
        tutorialpomodoroSettingButton.SetActive(false);
        buttonPanel.SetActive(true);
        carouselObject.SetActive(true);
        beforePomodoroCarousel.SetAnimationAllItems(false);
        studyingPomodoroCarousel.SetAnimationAllItems(false);
        timer.SetTimerMode();
        timer.ClearIndex();
        timer.ClearTime();
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
    public void EnablePomodoroStudyPanel()
    {
        // �Ǹ𵵷� ���� ȭ�� ��Ƽ��
        pomodoroStudyPanel.SetActive(true);

        // ������ �гε� �ξ�Ƽ��
        infinityStudyPanel.SetActive(false);
        beforeInfinityStudyPanel.SetActive(false);
        beforePomodoroPanel.SetActive(false);
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
