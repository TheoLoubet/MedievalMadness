using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public LayerMask wallLayer;
    public LayerMask hitLayer;
    RaycastHit2D[] ennemyHits;

    public float damage = 1;

    public float damageRate = 0.1f;
    private float timeUntilNextDamage = 0f;


    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = true;
        lineRenderer.useWorldSpace = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Draw
        RaycastHit2D positionHit = Physics2D.Raycast(this.transform.position, this.transform.up, 200f, wallLayer);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, positionHit.point);

        // Damage
        if (timeUntilNextDamage > 0)
        {
            timeUntilNextDamage -= Time.deltaTime;
        }
        if (timeUntilNextDamage <= 0)
        {
            ennemyHits = Physics2D.RaycastAll(this.transform.position, this.transform.up, 200f, hitLayer);


            for (int i = 0; i < ennemyHits.Length; i++)
            {
                if (ennemyHits[i].transform.gameObject.CompareTag("Monster"))
                {
                    ennemyHits[i].transform.gameObject.GetComponent<MonsterBase>().TakeDamage(damage);
                }
                else if (ennemyHits[i].transform.gameObject.CompareTag("Civil"))
                {
                    ennemyHits[i].transform.gameObject.GetComponent<Civil>().Death();
                }
                    
            }
            timeUntilNextDamage = damageRate;
        }

    }
}
