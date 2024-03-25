using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocoTalkController : MonoBehaviour
{
    public static ChocoTalkController instance;

    public RectTransform friendsTab;
    public RectTransform ChatTab;
    public RectTransform OPChatTab;

    public GameObject[] Chats;
    public GameObject[] ChatButtons;

    private Dictionary<string, GameObject> ChatMap = new Dictionary<string, GameObject>();
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        for(int i = 0; i < Chats.Length; i++)
        {
            ChatMap.Add(ChatButtons[i].name, Chats[i]);
        }
    }
    public void ActiveChat(string name)
    {
        PhoneController.instance.ActiveTab(ChatMap[name]);
    }
    public void OpenFriendsTab(){
        friendsTab.SetAsLastSibling();
    }
    public void OpenChatTab(){
        ChatTab.SetAsLastSibling();
    }
    public void OpenOPChatTab(){
        OPChatTab.SetAsLastSibling();
    }
}
