using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MadnessBar : MonoBehaviour
{
    public Slider slider;
    public void setMadness(int madness)
    {
        slider.value = madness;
    }
    public float getMadness()
    {
        return slider.value;
    }
}
