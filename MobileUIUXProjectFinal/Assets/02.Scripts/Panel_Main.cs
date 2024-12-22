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

            // 타입에 따른 이미지 생성
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
            //애니메이션 비활성화
            tempObj3.GetComponent<AnimatedImage>()._playOnAwake = false;
            tempObj4.GetComponent<AnimatedImage>()._playOnAwake = false;
            // 카루셀 리스트에 아이템 넣기
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

            // 타입에 따른 이미지 생성
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
            // 애니메이션 비활성화
            tempObj3.GetComponent<AnimatedImage>()._playOnAwake = false;
            tempObj4.GetComponent<AnimatedImage>()._playOnAwake = false;
            // 카루셀 리스트에 아이템 넣기
            beforePomodoroCarousel.items.Add(tempObj1.GetComponent<RectTransform>());
            studyingPomodoroCarousel.items.Add(tempObj2.GetComponent<RectTransform>());
            ResetMiniIconTransparency();
        }
    }


    public void ClearCarouselContents()
    {
        // 모든 자식객체 지우기
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

        // item들 초기화
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

    // 뽀모도로 공부화면으로 세팅
    public void EnablePomodoroStudyPanel()
    {
        // 뽀모도로 공부 화면 액티브
        pomodoroStudyPanel.SetActive(true);

        // 나머지 패널들 인액티브
        infinityStudyPanel.SetActive(false);
        beforeInfinityStudyPanel.SetActive(false);
        beforePomodoroPanel.SetActive(false);
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
