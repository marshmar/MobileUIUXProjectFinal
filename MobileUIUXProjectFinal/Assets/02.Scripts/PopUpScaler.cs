using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScaler : MonoBehaviour
{
    public bool minusOption;
    private RectTransform rectTransform;
    public float MaxScale;
    // Start is called before the first frame update
    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StartCoroutine(Scale());
    }

    public void ReScale()
    {
        StartCoroutine(Scale());
    }
    public IEnumerator Scale()
    {
        Vector2 offset = rectTransform.offsetMin;
        Vector2 tempOffset = new Vector2(offset.x, 0);
        rectTransform.offsetMin = tempOffset;

        while (true)
        {
            if (minusOption)
            {
                tempOffset.y += -50.0f;
            }
            else
            {
                tempOffset.y += 50.0f;
            }
            if (minusOption)
            {
                if (tempOffset.y <= MaxScale) tempOffset.y = MaxScale;
            }
            else
            {
                if (tempOffset.y >= MaxScale) tempOffset.y = MaxScale;
            }

            rectTransform.offsetMin = tempOffset;

            if (minusOption)
            {
                if (rectTransform.offsetMin.y <= MaxScale) yield break;
            }
            else
            {
                if (rectTransform.offsetMin.y >= MaxScale) yield break;
            }


            yield return new WaitForSeconds(0.01f);
        }
    }
}
