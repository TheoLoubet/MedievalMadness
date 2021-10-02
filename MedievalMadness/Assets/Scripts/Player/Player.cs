using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float timeForWait = 0;
    public int maxMadness = 50;
    public int currentMadness;
    public float madnessDecreasing = 1;
    public GameObject madnessBarScript;
    // Start is called before the first frame update
    void Start()
    {
        currentMadness = maxMadness;
    }

    // Update is called once per frame
    void Update()
    {
        timeForWait += Time.deltaTime;
        if (timeForWait > 1)
        {   
            if (currentMadness > 0)
            {
                currentMadness -= 1;
                timeForWait = 0;
                madnessBarScript.GetComponent<MadnessBar>().setMadness(currentMadness);
            }
        }
        

    }
}
