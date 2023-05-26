using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class fondu : MonoBehaviour
{
    private float Transparence;
    public bool FadeOut;
    public float Step;

    private void Start()
    {
        Transparence = 1;

    }

    private void Update()
    {
        Transparence = Mathf.Clamp(Transparence, 0, 1);
        if(FadeOut)
        {
            Transparence += Step;
        }
        else
        {
            Transparence -= Step;
        }
        GetComponent<CanvasGroup>().alpha = Transparence;
    }
}
