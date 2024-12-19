using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using LottiePlugin.UI;
using LottiePlugin.Support;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;               // UI�� �ҼӵǾ� �ִ� �ֻ���� CanvasTransform
    private Transform previousParent;       // �ش� ������Ʈ�� ������ �ҼӵǾ� �־��� �θ� Transform
    private RectTransform rect;             // UI ��ġ ��� ���� RectTransform
    private CanvasGroup canvasGroup;        // UI�� ���İ��� ��ȣ�ۿ� ��� ���� CanvasGroup
    [SerializeField]
    private GameObject imagePrefab;
    private GameObject tempObj;

    private AnimatedImage animatedImageScr;
    //private Data dataComponent;
    public GameObject TempObj { get => tempObj; set => tempObj = value; }

    /*    public Transform PreviousParent { get => previousParent; set => previousParent = value; }
public CanvasGroup CanvasGroup { get => canvasGroup; set => canvasGroup = value; }*/

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        //dataComponent = GetComponent<Data>();
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        tempObj = Instantiate(imagePrefab, transform);   
        /* if(tempObj.TryGetComponent<Data>(out Data data))
         {
             data.time = dataComponent.time;
         }*/


        //tempObj.GetComponent<Image>().sprite = GetComponent<Image>().sprite; 
        canvasGroup = tempObj.GetComponent<CanvasGroup>();
        rect = tempObj.GetComponent<RectTransform>();
        // ���� �巡������ UI�� ȭ���� �ֻ�ܿ� ��µǵ��� �ϱ� ����
        tempObj.transform.SetParent(canvas);    // �θ� ������Ʈ�� Canvas�� ����
        tempObj.transform.SetAsLastSibling();   // ���� �տ� ���̵��� ������ �ڽ����� ����
        tempObj.transform.Rotate(0.0f, 180.0f, 180.0f);

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // ���� ��ũ������ ���콺 ��ġ�� UI ��ġ�� ���� (UI�� ���콺�� �Ѿƴٴϴ� ����)
        rect.position = eventData.position;
        rect.localScale = new Vector3(1.2f, 1.2f, 1.2f);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // �巡�׸� �����ϸ� �θ� canvas�� �����Ǳ� ������
        // �巡�׸� ������ �� �θ� canvas�̸� ������ ������ �ƴ� ������ ����
        // ����� �ߴٴ� ���̱� ������ �巡�� ������ �ҼӵǾ� �ִ� ������ �������� ������ �̵�
        if(tempObj.transform.parent == canvas)
        {
            // �������� �ҼӵǾ��־��� previousParent�� �ڽ����� �����ϰ�, �ش� ��ġ�� ����
            /*transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;*/
            Destroy(tempObj);
            return;
        }

        // ���İ��� 1�� �����ϰ�, ���� �浹ó���� �ǵ��� �Ѵ�
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts = true;
    }
}
