using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteNoire1 : MonoBehaviour
{
    public GameObject porte1;

    public bool BlackDoorVerte;
    public Inventaire inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.ContainsObjects("Key black"))
        {
            Invoke("DoorOpen", 3);

            BlackDoorVerte = true;

        }
    }



    private void DoorOpen()
    {


        porte1.SetActive(false);

        BlackDoorVerte = false;

    }
}
