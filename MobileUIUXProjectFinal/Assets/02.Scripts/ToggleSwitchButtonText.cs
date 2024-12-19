using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 토글 상태에 따른 버튼 색을 조정하는 클래스
public class ToggleSwitchButtonText : MonoBehaviour
{
    [Header("Text Object")]
    [SerializeField]
    private TMP_Text leftText;
    [SerializeField]
    private TMP_Text rightText;

    [Header("Text Color")]
    public string enableTextColor;
    public string disableTextColor;

    // 텍스트 컬러를 설정하는 함수
    public void SetTextColor(bool isOnLeft)
    {
        // 헥스 컬러 값을 Color 타입으로 변환
        Color enableColor, disableColor;
        ColorUtility.TryParseHtmlString(enableTextColor, out enableColor);
        ColorUtility.TryParseHtmlString(disableTextColor, out disableColor);

        // disableColor의 알파값을 100으로 조정
        disableColor = new Color(disableColor.r, disableColor.g, disableColor.b, 100.0f/ 255.0f);

        // 왼쪽이 활성화 됐을 경우
        if (isOnLeft)
        {
            leftText.color = enableColor;
            rightText.color = disableColor;
        }
        // 오른쪽이 활성화 됐을 경우
        else
        {
            leftText.color = disableColor;
            rightText.color = enableColor;
        }
        
        
    }
}
