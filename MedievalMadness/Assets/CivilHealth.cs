using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CivilHealth : MonoBehaviour
{
    public int Health = 2;
    private float timer = 0;
    public float invincibilityTime = 1;
    private bool hasBeenTouch = false;

    //Update called every frame
    private void Update() 
    {
        if (hasBeenTouch == true)
        {
            if(timer < invincibilityTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                hasBeenTouch = false;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (hasBeenTouch == false)
        {
            Debug.Log("wesh");
            if(other.gameObject.CompareTag("Monster"))
            {
                Debug.Log("try to destroy");
                if(Health >1)
                {
                    Health -=1 ;
                    hasBeenTouch = true;
                }    
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other) 
    {
        if (hasBeenTouch == false)
        {
            Debug.Log("wesh");
            if(other.gameObject.CompareTag("Monster"))
            {
                Debug.Log("try to destroy");
                if(Health >1)
                {
                    Health -=1 ;
                    hasBeenTouch = true;
                }    
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
