using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public LayerMask wallLayer;
    public LayerMask monsterLayer;
    RaycastHit2D[] ennemyHits;

    public float damage = 1;

    public float damageRate = 0.2f;
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
        RaycastHit2D positionHit = Physics2D.Raycast(this.transform.position, this.transform.up, 100f, wallLayer);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, positionHit.point);

        // Damage
        if (timeUntilNextDamage > 0)
        {
            timeUntilNextDamage -= Time.deltaTime;
        }
        if (timeUntilNextDamage <= 0)
        {
            ennemyHits = Physics2D.RaycastAll(this.transform.position, this.transform.up, 100f, monsterLayer);


            for (int i = 0; i < ennemyHits.Length; i++)
            {
                ennemyHits[i].transform.gameObject.GetComponent<MonsterBase>().TakeDamage(damage);
            }
            timeUntilNextDamage = damageRate;
        }

    }
}
