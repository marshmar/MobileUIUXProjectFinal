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
        // 그룹 메인 패널 활성화
        groupMainPanel.SetActive(true);

        // 나머지 패널들 비활성화
        groupCreatePanel.SetActive(false);
        groupInfoPanel.SetActive(false);
    }

    public void EnableGroupCreatePanel()
    {
        // 그룹 생성 패널 활성화
        groupCreatePanel.SetActive(true);

        // 나머지 패널들 비활성화
        groupMainPanel.SetActive(false);
        
    }

    public void EnableGroupInfoPanel()
    {
        // 그룹 정보 패널 활성화
        groupInfoPanel.SetActive(true);

        // 나머지 패널들 비활성화
        groupMainPanel.SetActive(false);
        groupAttendancePanel.SetActive(false);
        groupChattingPanel.SetActive(false);
        groupManagementPanel.SetActive(false);

        // 백 버튼 활성화
        backButton.SetActive(true);
    }

    public void EnableGroupAttendancePanel()
    {
        // 그룹 출석 패널 활성화
        groupAttendancePanel.SetActive(true);

        // 나머지 패널들 비활성화
        groupInfoPanel.SetActive(false);
    }

    public void EnableGroupChattingPanel()
    {
        // 그룹 채팅 패널 활성화
        groupChattingPanel.SetActive(true);

        // 나머지 패널들 비활성화
        groupInfoPanel.SetActive(false);
    }

    public void EnableGroupManagementPanel()
    {
        // 그룹 관리 패널 활성화
        groupManagementPanel.SetActive(true);

        // 나머지 패널들 비활성화
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
