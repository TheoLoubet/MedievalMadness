using UnityEngine;

public class Player : MonoBehaviour
{
    private float madnessDecreaseTime = 0f;
    public float maxMadness = 100f;
    public float currentMadness = 0f;
    public float minMadness = 0f;
    public MadnessBar madnessBar;
    public GameObject madnessAnimation;     // empty object with madness animation
    public bool isMadness = false;
    
    private void Start() 
    {
        madnessBar = GameObject.Find("Madness_Bar").GetComponent<MadnessBar>();
    }

    
    void Update()
    {
        currentMadness = madnessBar.getMadness();

        if (currentMadness >= maxMadness)
        {
            isMadness = true;
            madnessAnimation.SetActive(true);
        }

        if (currentMadness <= minMadness)
        {
            isMadness = false;
            madnessAnimation.SetActive(false);

        }

        madnessBar.GetComponent<MadnessBar>().setIsMadness(isMadness);

        madnessDecreaseTime += Time.deltaTime;
        if (madnessDecreaseTime > 1f)
        {   
            if (currentMadness > 0)
            {
                if(!isMadness)
                {
                    currentMadness -= 1f;
                }
                else
                {
                    currentMadness -= 5;
                }
                madnessDecreaseTime = 0;
                madnessBar.GetComponent<MadnessBar>().setMadness(currentMadness);
            }
        }

        

    }
}
