using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Dialogue;
using UnityEngine;

public class PlayerDialogController : MonoBehaviour
{
    private DialogueManager dialogueManager;

    void Strart()
    {
        dialogueManager = GetComponentInChildren<DialogueManager>();
    }

    public void StartDialog(String dialogId)
    {
        Debug.Log("Starting dialog: " + dialogId);
        var x = dialogueManager.GetChatByKey(dialogId);
        Debug.Log("Dialog: " + x.Chat.ChatContent);
    }
}
