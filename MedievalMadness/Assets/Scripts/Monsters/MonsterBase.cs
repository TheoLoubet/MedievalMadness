using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    public float healthPoint;
    public float moveSpeedDefault;
    private float moveSpeed;

    private void Awake()
    {
        moveSpeed = moveSpeedDefault;
    }

    public void TakeDamage(float damage)
    {
        this.healthPoint -= damage;
        if (this.healthPoint <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }

    public void Slow(float power)
    {
        moveSpeed = moveSpeed * power;
    }
    public void UnSlow()
    {
        moveSpeed = moveSpeedDefault;
    }
}
