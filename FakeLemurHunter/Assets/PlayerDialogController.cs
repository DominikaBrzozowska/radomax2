using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Dialogue;
using UnityEngine;

public class PlayerDialogController : MonoBehaviour
{
    private DialogueManager dialogueManager;

    void Start()
    {
        dialogueManager = GetComponentInChildren<DialogueManager>();
        Debug.Log(dialogueManager);
    }

    public void StartDialog(String dialogId)
    {
        Debug.Log("==== Starting dialog: " + dialogId + " ====");
        var chatGroups = dialogueManager.GetChatByChatGroup(dialogId);
        foreach (var chatGroup in chatGroups)
        {
            Debug.Log("  • " + chatGroup.Chat.ChatContent);
        }
        // Debug.Log("  • " + chatGroups.Chat.ChatContent);
        Debug.Log("========");
    }
}
