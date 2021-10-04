using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessBar : MonoBehaviour
{
    public Slider slider;
    public int civilMadnessValue = 20;

    public Image HeadCharacter;
    public Sprite[] AllHead;
    
    private bool isMadness = false;

    private void Start() 
    {
        HeadCharacter.overrideSprite = AllHead[0] ;
    }

    void Update()
    {
        SetMadnessSprite();
    }


    public void setMadness(float madness)
    {
        slider.value = madness;
    }
    public float getMadness()
    {
        return slider.value;
    }
    public void CivilDeath()
    {
        slider.value += civilMadnessValue;
    }


    public void setIsMadness(bool newIsMadness){
        isMadness = newIsMadness;
    }


    private void SetMadnessSprite()
    {
        if (isMadness)
        {
            HeadCharacter.overrideSprite = AllHead[3];

        }
        else
        {

            if (slider.value < 25)
            {
                HeadCharacter.overrideSprite = AllHead[0];
            }

            if (slider.value < 75 & slider.value >= 25)
            {
                HeadCharacter.overrideSprite = AllHead[1];
            }

            if (slider.value >= 75)
            {
                HeadCharacter.overrideSprite = AllHead[2];
            }
        }
    }
}
