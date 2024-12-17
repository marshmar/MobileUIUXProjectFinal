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
    public float scale; // ũ�Ⱑ ��ȭ�� ��
    [SerializeField]
    public float time; // ����� �ð�
    private WaitForSeconds waitingTime; // ��� �ð�

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rectTransform = GetComponent<RectTransform>();
        waitingTime = new WaitForSeconds(time);
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        // ��ư Ŭ���� ������ ���� �ڷ�ƾ ����
        StartCoroutine(Scale(eventData));
    }

    public IEnumerator Scale(PointerEventData eventData)
    {
        // ���� �����ϰ� �޾ƿ���
        Vector3 currScale = new Vector3(rectTransform.localScale.x, rectTransform.localScale.y, rectTransform.localScale.z);
        // ���� �����ϰ��� scale �踸ŭ ũ�� ����
        transform.DOScale(currScale * scale, 0.05f);

        // watingTime��ŭ ��ٸ���
        yield return waitingTime;

        // �ٽ� ���� �����Ϸ� ũ�� ����
        transform.DOScale(currScale, 0.05f);

        // watingTime��ŭ ��ٸ���
        yield return waitingTime;

        // OnClick �̺�Ʈ ����
        base.OnPointerClick(eventData);
    }
}
