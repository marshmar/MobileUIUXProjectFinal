using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "MemberData")]
public class MemberData : ScriptableObject
{
    public string memberName;       // ��� �̸�
    public float studyTime;         // ���� �ð�
    public bool isGroupMaster;      // �׷��� ����
    public int attendanceCount;     // ���� �ϼ�
}
