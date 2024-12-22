using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniIconPanel : MonoBehaviour
{
    public void ResetTransparency()
    {
        foreach(Transform child in transform)
        {
            CanvasGroup group = child.GetComponent<CanvasGroup>();
            group.alpha = 0.15f;
        }
    }

    public void SetTransaprency(int index, float alpha)
    {
        transform.GetChild(index).GetComponent<CanvasGroup>().alpha = alpha;
    }
}
