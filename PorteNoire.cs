using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteNoire : MonoBehaviour
{
    public GameObject porte1;

    public bool BlackDoor;
    public Inventaire inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.ContainsObjects("Key black"))
        {
            Invoke("DoorOpen", 3);

            BlackDoor = true;

        }
    }



    private void DoorOpen()
    {


        porte1.SetActive(false);

        BlackDoor = false;

    }
}
