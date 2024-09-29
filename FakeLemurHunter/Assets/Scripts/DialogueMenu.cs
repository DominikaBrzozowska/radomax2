using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Script.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class DialogueMenu : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign the button prefab in the Inspector
    public GameObject buttonContainer; // Assign the panel or parent object for buttons

    private List<GameObject> buttonObjects = new List<GameObject>();

    private PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // public void CreateButtons(List<string> buttonTexts)
    public void OpenDialogQuestions(List<ChatWrapper> chats)
    {
        for (int i = 0; i < chats.Count; i++)
        {
            var chat = chats[i];
            // Instantiate a button
            GameObject button = Instantiate(buttonPrefab, buttonContainer.GetComponent<Transform>());
            buttonObjects.Add(button);

            // Get the TextMeshProUGUI component from the button's child
            TextMeshProUGUI buttonGui = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonGui != null)
            {
                buttonGui.text = (i + 1) + ". " + chat.Chat.ChatContent;
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found in button prefab.");
            }

            // Add a listener to the button
            int buttonIndex = i; // Capture the current index
            // var nextChatGroupId = chat.Chat.ChatsGroupAvailable[0];
            // var anwserText = chat.Chat.Answer;
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(chat));
        }
    }


    private void HideQuestionMenu()
    {
        gameObject.SetActive(false); // Hide the dialogue menu
        buttonObjects.ForEach(Destroy); // Destroy all buttons
        buttonObjects.Clear(); // Clear the list
    }

    void OnButtonClick(ChatWrapper chat)
    {
        Debug.Log("Button " + chat.Key + " clicked!");
        var nextChatGroupId = chat.Chat.ChatsGroupAvailable.Any() ? chat.Chat.ChatsGroupAvailable[0] : null;
        playerController.npcInRange.Say(chat.Chat.Answer, nextChatGroupId);
        // Add your action here
        HideQuestionMenu();
    }

}
