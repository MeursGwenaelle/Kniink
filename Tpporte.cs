using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tpporte : MonoBehaviour
{
    public GameObject PortailPorte;
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.transform.position = PortailPorte.transform.position;

    }


}
