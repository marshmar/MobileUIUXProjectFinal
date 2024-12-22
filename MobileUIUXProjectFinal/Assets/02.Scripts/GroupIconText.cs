using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroupIconText : MonoBehaviour
{
    [SerializeField] private TMP_Text iconText;
    [SerializeField] private ScaledToggle scaledToggle;
    public string onColor;
    public string offColor;

    public void SetText()
    {
        if (scaledToggle.isOn)
        {
            if (ColorUtility.TryParseHtmlString(onColor, out Color color))
            {
                iconText.color = color;
            }
        }
        else
        {
            if (ColorUtility.TryParseHtmlString(offColor, out Color color))
            {
                iconText.color = color;
            }
        }

    }
}
