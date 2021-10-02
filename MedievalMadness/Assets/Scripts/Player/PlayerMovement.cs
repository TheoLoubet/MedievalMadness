using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Dash variables
    public float dashForce = 30f;
    public float dashRate = 0.5f;
    public float dashTime = 0.1f;
    private float timeUntilNextDash = 0f;
    private bool isDashing = false;


    Rigidbody2D rb;

    Vector2 movementVector;
    Vector2 aimInput;
    Vector2 aimVector;


    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Left joystick for movement
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = Input.GetAxisRaw("Vertical");

        // Right joystick for aiming
        aimInput.x = Input.GetAxis("Horizontal2");
        aimInput.y = Input.GetAxis("Vertical2");

        if (aimInput.magnitude >= 0.5)
        {
            aimVector.x = aimInput.x;
            aimVector.y = aimInput.y;
            aimVector.Normalize();
        }

        // Dash
        if(timeUntilNextDash > 0 && !isDashing)
        {
            timeUntilNextDash -= Time.deltaTime;
        }

        if (Input.GetAxisRaw("LeftTrigger") > 0 && timeUntilNextDash <= 0)
        {
            Dash(movementVector);
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
        if (!isDashing)
        {
            rb.MovePosition(rb.position + movementVector * moveSpeed * Time.fixedDeltaTime);
        }

        // Rotate player
        float endAngle = Mathf.Atan2(aimVector.y, aimVector.x) * Mathf.Rad2Deg - 90f;   // get end angle from controller

        float currentAngle = rb.rotation;                           // get current angle 
        currentAngle = Mathf.LerpAngle(currentAngle,endAngle,0.3f); // make Lerp to smooth movement
        rb.rotation = currentAngle;                                 // set Current Angle as rotation

    }

    private void Dash(Vector2 vector)
    {
        isDashing = true;
        rb.AddForce(vector * dashForce, ForceMode2D.Impulse);
        timeUntilNextDash = dashRate;

        Invoke("EndDash", dashTime);
    }

    private void EndDash()
    {
        rb.velocity = Vector2.zero;
        isDashing = false;
    }
}
