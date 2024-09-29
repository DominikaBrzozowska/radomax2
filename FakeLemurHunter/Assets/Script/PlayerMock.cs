using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMock : MonoBehaviour
{
    [SerializeField] private GameObject pfChatBubble;

    public void CreateChatBubble(Transform parent, Vector3 localPosition, string message, int fontSize, UnityEngine.Vector2 padding)
    {
        GameObject chatBubbleInstance = Instantiate(pfChatBubble, parent);
        chatBubbleInstance.transform.localPosition = localPosition;

        ChatBubble chatBubbleScript = chatBubbleInstance.GetComponent<ChatBubble>();
        chatBubbleScript.Setup(message, fontSize, padding);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateChatBubble(transform, new Vector3(0, 1.3F, 0), "Hello World!", 3, new UnityEngine.Vector2(0.2f, 0.2f));
    }
}
