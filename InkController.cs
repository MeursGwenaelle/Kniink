using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkController : MonoBehaviour
{
    [SerializeField] private ink Ink;
    public Slider slider;

    public Gradient gradient;
    public Image fill;


    public void SetMaxInk(int ink)
    {
        slider.maxValue = Ink.inkMax;
        slider.value = Ink.CurrentInk;

    }
    public void SetInk(int ink)
    {
        slider.value = Ink.CurrentInk;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
