using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private float timeForWait = 0;
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthBarScript;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        timeForWait += Time.deltaTime;
        if (timeForWait > 1)
        {
            timeForWait = 0;
            healthBarScript.GetComponent<HealthBar>().loseHealth();
        }
        

    }
}
