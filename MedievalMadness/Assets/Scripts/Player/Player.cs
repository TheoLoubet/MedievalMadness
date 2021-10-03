using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float timeForWait = 0;
    public float maxMadness = 50;
    public float currentMadness = 0;
    public float minMadness = 0;
    public float madnessDecreasing = 1;
    public GameObject madnessBar;
    public bool isMadness = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        currentMadness = madnessBar.GetComponent<MadnessBar>().getMadness();
        if (currentMadness == maxMadness)
        {
            isMadness = true;
        }

        if (currentMadness == minMadness)
        {
            Debug.Log("wesh");
            isMadness = false;
        }


        timeForWait += Time.deltaTime;
        if (timeForWait > 1)
        {   
            if (currentMadness > 0)
            {
                currentMadness -= 1;
                timeForWait = 0;
                madnessBar.GetComponent<MadnessBar>().setMadness(currentMadness);
            }
        }

        

    }
}
