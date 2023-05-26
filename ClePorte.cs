using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClePorte : MonoBehaviour
{

    public GameObject porte1;
    public bool BlueDoor;


    public Inventaire inventory;


   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inventory.ContainsObjects("Key blue"))
        {
            Invoke("DoorOpen", 3);

            BlueDoor = true;
          
        }
    }


    
    private void DoorOpen()
    {
       
        
        porte1.SetActive(false);

        BlueDoor = false;
       
    }
}
