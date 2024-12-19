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
    private WaitForSeconds watingTime;
    private float touchStartTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        enableImage.SetActive(false);
        createdImage = false;
        isPressing = false;
        rectTransform = GetComponent<RectTransform>();
        watingTime = new WaitForSeconds(time);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressing && !createdImage)
        {
            float touchTime = Time.time;
            Debug.Log("터치 중");
            if (touchTime - touchStartTime >= 1.0f)
            {
                transform.DOPunchScale(new Vector3(0.0f, 0.0f, 0.0f), 0.3f, 1, 0);
                enableImage.SetActive(true);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            if(!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition))
            {
                enableImage.SetActive(false);
            }
        }
    }

    public override void OnPointerDown(PointerEventData pointerEventData)
    {
        touchStartTime = Time.time;
        isPressing = true;
    }

    public override void OnPointerUp(PointerEventData pointerEventData)
    {
        isPressing = false;
        float touchEndTime, timeDiff;
        touchEndTime = Time.time;

        timeDiff = touchEndTime - touchStartTime;
        Debug.Log(timeDiff);

        if (timeDiff >= 1.0f)
        {

            //enableImage.SetActive(true);

        }
        else
        {
            if (!createdImage)
            {
                StartCoroutine(Scale(pointerEventData));
            }

        }

    }

    public IEnumerator Scale(PointerEventData eventData)
    {
        Vector3 currScale = new Vector3(rectTransform.localScale.x, rectTransform.localScale.y, rectTransform.localScale.z);
        transform.DOScale(currScale * scale, 0.05f);

        yield return watingTime;

        transform.DOScale(currScale, 0.05f);

        yield return watingTime;

        base.OnPointerClick(eventData);
    }

}
