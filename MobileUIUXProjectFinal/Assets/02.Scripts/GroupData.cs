using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GroupData : MonoBehaviour
{
    private string groupName;       // 그룹 이름
    private List<MemberData> memberDataList;
    private MemberData groupLeader;
    private Panel_Group panel_Group;

    [SerializeField] private TMP_Text groupNameText;
    public string GroupName { get => groupName; set => groupName = value; }
    public List<MemberData> MemberDataList { get => memberDataList; set => memberDataList = value; }
    public MemberData GroupLeader { get => groupLeader; set => groupLeader = value; }

    private void Awake()
    {
        memberDataList = new List<MemberData>();
        panel_Group = GetComponentInParent<Panel_Group>();
    }
    
    public void AddMemberData(MemberData memberData)
    {
        // 그룹원 추가
        memberDataList.Add(memberData);
    }

    public void ClearMemberData()
    {
        // 데이터 전부 비우기
        memberDataList.Clear();
    }
    
    public void RemoveMemberData(MemberData memberData)
    {
        // 특정 데이터 제거하기
        memberDataList.Remove(memberData);
    }

    public void SetGroupLeader(MemberData memberData)
    {
        // 그룹장 설정하기
        groupLeader = memberData;
    }

    public void SetGroupName(string groupName)
    {
        this.groupName = groupName;
        SetGroupNameText();
    }

    public void SetGroupNameText()
    {
        groupNameText.text = this.groupName;
    }

    public void EnableGroupInfoPanel()
    {
        panel_Group.EnableGroupInfoPanel();
        panel_Group.SetTitleText(groupName);
    }

    public void SetGroupData()
    {
        GroupDataManager.Instance.CurrGroupData = this;
    }
}
