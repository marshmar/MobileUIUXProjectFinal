using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LottiePlugin.UI;

public class Carousel : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;     // ScrollView의 ScrollRect
    [SerializeField] private RectTransform content;     // ScrollView의 Content
    public List<RectTransform> items;                  // 카루셀 아이템 리스트
    public float spacing = 400f;                        // 아이템간의 간격
    public float scaleFactor = 0.5f;                    // 양 옆의 아이템 크기 축소 비율
    public float smoothSpeed = 10f;                     // 스크롤 이동속도

    private Vector2 targetPosition;                     // 스크롤의 목표 위치
    private int currentIndex = 0;

    private void Start()
    {
        // 초기 목표 위치 설정
        MoveToItem(0);
        targetPosition = content.anchoredPosition;
    }

    private void Update()
    {
        UpdateItemScales();     // 아이템 크기와 투명도 업데이트
        SmoothScroll();          // 스크롤을 부드럽게 이동
    }

    public void MoveToItem(int index)
    {
        // 선택한 아이템의 위치로 스크롤 이동
        currentIndex = index;
        float newX = -index * spacing;
        targetPosition = new Vector2(newX, content.anchoredPosition.y);
    }

    public void PlayAnimIndex(int index)
    {
        AnimatedImage anim = items[index].GetComponent<AnimatedImage>();
        anim._playOnAwake = true;
        anim.Play();
    }

    public void StopAnimIndex(int index)
    {
        AnimatedImage anim = items[index].GetComponent<AnimatedImage>();
        anim.Stop();
    }
    private void SmoothScroll()
    {
        content.anchoredPosition = Vector2.Lerp(content.anchoredPosition, targetPosition, Time.deltaTime * smoothSpeed);
    }

    private void UpdateItemScales()
    {
        for (int i = 0; i < items.Count; i++)
        {
            float distance = Mathf.Abs(content.anchoredPosition.x + i * spacing);
            float scale = Mathf.Clamp(1 - (distance / spacing) * (1 - scaleFactor), scaleFactor, 1f);
            items[i].localScale = new Vector3(scale, scale, 1f);

            // 투명도 변경
            CanvasGroup canvasGroup = items[i].GetComponent<CanvasGroup>();
            if (canvasGroup != null)
            {
                canvasGroup.alpha = scale;
            }
        }
    }

    public void SetAnimationAllItems(bool isPlay)
    {
        foreach(RectTransform rect in items)
        {
            AnimatedImage anim = rect.GetComponent<AnimatedImage>();
            if (isPlay)
            {
                anim.Play();
            }
            else
            {
                anim._playOnAwake = false;
                //anim.Stop();
            }
        }
    }
}
