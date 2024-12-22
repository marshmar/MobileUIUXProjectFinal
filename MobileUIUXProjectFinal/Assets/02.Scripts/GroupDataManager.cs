using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupDataManager : Singleton<GroupDataManager>
{
    private GroupData currGroupData;
    private GroupData settingGroupData;

    private List<GroupData> groupDataList = new List<GroupData>();

    public List<GroupData> GroupDataList { get => groupDataList; set => groupDataList = value; }
    public GroupData CurrGroupData { get => currGroupData; set => currGroupData = value; }
    public GroupData SettingGroupData { get => settingGroupData; set => settingGroupData = value; }


    public void AddGroupData(GroupData groupData)
    {
        groupDataList.Add(groupData);
    }

    public void RemoveGroupData(GroupData groupData)
    {
        groupDataList.Remove(groupData);
    }

    public void ClearGroupData()
    {
        groupDataList.Clear();
    }

}
