using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    private float actualMoveSpeed;

    // Dash variables
    public float dashForce = 40f;
    public float dashRate = 1f;
    public float dashTime = 0.1f;
    private float timeUntilNextDash = 0f;
    private bool isDashing = false;

    // Madness
    bool isMadness = false;

    //TP locations
    private bool endTP = true;
    private int Tp_ID = 0;
    public GameObject TpSprites;
    public GameObject BodySprites;
    public Transform leftLoc;
    public Transform upLoc;
    public Transform rightLoc;
    public Transform downLoc;

    Rigidbody2D rb;

    Vector2 movementVector;
    Vector2 aimInput;
    Vector2 aimVector;

    private void Start() 
    {
        
    }

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Time.timeScale != 0)
        { 
            isMadness = GetComponent<Player>().isMadness;
            if (isMadness)
            {
                actualMoveSpeed = moveSpeed * 1.5f;
            }
            else
            {
                actualMoveSpeed = moveSpeed;

            }

            // Left joystick for movement
            if (endTP)
            {
                movementVector.x = Input.GetAxisRaw("Horizontal");
                movementVector.y = Input.GetAxisRaw("Vertical");

                // Right joystick for aiming

                aimInput.x = Input.GetAxis("Horizontal2");
                aimInput.y = Input.GetAxis("Vertical2");

                if (aimInput.magnitude >= 0.8)
                {
                    aimVector.x = aimInput.x;
                    aimVector.y = aimInput.y;
                    aimVector.Normalize();
                }

                // Dash
                if (timeUntilNextDash > 0 && !isDashing)
                {
                    timeUntilNextDash -= Time.deltaTime;
                }

                if (Input.GetAxisRaw("LeftTrigger") > 0 && timeUntilNextDash <= 0)
                {
                    Dash(movementVector);
                }

                if (isDashing)
                {
                    Physics2D.IgnoreLayerCollision(7, 8, true);
                    Physics2D.IgnoreLayerCollision(6, 8, true);
                }
                else
                {
                    Physics2D.IgnoreLayerCollision(7, 8, false);
                    Physics2D.IgnoreLayerCollision(6, 8, false);
                }
            }
            GetTpInput();
            
        }



        //--- 
        HandleTp();

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
            rb.MovePosition(rb.position + movementVector * actualMoveSpeed * Time.fixedDeltaTime);
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

        if(!isMadness)
        {
            timeUntilNextDash = dashRate;
        }
        else
        {
            timeUntilNextDash = dashRate/2f;
        }
            

        Invoke("EndDash", dashTime);
    }

    private void EndDash()
    {
        rb.velocity = Vector2.zero;
        
        isDashing = false;
    }


    private void GetTpInput()
    {
        if (Input.GetAxisRaw("TpX") > 0)
        {
            Tp_ID = 0;  // Left
            endTP = false;
        }
        if (Input.GetAxisRaw("TpX") < 0)
        {
            Tp_ID = 1; // Right
            endTP = false;
        }
        if (Input.GetAxisRaw("TpY") > 0)
        {
            Tp_ID = 2;  // Down
            endTP = false;
        }
        if (Input.GetAxisRaw("TpY") < 0)
        {
            Tp_ID = 3;  // UP
            endTP = false;
        }
    }

    private void HandleTp()
    {
        if (!endTP)
        {



            Physics2D.IgnoreLayerCollision(7, 8, true);
            Physics2D.IgnoreLayerCollision(6, 8, true);
            Physics2D.IgnoreLayerCollision(3, 8, true);

            TpSprites.SetActive(true);
            BodySprites.SetActive(false);
            switch (Tp_ID)
            {
                case 0:
                    TpTo(leftLoc.position);
                    break;

                case 1:
                    TpTo(rightLoc.position);
                    break;

                case 2:
                    TpTo(downLoc.position);
                    break;

                case 3:
                    TpTo(upLoc.position);
                    break;

                default:
                    break;
            }
        }
        else
        {

            if (isDashing)
            {
                Physics2D.IgnoreLayerCollision(7, 8, true);
                Physics2D.IgnoreLayerCollision(6, 8, true);
            }
            else
            {
                Physics2D.IgnoreLayerCollision(7, 8, false);
                Physics2D.IgnoreLayerCollision(6, 8, false);
            }
            Physics2D.IgnoreLayerCollision(3, 8, false);

            TpSprites.SetActive(false);
            BodySprites.SetActive(true);
        }
    }

    private void TpTo(Vector2 TpLocation)
    {
        Vector3 CurrentLocation = rb.position;
        rb.position = Vector3.Lerp(CurrentLocation, TpLocation, 0.02f);

        if (Vector2.Distance(rb.position, TpLocation) < 2.0f)
        {
            endTP = true;
            
        }
    }

    public bool isDashUp()
    {
        return timeUntilNextDash <= 0;
    }
}
