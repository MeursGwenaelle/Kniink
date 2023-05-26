using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteRouge : MonoBehaviour
{
    public GameObject porte1;
    public bool RedDoor;


    public Inventaire inventory;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.ContainsObjects("Key red"))
        {
            Invoke("DoorOpen", 3);

            RedDoor = true;

        }
    }



    private void DoorOpen()
    {


        porte1.SetActive(false);

        RedDoor = false;

    }
}
