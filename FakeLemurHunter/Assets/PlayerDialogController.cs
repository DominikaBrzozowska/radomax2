using System;
using System.Linq;
using Assets.Script.Dialogue;
using UnityEngine;

public class PlayerDialogController : MonoBehaviour
{
    private DialogueManager dialogueManager;
    private DialogueMenu dialogueMenu;

    void Start()
    {
        dialogueManager = GetComponentInChildren<DialogueManager>();
        dialogueMenu = GetComponentInChildren<DialogueMenu>();
        Debug.Log(dialogueManager);
    }

    public void StartDialog(String dialogId)
    {
        Debug.Log("==== Starting dialog: " + dialogId + " ====");
        Debug.Log(dialogueMenu.name);
        var chatGroups = dialogueManager.GetChatByChatGroup(dialogId);
        Debug.Log(chatGroups.Count + " chat groups found.");
        Debug.Log(chatGroups);
        // dialogueMenu.CreateButtons(chatGroups.Select(group => group.Chat.ChatContent).ToList());
        dialogueMenu.OpenDialogQuestions(chatGroups);
        // foreach (var chatGroup in chatGroups)
        // {
        //     Debug.Log("  • " + chatGroup.Chat.ChatContent);
        // }
        Debug.Log("========");
    }
}
