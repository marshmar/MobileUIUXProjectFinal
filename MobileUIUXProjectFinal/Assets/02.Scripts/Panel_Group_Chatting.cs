using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel_Group_Chatting : MonoBehaviour
{
    [SerializeField] private GameObject chattingPrefab;
    [SerializeField] private Transform chattingContent;

    public void CreateChatting()
    {
        Instantiate(chattingPrefab, chattingContent);
    }
}
