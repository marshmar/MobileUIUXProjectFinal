using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SetText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text myText;
    [SerializeField]
    private TMP_Text targetText;

    public void SetTargetText()
    {
        targetText.text = myText.text;
    }
}
