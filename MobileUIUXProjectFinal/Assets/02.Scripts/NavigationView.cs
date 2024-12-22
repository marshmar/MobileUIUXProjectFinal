using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NavigationView : MonoBehaviour
{
    [SerializeField]
    private RectTransform currentView;
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Button buttonPrev;
    private Stack<RectTransform> stackViews;
    private Panel_Main panel_MainScr;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        stackViews = new Stack<RectTransform>();
        panel_MainScr = GetComponentInParent<Panel_Main>();
        // 버튼에 이벤트 메소드 등록
        buttonPrev.onClick.AddListener(Pop);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log(stackViews.Count);
            foreach(RectTransform rect in stackViews)
            {
                Debug.Log(rect.gameObject.name);
            }
        }
    }

    public void Push(RectTransform newView)
    {
        canvasGroup.blocksRaycasts = false;

        RectTransform previousView = currentView;
        previousView.gameObject.SetActive(false);
        stackViews.Push(previousView);

        currentView = newView;
        currentView.gameObject.SetActive(true);

        canvasGroup.blocksRaycasts = true;

        
    }

    public void Pop()
    {
        if(stackViews.Count < 1)
        {
            panel_MainScr.EnableBeforePomodoroStudyPanel();
            return;
        }

        canvasGroup.blocksRaycasts = false;

        RectTransform previousView = currentView;
        previousView.gameObject.SetActive(false);

        currentView = stackViews.Pop();
        currentView.gameObject.SetActive(true);

        canvasGroup.blocksRaycasts = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
