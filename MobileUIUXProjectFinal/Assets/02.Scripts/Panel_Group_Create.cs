using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Panel_Group_Create : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private GameObject memberPreafab;
    [SerializeField] private Transform memberPanel;

    private List<string> memberName = new List<string>();
    public List<MemberData> memberData = new List<MemberData>();
    private void Awake()
    {
        AddMemberNames();
    }

    private void OnEnable()
    {
        DeleteAllMember();
        AddMe();
    }

    private void AddMe()
    {
        GameObject tempObj = Instantiate(memberPreafab, memberPanel);
        tempObj.GetComponentInChildren<TMP_Text>().text = "강해담";
    }

    public void AddMember()
    {
        GameObject tempObj = Instantiate(memberPreafab, memberPanel);
        int randomIntex = 0;
        randomIntex = UnityEngine.Random.Range(0, memberName.Count);
        tempObj.GetComponentInChildren<TMP_Text>().text = memberName[randomIntex];
    }

    public void DeleteAllMember()
    {
        foreach(Transform child in memberPanel)
        {
            Destroy(child.gameObject);
        }
    }

    public void SetGroupName()
    {
        if (GroupDataManager.Instance.SettingGroupData == null) return;

        GroupData groupData = GroupDataManager.Instance.SettingGroupData;
        string tempText = nameInput.text;
        if(tempText == "")
        {
            tempText = "공부그룹";
        }
        groupData.SetGroupName(tempText);
    }

    private void AddMemberNames()
    {
        memberName.Add("김은후");
        memberName.Add("박제현");
        memberName.Add("윤유리");
    }
}
