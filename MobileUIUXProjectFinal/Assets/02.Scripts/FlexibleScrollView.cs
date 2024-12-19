using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlexibleScrollView : MonoBehaviour
{
    private RectTransform rectTransform;
    public float maximumWidth;
    public float maximumHeight;
    [SerializeField]
    private RectTransform contentTransform;

    private VerticalLayoutGroup verticalLayoutGroup;
    private void Awake()
    {
        verticalLayoutGroup = GetComponentInParent<VerticalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = contentTransform.sizeDelta;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetScrollViewHorizontalSize(contentTransform.sizeDelta);
        LimitScrollViewSize();
    }

    public void LimitScrollViewSize()
    {
        rectTransform.sizeDelta = new Vector2
        (
            Mathf.Min(rectTransform.rect.width, maximumWidth),
            Mathf.Min(rectTransform.rect.height, maximumHeight)
        );

    }

    public void SetScrollViewHorizontalSize(Vector2 size)
    {
        rectTransform.sizeDelta = new Vector2(maximumWidth, size.y);
    }
}
