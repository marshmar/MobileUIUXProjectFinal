using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum DROPTYPE { FOCUS, REST, LONGREST}
public class DroppableUI : MonoBehaviour, IPointerEnterHandler, IDropHandler, IPointerExitHandler
{

    private RectTransform rect;
    //private PanelPSData panelPSDataScr;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        //panelPSDataScr = GetComponentInParent<PanelPSData>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        //image.color = Color.yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //image.color = Color.white;
    }

    public void OnDrop(PointerEventData eventData)
    {
        // pointerDrag는 현재 드래그하고 있는 대상(=아이템)
        if(eventData.pointerDrag != null)
        {
            if(eventData.pointerDrag.transform.TryGetComponent<DraggableUI>(out DraggableUI dui))
            {
                // 드래그하는 있는 대상의 부모를 현재 오브젝트로 설정하고, 위치를 현재 오브젝트 위치와 동일하게 설정
                dui.TempObj.transform.SetParent(transform);
                dui.TempObj.transform.position = rect.position;
                dui.TempObj.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                dui.TempObj.GetComponent<CanvasGroup>().alpha = 1.0f;
                /*if(dui.TempObj.TryGetComponent<Data>(out Data data))
                {
                    //data.SetPomodoroData();
                }*/
            }
        }
    }
}
