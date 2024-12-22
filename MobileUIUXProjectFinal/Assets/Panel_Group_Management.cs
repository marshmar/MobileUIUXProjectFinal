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
        memberName.Add("ÀÌ¼ø½Å");
        memberName.Add("Á¤¾à¿ë");
        memberName.Add("¾ÈÁß±Ù");
        memberName.Add("ÇÑ¼®ºÀ");
        memberName.Add("È«±æµ¿");
        memberName.Add("À±µ¿ÁÖ");
        memberName.Add("±è»ñ°«");
        memberName.Add("±èÁÖ¸ù");
        memberName.Add("¿Õ¼¼Á¾");
    }

    public void AddMember()
    {
        GameObject tempObj = Instantiate(memberPrefab, contentPanel);
        int randomIntex = 0;
        randomIntex = UnityEngine.Random.Range(0, memberName.Count);
        tempObj.GetComponentInChildren<TMP_Text>().text = memberName[randomIntex];
    }
}
