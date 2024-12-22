using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnIdle : MonoBehaviour
{
    public CanvasGroup canvasGroup; // ���İ��� ������ CanvasGroup
    public float fadeDelay = 2.0f; // Ŭ���� ���� �� ���̵尡 ���۵Ǳ������ ��� �ð�
    public float fadeDuration = 1.0f; // ���̵� �ƿ��� �ɸ��� �ð�

    private float lastClickTime; // ������ Ŭ�� �ð��� ���
    private bool isFading = false; // ���� ���̵� ������ ����
    public bool fadeOnIdle;

    void Start()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup�� �����ϼ���!");
            return;
        }
        canvasGroup.alpha = 1; // �ʱ� ���İ� ����
    }

    void Update()
    {
        // Ŭ�� ����
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            OnClickDetected();
        }

        if (fadeOnIdle)
        {
            // ���̵� ���� ����
            if (Time.time - lastClickTime > fadeDelay && !isFading && canvasGroup.alpha > 0)
            {
                StartCoroutine(FadeOut());
            }
        }

    }

    public void OnClickDetected()
    {
        // Ŭ�� �� ���İ��� 1�� �����ϰ� ���̵带 ����
        canvasGroup.alpha = 1;
        lastClickTime = Time.time;
        StopAllCoroutines();
        isFading = false;
        canvasGroup.interactable = true;
    }

    private IEnumerator FadeOut()
    {
        isFading = true;
        float startAlpha = canvasGroup.alpha;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, elapsedTime / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        isFading = false;
        canvasGroup.interactable = false;
    }

    public void SetFadable(bool value)
    {
        fadeOnIdle = value;
    }
}
