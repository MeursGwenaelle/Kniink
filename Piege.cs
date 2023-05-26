using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piege : MonoBehaviour
{
    public float degats = 10f;

    private void OnTriggerEnter(Collider autre)
    {
        print(autre.gameObject.name + " viens de me rentrer dedans !");
        autre.gameObject.SendMessage("RecevoirDegats", degats);
    }
}
