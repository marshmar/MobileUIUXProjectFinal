using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

// https://www.youtube.com/watch?v=E9AWlbPGi_4 ��Ʃ�� ��� ����ġ ����� ���� �����Ͽ����ϴ�.

public class ToggleSwitch : MonoBehaviour, IPointerClickHandler
{
    [Header("Slider setup")]
    [SerializeField, Range(0, 1f)] private float sliderValue;

    public bool CurrentValue { get; private set; }  // ���� ����� ���¸� �����ϴ� ������Ƽ

    private Slider _slider;

    [Header("Animation")]   // �����̴� ����� �Ѿ�� �ִϸ��̼� �ӵ�
    [SerializeField, Range(0, 1f)] private float animationDuration = 0.25f;
    [SerializeField]        // �ִϸ��̼��� �ӵ��� ��� �����ϴ� ����
    private AnimationCurve slideEase =
        AnimationCurve.EaseInOut(timeStart: 0, valueStart: 0, timeEnd: 1, valueEnd: 1);

    private Coroutine _animateSliderCoroutine;  // ���� �ִϸ��̼� �ڷ�ƾ�� �����ϴ� ����

    [Header("Events")]      // �ִϸ��̼ǿ� ���� �̺�Ʈ �ڵ鷯�� ���� UI �ν����� �׷� ǥ��
    [SerializeField] private UnityEvent onToggleOn;     // ����� Ȱ��ȭ�� �� ȣ��Ǵ� �̺�Ʈ
    [SerializeField] private UnityEvent onToggleOff;    // ����� ��Ȱ��ȭ�� �� ȣ��Ǵ� �̺�Ʈ

    private ToggleSwitchGroupManager _toggleSwitchGroupManager;

    [Header("HighLight Setup")] // ���̶���Ʈ ������ ���� UI �ν����� �׷� ǥ��
    [SerializeField, Range(0, 255.0f)] private float highLightAlpha;
    [SerializeField] private float waitingTime;

    private WaitForSeconds waiting;
    private Image backgroundImage;

    protected void OnValidate()
    {
        // UI ��� �ʱ�ȭ
        SetupToggleComponents();

        _slider.value = sliderValue;
    }

    private void SetupToggleComponents()
    {
        if (_slider != null)
            return;

        // ���� ������Ʈ�� �ִ� �����̴��� �����ͼ� ����
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
        // �ʱ�ȭ ����
        SetupToggleComponents();
        waiting = new WaitForSeconds(waitingTime);
        backgroundImage = GetComponentInChildren<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // ������ Ŭ���� ���̶���Ʈ ������ �Ŀ� Toggle ����
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

    // ���̶���Ʈ �ڷ�ƾ
    public IEnumerator HighLight()
    {
        // ��� �̹��� ���� ������ ����
        Color color = backgroundImage.color;
        backgroundImage.color = new Color(color.r, color.g, color.b, highLightAlpha / 255.0f);

        yield return waiting;

        // ������� ����
        backgroundImage.color = color;
    }
}
