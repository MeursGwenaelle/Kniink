using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parchemin : MonoBehaviour
{
    public GameObject ParcheminGame;
    public GameObject ParcheminButton;
    public GameObject ParcheminContainer;


    public void OnTriggerEnter2D(Collider2D other)
    {
        ParcheminGame.SetActive(false);
        ParcheminButton.SetActive(true);
    }

    public void ParcheminOpen()
    {
        ParcheminContainer.SetActive(true);
    }

    public void ParcheminClose()
    {
        ParcheminContainer.SetActive(false);
    }
}