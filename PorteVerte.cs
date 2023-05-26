using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteVerte : MonoBehaviour
{
    public GameObject porte1;
    public bool GreenDoor;


    public Inventaire inventory;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.ContainsObjects("Key green"))
        {
            Invoke("DoorOpen", 3);

            GreenDoor = true;

        }
    }



    private void DoorOpen()
    {


        porte1.SetActive(false);

        GreenDoor = false;

    }
}
