using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private LifeAndDeath lifeanddeath;
   

    public Slider slider;

    public Gradient gradient;
    public Image fill;
    
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = lifeanddeath.hpMax;
        slider.value = lifeanddeath.hp;

    }

    public void SetHealth(int health)
    {
        slider.value = lifeanddeath.hp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }


}
