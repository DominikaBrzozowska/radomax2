using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Numerics;
using Unity.VisualScripting;
using Vector2 = UnityEngine.Vector2;

public class ChatBubble : MonoBehaviour
{
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    private Coroutine typingCoroutine;

    private void Awake() {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    public void Setup(string text, int fontSize, Vector2 padding, float typingSpeed) {
        backgroundSpriteRenderer.color = new Color(1, 1, 1);

        textMeshPro.color = new Color(0, 0, 0);
        textMeshPro.fontSize = fontSize;

        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);

        backgroundSpriteRenderer.size = textSize + padding;

        backgroundSpriteRenderer.transform.localPosition = 
            new UnityEngine.Vector3((backgroundSpriteRenderer.size.x / 2f) - (padding.x / 2f), 0f);

        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(text, typingSpeed));
    }

    private IEnumerator TypeText(string text, float typingSpeed) {
        textMeshPro.text = "";
        foreach (char letter in text.ToCharArray()) {
            textMeshPro.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}