using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessBar : MonoBehaviour
{
    public Slider slider;
    public int civilMadnessValue = 20;
    
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
}
