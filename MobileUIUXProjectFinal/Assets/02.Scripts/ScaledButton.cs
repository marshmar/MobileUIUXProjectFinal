using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;


public class ScaledButton : Button
{
    private RectTransform rectTransform;
    [SerializeField]
    public float scale;
    [SerializeField]
    public float time;

    private WaitForSeconds watingTime;
    protected override void Start()
    {
        base.Start();
        rectTransform = GetComponent<RectTransform>();
        watingTime = new WaitForSeconds(time);
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(Scale(eventData));
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
