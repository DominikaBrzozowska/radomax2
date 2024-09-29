using System;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    public String dialogId;

    private bool playerInteracted = false;
    private PlayerDialogController playerInRange = null;
    private SpriteRenderer exclamationMarkRenderer;
    private SpriteRenderer promptKeyRenderer;
    [SerializeField] private GameObject pfChatBubble;

    // Start is called before the first frame update
    void Start()
    {
        exclamationMarkRenderer = transform.Find("exclamation-mark").GetComponent<SpriteRenderer>();
        promptKeyRenderer = transform.Find("e-key-prompt").GetComponent<SpriteRenderer>();
    }

    public void StartDialog(string dialogId)
    {
        playerInRange.StartDialog(dialogId);
    }

    public void Say(string message, string nextChatGroupId)
    {
        Debug.Log("NPC said: " + message); // TODO chmurki od Marka

        if (nextChatGroupId != null)
        {
            StartDialog(nextChatGroupId);
        }
    }

    private GameObject lastChatBubbleInstance;
    public void OnInteractPressed()
    {
        if (playerInRange && !playerInteracted)
        {
            exclamationMarkRenderer.enabled = false;
            promptKeyRenderer.enabled = false;
            playerInteracted = true;
            lastChatBubbleInstance = CreateChatBubble(transform, new Vector3(-1.2F, 1.5F, 0), "Cześć!", 9, new UnityEngine.Vector2(0.2f, 0.2f), 0.05f);
            Debug.Log("Interacted with Player!");

            // TODO call DialogManager with dialogId from NPC
            StartDialog(dialogId);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided " + other.gameObject.tag);
        // Check if the object entered a specific trigger
        if (other.CompareTag("Player") && !playerInteracted)
        {
            playerInRange = other.gameObject.GetComponent<PlayerDialogController>();
            promptKeyRenderer.enabled = true;
            Debug.Log("Triggered Player!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = null;
            Debug.Log("Left Player!");
            promptKeyRenderer.enabled = false;
        }
    }

    public GameObject CreateChatBubble(Transform parent, Vector3 localPosition, string message, int fontSize, UnityEngine.Vector2 padding, float time)
    {
        GameObject chatBubbleInstance = Instantiate(pfChatBubble, parent);
        chatBubbleInstance.transform.localPosition = localPosition;

        ChatBubble chatBubbleScript = chatBubbleInstance.GetComponent<ChatBubble>();
        chatBubbleScript.Setup(message, fontSize, padding, time);

        return chatBubbleInstance;
    }
}
