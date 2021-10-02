using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float power = 0.5f;
    public float duration = 5f;

    private void Start()
    {
        Invoke("DestroyZone", duration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<SmallMonster>().Slow(power);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<SmallMonster>().UnSlow();
        }
    }

    private void DestroyZone()
    {
        this.gameObject.GetComponent<CircleCollider2D>().radius = 0f;
        Destroy(this.gameObject);
    }
}
