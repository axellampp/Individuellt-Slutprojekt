using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collision is with player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            // Stop player from falling through ground
            playerBody.velocity = new Vector2(playerBody.velocity.x, 0f);
        }
    }
}

