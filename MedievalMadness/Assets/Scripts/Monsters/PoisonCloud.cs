using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour
{
    public GameObject poissonSprite;
    public float aliveTime = 3;
    private float CurrentAlpha = 255.0f;
    public float speedAlpha = 0.04f;

    private void Start()
    {
        Destroy(this.gameObject, aliveTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Civil"))
        {
            collision.gameObject.GetComponent<Civil>().Death();
        }

    }


    private void Update()
    {
        CurrentAlpha = Mathf.Lerp(CurrentAlpha, 0.0f , speedAlpha);
        poissonSprite.GetComponent<SpriteRenderer>().color = new Color(255,255,255, CurrentAlpha);
    }
}
