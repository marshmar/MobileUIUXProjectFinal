using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Panel_Group : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private GameObject tutorialObject;
    [SerializeField] private GameObject groupdListObj;

    [Header("Panel")]
    [SerializeField] private GameObject groupMainPanel;
    [SerializeField] private GameObject groupCreatePanel;
    [SerializeField] private GameObject groupInfoPanel;
    [SerializeField] private GameObject groupAttendancePanel;
    [SerializeField] private GameObject groupChattingPanel;
    [SerializeField] private GameObject groupManagementPanel;

    [Header("GroupData")]
    [SerializeField] private GameObject groupDataPrefab;
    [SerializeField] private Transform groupDataContentPanel;

    [Header("Button")]
    [SerializeField] private GameObject backButton;
    public void EnableGroupMainPanel()
    {
        // �׷� ���� �г� Ȱ��ȭ
        groupMainPanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        groupCreatePanel.SetActive(false);
        groupInfoPanel.SetActive(false);
    }

    public void EnableGroupCreatePanel()
    {
        // �׷� ���� �г� Ȱ��ȭ
        groupCreatePanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        groupMainPanel.SetActive(false);
        
    }

    public void EnableGroupInfoPanel()
    {
        // �׷� ���� �г� Ȱ��ȭ
        groupInfoPanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        groupMainPanel.SetActive(false);
        groupAttendancePanel.SetActive(false);
        groupChattingPanel.SetActive(false);
        groupManagementPanel.SetActive(false);

        // �� ��ư Ȱ��ȭ
        backButton.SetActive(true);
    }

    public void EnableGroupAttendancePanel()
    {
        // �׷� �⼮ �г� Ȱ��ȭ
        groupAttendancePanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        groupInfoPanel.SetActive(false);
    }

    public void EnableGroupChattingPanel()
    {
        // �׷� ä�� �г� Ȱ��ȭ
        groupChattingPanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        groupInfoPanel.SetActive(false);
    }

    public void EnableGroupManagementPanel()
    {
        // �׷� ���� �г� Ȱ��ȭ
        groupManagementPanel.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        groupInfoPanel.SetActive(false);
    }

    public void SetTitleText(string text)
    {
        titleText.text = text;
    }

    public void SetTitleTextToGroupName()
    {
        titleText.text = GroupDataManager.Instance.CurrGroupData.GroupName;
    }

    public void EndTutorial()
    {
        tutorialObject.SetActive(false);
        groupdListObj.SetActive(true);
    }

    public void CreateGroupData()
    {
        GameObject createdGroupData = Instantiate(groupDataPrefab, groupDataContentPanel);
        GroupData groupData = createdGroupData.GetComponent<GroupData>();

        GroupDataManager.Instance.SettingGroupData = groupData;

        EndTutorial();
    }

    
}
