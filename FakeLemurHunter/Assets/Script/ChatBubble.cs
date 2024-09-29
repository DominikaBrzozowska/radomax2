using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Numerics;
using Unity.VisualScripting;

public class ChatBubble : MonoBehaviour
{   
    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake() {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }
 
    public void Setup(String text, int fontSize, UnityEngine.Vector2 padding) {
        backgroundSpriteRenderer.color = new Color(1,1,1);

        textMeshPro.color = new Color(0,0,0);
        textMeshPro.fontSize = fontSize;
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        UnityEngine.Vector2 textSize = textMeshPro.GetRenderedValues(false);

        backgroundSpriteRenderer.size = textSize + padding;

        backgroundSpriteRenderer.transform.localPosition = 
            new UnityEngine.Vector3((backgroundSpriteRenderer.size.x / 2f) - (padding.x / 2f), 0f);
    }
}
