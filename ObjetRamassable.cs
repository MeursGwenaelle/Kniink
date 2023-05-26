using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetRamassable : MonoBehaviour
{
    private void OnTriggerEnter(Collider autre)
    {
        autre.gameObject.SendMessage("AjouterObjet", gameObject);
    }
}
