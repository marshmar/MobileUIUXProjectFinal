using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Setting : MonoBehaviour
{
    [Header("TopPanel")]
    [SerializeField] private GameObject topMain;
    [SerializeField] private GameObject topFriend;
    [SerializeField] private GameObject topSetting;
    [SerializeField] private GameObject topPicture;

    [Header("Panel")]
    [SerializeField] private GameObject panelMain;
    [SerializeField] private GameObject panelFriend;
    [SerializeField] private GameObject panelSetting;
    [SerializeField] private GameObject panelPicture;

    public void EnableSettingMainPanel()
    {
        // ���� �г� Ȱ��ȭ
        panelMain.SetActive(true);
        topMain.SetActive(true);

        // ������ �гε�
        panelFriend.SetActive(false);
        panelSetting.SetActive(false);
        panelPicture.SetActive(false);

        // ��ܹ� �г� ����
        topFriend.SetActive(false);
        topSetting.SetActive(false);
        topPicture.SetActive(false);
    }

    public void EnableSettingFriendPanel()
    {
        // ģ�� �г� ����
        panelFriend.SetActive(true);
        topFriend.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        topMain.SetActive(false);
        panelMain.SetActive(false);
    }

    public void EnableSettingPicturePanel()
    {
        // ģ�� �г� ����
        panelPicture.SetActive(true);
        topPicture.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        topMain.SetActive(false);
        panelMain.SetActive(false);
    }

    public void EnableSettingSettingPanel()
    {
        // ģ�� �г� ����
        panelSetting.SetActive(true);
        topSetting.SetActive(true);

        // ������ �гε� ��Ȱ��ȭ
        topMain.SetActive(false);
        panelMain.SetActive(false);
    }
}
