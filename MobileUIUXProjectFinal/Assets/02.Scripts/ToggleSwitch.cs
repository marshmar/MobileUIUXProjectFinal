using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

// https://www.youtube.com/watch?v=E9AWlbPGi_4 유튜브 토글 스위치 만드는 법을 참고하였습니다.

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
{
    [Header("Slider setup")]
    [SerializeField, Range(0, 1f)] private float sliderValue;

    public bool CurrentValue { get; private set; }  // 현재 토글의 상태를 저장하는 프로퍼티

    private Slider _slider;

    [Header("Animation")]   // 슬라이더 토글이 넘어가는 애니메이션 속도
    [SerializeField, Range(0, 1f)] private float animationDuration = 0.25f;
    [SerializeField]        // 애니메이션의 속도와 곡선을 정의하는 변수
    private AnimationCurve slideEase =
        AnimationCurve.EaseInOut(timeStart: 0, valueStart: 0, timeEnd: 1, valueEnd: 1);

    private Coroutine _animateSliderCoroutine;  // 현재 애니메이션 코루틴을 참조하는 변수

    [Header("Events")]      // 애니메이션에 대한 이벤트 핸들러를 위한 UI 인스펙터 그룹 표시
    [SerializeField] private UnityEvent onToggleOn;     // 토글이 활성화될 때 호출되는 이벤트
    [SerializeField] private UnityEvent onToggleOff;    // 토글이 비활성화될 때 호출되는 이벤트

    private ToggleSwitchGroupManager _toggleSwitchGroupManager;

    [Header("HighLight Setup")] // 하이라이트 조절을 위한 UI 인스펙터 그룹 표시
    [SerializeField, Range(0, 255.0f)] private float highLightAlpha;
    [SerializeField] private float waitingTime;

    private WaitForSeconds waiting;
    private Image backgroundImage;

    protected void OnValidate()
    {
        // UI 요소 초기화
        SetupToggleComponents();

        _slider.value = sliderValue;
    }

    private void SetupToggleComponents()
    {
        if (_slider != null)
            return;

        // 게임 오브젝트에 있는 슬라이더를 가져와서 조작
        SetupSliderComponent();
    }

    private void SetupSliderComponent()
    {
        _slider = GetComponent<Slider>();

        if(_slider == null)
        {
            Debug.Log("No slider found!", this);
            return;
        }

        _slider.interactable = false;
        var sliderColors = _slider.colors;
        sliderColors.disabledColor = Color.white;
        _slider.colors = sliderColors;
        _slider.transition = Selectable.Transition.None;
    }

    public void SetupForManager(ToggleSwitchGroupManager manager)
    {
        _toggleSwitchGroupManager = manager;
    }

    private void Awake()
    {
        // 초기화 수행
        SetupToggleComponents();
        waiting = new WaitForSeconds(waitingTime);
        backgroundImage = GetComponentInChildren<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 포인터 클릭시 하이라이트 조절한 후에 Toggle 수행
        StartCoroutine(HighLight());
        Toggle();
    }

    private void Toggle()
    {
        if (_toggleSwitchGroupManager != null)
            _toggleSwitchGroupManager.ToggleGroup(this);
        else
            SetStateAndStartAnimation(!CurrentValue);
    }

    public void ToggleByGroupManager(bool valueToSetTo)
    {
        SetStateAndStartAnimation(valueToSetTo);
    }

    private void SetStateAndStartAnimation(bool state)
    {
        CurrentValue = state;

        if (CurrentValue)
            onToggleOn?.Invoke();
        else
            onToggleOff?.Invoke();

        if (_animateSliderCoroutine != null)
            StopCoroutine(_animateSliderCoroutine);

        _animateSliderCoroutine = StartCoroutine(AnimateSlider());
    }

    private IEnumerator AnimateSlider()
    {
        float startValue = _slider.value;
        float endValue = CurrentValue ? 1 : 0;

        float time = 0;
        if(animationDuration > 0)
        {
            while(time < animationDuration)
            {
                time += Time.deltaTime;

                float lerpFactor = slideEase.Evaluate(time / animationDuration);
                _slider.value = sliderValue = Mathf.Lerp(startValue, endValue, lerpFactor);

                yield return null;
            }
        }

        _slider.value = endValue;
    }

    // 하이라이트 코루틴
    public IEnumerator HighLight()
    {
        // 배경 이미지 색의 투명도를 설정
        Color color = backgroundImage.color;
        backgroundImage.color = new Color(color.r, color.g, color.b, highLightAlpha / 255.0f);

        yield return waiting;

        // 원래대로 설정
        backgroundImage.color = color;
    }
}
