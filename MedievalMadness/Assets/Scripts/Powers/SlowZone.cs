using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowPower = 0.5f;
    public float speedPower = 1.5f;
    public float duration = 5f;

    private void Start()
    {
        Invoke("DestroyZone", duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<MonsterBase>().Slow(slowPower);
        }
        else if (collision.gameObject.CompareTag("Civil"))
        {
            collision.gameObject.GetComponent<Civil>().SpeedUp(speedPower);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<MonsterBase>().UnSlow();
        }
        else if (collision.gameObject.CompareTag("Civil"))
        {
            collision.gameObject.GetComponent<Civil>().SpeedDown();
        }
    }

    private void DestroyZone()
    {
        this.gameObject.GetComponent<CircleCollider2D>().radius = 0f;
        Destroy(this.gameObject);
    }
}
