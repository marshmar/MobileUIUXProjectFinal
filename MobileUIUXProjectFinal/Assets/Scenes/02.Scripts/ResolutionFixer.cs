using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 빌드시 해상도 고정
public class ResolutionFixer : MonoBehaviour
{
    void Awake()
    {
        // 540x960 비율로 빌드시 해상도 고정
        Screen.SetResolution(540, 960, false);
    }

}
