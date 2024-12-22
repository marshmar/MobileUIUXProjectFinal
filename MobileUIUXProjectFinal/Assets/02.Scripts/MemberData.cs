using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewData", menuName = "MemberData")]
public class MemberData : ScriptableObject
{
    public string memberName;       // 멤버 이름
    public float studyTime;         // 공부 시간
    public bool isGroupMaster;      // 그룹장 여부
    public int attendanceCount;     // 참석 일수
}
