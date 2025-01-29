using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider; 
    public void SetMaxExp(float exp)
    {
        slider.maxValue = exp;
    }
    public void SetExp(float exp)
    {
        slider.value = exp;    
    }
}
