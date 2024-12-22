using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class HoldingComponent : Button
{
    [SerializeField] public GameObject enableImage;    // 홀딩 시에 활성화할 이미지
    [SerializeField] public float scale;               // 변화할 스케일
    [SerializeField] public float time;                // 기다릴 시간
    [SerializeField] public float holdingTime;         // 홀딩 기준 시간

    private RectTransform rectTransform;
    private bool isPressing;
    private bool createdImage;
    private bool isScaling;
    private WaitForSeconds watingTime;
    private float touchStartTime;
    private Vector3 originalScale;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enableImage.SetActive(false);
        createdImage = false;
        isPressing = false;
        isScaling = false;
        rectTransform = GetComponent<RectTransform>();
        watingTime = new WaitForSeconds(time);
        originalScale = new Vector3(rectTransform.localScale.x, rectTransform.localScale.y, rectTransform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressing && !createdImage)
        {
            float touchTime = Time.time;
            if (touchTime - touchStartTime >= holdingTime)
            {
                transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f, 1, 0);
                enableImage.SetActive(true);
                createdImage = true;
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            if(!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
            {
                enableImage.SetActive(false);
                createdImage = false;
            }
        }
    }

    public override void OnPointerDown(PointerEventData pointerEventData)
    {
        touchStartTime = Time.time;
        isPressing = true;
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        isPressing = false;
        float touchEndTime, timeDiff;
        touchEndTime = Time.time;

        timeDiff = touchEndTime - touchStartTime;

        if (timeDiff < holdingTime && !createdImage)
        {
            StartCoroutine(Scale(eventData));
        }
        else
        {
            return;
        }
        //base.OnPointerClick(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
        base.OnPointerUp(eventData);
    }
    public IEnumerator Scale(PointerEventData eventData)
    {
        if (isScaling) yield break;
        isScaling = true;
        transform.DOScale(originalScale * scale, 0.05f);    // 스케일 줄이기

        Debug.Log("크기 조절");
        yield return watingTime;

        Debug.Log("크기 원상 복구");
        transform.DOScale(originalScale, 0.05f);            // 스케일 원래대로

        yield return watingTime;

        Debug.Log("OnClick 실행");
        isScaling = false;
        base.OnPointerClick(eventData);                     // OnClick이벤트 실행
    }

}
