using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class ScaledToggle : Toggle
{

    private RectTransform rectTransform;
    [SerializeField]
    public float scale; // 크기가 변화될 값
    [SerializeField]
    public float time; // 대기할 시간
    private WaitForSeconds waitingTime; // 대기 시간

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rectTransform = GetComponent<RectTransform>();
        waitingTime = new WaitForSeconds(time);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // 버튼 클릭시 스케일 조절 코루틴 시작
        StartCoroutine(Scale(eventData));
    }

    public IEnumerator Scale(PointerEventData eventData)
    {
        // 현재 스케일값 받아오기
        Vector3 currScale = new Vector3(rectTransform.localScale.x, rectTransform.localScale.y, rectTransform.localScale.z);
        // 현재 스케일값의 scale 배만큼 크기 조절
        transform.DOScale(currScale * scale, 0.05f);

        // watingTime만큼 기다리기
        yield return waitingTime;

        // 다시 원래 스케일로 크기 조절
        transform.DOScale(currScale, 0.05f);

        // watingTime만큼 기다리기
        yield return waitingTime;

        // OnClick 이벤트 실행
        base.OnPointerClick(eventData);
    }
}
