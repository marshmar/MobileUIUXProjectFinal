using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMainTopController : MonoBehaviour
{
    [SerializeField] private GameObject studyModeButton;
    [SerializeField] private GameObject studyingText;

    public void EnableStudyModeButton()
    {
        studyModeButton.SetActive(true);
        studyingText.SetActive(false);
    }

    public void EnableStudyingText()
    {
        studyModeButton.SetActive(false);
        studyingText.SetActive(true);
    }
}
