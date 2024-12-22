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
        // 메인 패널 활성화
        panelMain.SetActive(true);
        topMain.SetActive(true);

        // 나머지 패널들
        panelFriend.SetActive(false);
        panelSetting.SetActive(false);
        panelPicture.SetActive(false);

        // 상단바 패널 설정
        topFriend.SetActive(false);
        topSetting.SetActive(false);
        topPicture.SetActive(false);
    }

    public void EnableSettingFriendPanel()
    {
        // 친구 패널 설정
        panelFriend.SetActive(true);
        topFriend.SetActive(true);

        // 나머지 패널들 비활성화
        topMain.SetActive(false);
        panelMain.SetActive(false);
    }

    public void EnableSettingPicturePanel()
    {
        // 친구 패널 설정
        panelPicture.SetActive(true);
        topPicture.SetActive(true);

        // 나머지 패널들 비활성화
        topMain.SetActive(false);
        panelMain.SetActive(false);
    }

    public void EnableSettingSettingPanel()
    {
        // 친구 패널 설정
        panelSetting.SetActive(true);
        topSetting.SetActive(true);

        // 나머지 패널들 비활성화
        topMain.SetActive(false);
        panelMain.SetActive(false);
    }
}
