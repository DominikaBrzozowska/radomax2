using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    private bool playerInteracted = false;
    private SpriteRenderer exclamationMarkRenderer;
    private SpriteRenderer promptKeyRenderer;

    // Start is called before the first frame update
    void Start()
    {
        exclamationMarkRenderer = transform.Find("exclamation-mark").GetComponent<SpriteRenderer>();
        promptKeyRenderer = transform.Find("e-key-prompt").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided " + other.gameObject.tag);
        // Check if the object entered a specific trigger
        if (other.CompareTag("Player"))
        {
            // exclamationMarkRenderer.enabled = true;
            promptKeyRenderer.enabled = true;
            Debug.Log("Triggered Player!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Left Player!");
            promptKeyRenderer.enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Stayed Player! " + playerInteracted + " " + Input.GetKey(KeyCode.E));
        if (!playerInteracted && Input.GetKey(KeyCode.E))
        {
            exclamationMarkRenderer.enabled = false;
            playerInteracted = true;
            Debug.Log("Stayed Player!");
        }
    }
}
