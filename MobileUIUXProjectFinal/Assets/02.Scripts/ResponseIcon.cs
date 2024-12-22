using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResponseIcon : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] ScaledToggle scaledToggle;
    // Start is called before the first frame update
    
    
    public void SetResponse()
    {
        if (scaledToggle.isOn)
        {
            if (text.text == "") text.text = "0";

            text.text = ((int.Parse(text.text)) + 1).ToString();
            if(ColorUtility.TryParseHtmlString("#F2F3AE", out Color color))
            {
                text.color = color;
            }
        }
        else
        {
            int value = (int.Parse(text.text)) - 1;
            if(value <= 0)
            {
                text.text = "";
                return;
            }
            text.text = value.ToString();
            if (ColorUtility.TryParseHtmlString("#D58936", out Color color))
            {
                text.color = color;
            }

        }
    }
}
