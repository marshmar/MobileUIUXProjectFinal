using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOnIdle : MonoBehaviour
{
    public CanvasGroup canvasGroup; // 알파값을 조절할 CanvasGroup
    public float fadeDelay = 2.0f; // 클릭이 없을 때 페이드가 시작되기까지의 대기 시간
    public float fadeDuration = 1.0f; // 페이드 아웃에 걸리는 시간

    private float lastClickTime; // 마지막 클릭 시간을 기록
    private bool isFading = false; // 현재 페이드 중인지 여부
    public bool fadeOnIdle;

    void Start()
    {
        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup을 연결하세요!");
            return;
        }
        canvasGroup.alpha = 1; // 초기 알파값 설정
    }

    void Update()
    {
        // 클릭 감지
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            OnClickDetected();
        }

        if (fadeOnIdle)
        {
            // 페이드 시작 조건
            if (Time.time - lastClickTime > fadeDelay && !isFading && canvasGroup.alpha > 0)
            {
                StartCoroutine(FadeOut());
            }
        }

    }

    public void OnClickDetected()
    {
        // 클릭 시 알파값을 1로 설정하고 페이드를 중지
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
