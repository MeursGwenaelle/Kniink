using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBloc : MonoBehaviour
{
    public GameObject Bloc;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Bloc.SetActive(true);
    }
}
