using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isPlayerInside = false;
    private Collider2D playerCollider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            playerCollider = other;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerCollider.GetComponent<Rigidbody2D>().gravityScale = 2f;
            isPlayerInside = false;
            playerCollider = null;

           
        }
    }

    private void Update()
    {
        if (isPlayerInside && playerCollider != null)
        {
            float verticalInput = Input.GetAxis("Vertical");
            if (verticalInput != 0)
            {
                playerCollider.GetComponent<Rigidbody2D>().gravityScale = 0;
                float climbSpeed = 5f;

                
                Vector2 moveDirection = new Vector2( 0 , climbSpeed * verticalInput);
                playerCollider.GetComponent<Rigidbody2D>().velocity = moveDirection;
                
            
            }
        }
    }
}