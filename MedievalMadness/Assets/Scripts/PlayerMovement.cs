using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movementVector;
    Vector2 aimVector;

    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal2");
        movementVector.y = Input.GetAxisRaw("Vertical2");

        //aimVector.x = Input.GetAxisRaw("Horizontal2");
        //aimVector.y = Input.GetAxisRaw("Vertical2");
    }

    private void FixedUpdate()
    {
        if (movementVector.sqrMagnitude > 1f)
        {
            movementVector.Normalize();
        }
        rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);

        Debug.Log(aimVector);
    }
}
