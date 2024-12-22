using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LottiePlugin.UI;

public class Carousel : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;     // ScrollView�� ScrollRect
    [SerializeField] private RectTransform content;     // ScrollView�� Content
    public List<RectTransform> items;                  // ī�缿 ������ ����Ʈ
    public float spacing = 400f;                        // �����۰��� ����
    public float scaleFactor = 0.5f;                    // �� ���� ������ ũ�� ��� ����
    public float smoothSpeed = 10f;                     // ��ũ�� �̵��ӵ�

    private Vector2 targetPosition;                     // ��ũ���� ��ǥ ��ġ
    private int currentIndex = 0;

    private void Start()
    {
        // �ʱ� ��ǥ ��ġ ����
        MoveToItem(0);
        targetPosition = content.anchoredPosition;
    }

    private void Update()
    {
        UpdateItemScales();     // ������ ũ��� ���� ������Ʈ
        SmoothScroll();          // ��ũ���� �ε巴�� �̵�
    }

    public void MoveToItem(int index)
    {
        // ������ �������� ��ġ�� ��ũ�� �̵�
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

            // ���� ����
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
