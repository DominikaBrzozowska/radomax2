using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMenu : MonoBehaviour
{
    public GameObject buttonPrefab; // Assign the button prefab in the Inspector
    public Transform buttonContainer; // Assign the panel or parent object for buttons
    public int numberOfButtons = 5; // Set the number of buttons you want

    void Start()
    {
        CreateButtons();
    }

    private void CreateButtons()
    {
        for (int i = 0; i < numberOfButtons; i++)
        {
            // Instantiate a button
            GameObject button = Instantiate(buttonPrefab, buttonContainer);

            // Get the TextMeshProUGUI component from the button's child
            TextMeshProUGUI buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText != null)
            {
                buttonText.text = (i + 1) + ". " + "Button";
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not found in button prefab.");
            }

            // Add a listener to the button
            int buttonIndex = i; // Capture the current index
            button.GetComponent<Button>().onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    void OnButtonClick(int index)
    {
        Debug.Log("Button " + (index + 1) + " clicked!");
        // Add your action here
    }
}
