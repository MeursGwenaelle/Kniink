using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    public GameObject Dialogueboite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Dialogueboite.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialogueboite.SetActive(false);
    }
}
