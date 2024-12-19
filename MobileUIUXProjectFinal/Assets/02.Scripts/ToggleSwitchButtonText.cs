using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// ��� ���¿� ���� ��ư ���� �����ϴ� Ŭ����
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

    // �ؽ�Ʈ �÷��� �����ϴ� �Լ�
    public void SetTextColor(bool isOnLeft)
    {
        // �� �÷� ���� Color Ÿ������ ��ȯ
        Color enableColor, disableColor;
        ColorUtility.TryParseHtmlString(enableTextColor, out enableColor);
        ColorUtility.TryParseHtmlString(disableTextColor, out disableColor);

        // disableColor�� ���İ��� 100���� ����
        disableColor = new Color(disableColor.r, disableColor.g, disableColor.b, 100.0f/ 255.0f);

        // ������ Ȱ��ȭ ���� ���
        if (isOnLeft)
        {
            leftText.color = enableColor;
            rightText.color = disableColor;
        }
        // �������� Ȱ��ȭ ���� ���
        else
        {
            leftText.color = disableColor;
            rightText.color = enableColor;
        }
        
        
    }
}
