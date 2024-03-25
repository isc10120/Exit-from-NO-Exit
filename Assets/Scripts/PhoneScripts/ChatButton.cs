using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatButton : MonoBehaviour
{
    public void IsClicked(){
        ChocoTalkController.instance.ActiveChat(gameObject.name);
    }
}
