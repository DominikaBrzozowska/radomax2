using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private bool playerInteracted = false;
    private bool playerInRange = false;
    private SpriteRenderer exclamationMarkRenderer;
    private SpriteRenderer promptKeyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        exclamationMarkRenderer = transform.Find("exclamation-mark").GetComponent<SpriteRenderer>();
        promptKeyRenderer = transform.Find("e-key-prompt").GetComponent<SpriteRenderer>();
    }

    public void OnInteractPressed()
    {
        if (playerInRange && !playerInteracted)
        {
            exclamationMarkRenderer.enabled = false;
            playerInteracted = true;
            Debug.Log("Interacted with Player!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided " + other.gameObject.tag);
        // Check if the object entered a specific trigger
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            // exclamationMarkRenderer.enabled = true;
            promptKeyRenderer.enabled = true;
            Debug.Log("Triggered Player!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Left Player!");
            promptKeyRenderer.enabled = false;
        }
    }
}
