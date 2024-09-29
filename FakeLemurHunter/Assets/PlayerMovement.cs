using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveAmount = 0.5f; // Amount to move to the right
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position += new Vector3(this.moveAmount, 0, 0);
        // rb.velocity = new Vector2(moveAmount, 0);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(moveAmount, 0);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveAmount, 0);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
