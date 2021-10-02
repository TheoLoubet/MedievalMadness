using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;

    Vector2 movementVector;
    Vector2 aimInput;
    Vector2 aimVector;



    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");


        aimInput.x = Input.GetAxis("Horizontal2");
        aimInput.y = Input.GetAxis("Vertical2");

        if (aimInput.magnitude >= 0.7f)
        {
            aimVector.x = aimInput.x;
            aimVector.y = aimInput.y;
            aimVector.Normalize();
        }
        
    }

    private void FixedUpdate()
    {
        // Insure that movement vector is not longer than 1
        if (movementVector.sqrMagnitude > 1)
        {
            movementVector.Normalize();
        }
        
        // Move player
        rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);

        // Rotate player
        Vector2 lookDirection = aimVector - rb.position;
        float angle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}
