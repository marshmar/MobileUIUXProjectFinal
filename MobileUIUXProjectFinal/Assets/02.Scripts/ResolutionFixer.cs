using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� �ػ� ����
public class ResolutionFixer : MonoBehaviour
{
    void Awake()
    {
        // 540x960 ������ ����� �ػ� ����
        Screen.SetResolution(540, 960, false);
    }

}
