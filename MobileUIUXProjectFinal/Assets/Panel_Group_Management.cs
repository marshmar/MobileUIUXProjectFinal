using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Panel_Group_Management : MonoBehaviour
{
    [SerializeField] private GameObject memberPrefab;
    [SerializeField] private Transform contentPanel;

    private List<string> memberName  = new List<string>();

    private void Awake()
    {
        AddMemberName();
    }

    private void AddMemberName()
    {
        memberName.Add("�̼���");
        memberName.Add("�����");
        memberName.Add("���߱�");
        memberName.Add("�Ѽ���");
        memberName.Add("ȫ�浿");
        memberName.Add("������");
        memberName.Add("���");
        memberName.Add("���ָ�");
        memberName.Add("�ռ���");
    }

    public void AddMember()
    {
        GameObject tempObj = Instantiate(memberPrefab, contentPanel);
        int randomIntex = 0;
        randomIntex = UnityEngine.Random.Range(0, memberName.Count);
        tempObj.GetComponentInChildren<TMP_Text>().text = memberName[randomIntex];
    }
}
