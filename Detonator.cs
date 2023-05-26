using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonator : MonoBehaviour
{
    [SerializeField] private int detonatorId;
    public Bomb[] tabBombs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tabBombs = FindObjectsOfType(typeof(Bomb)) as Bomb[];

        foreach (Bomb bomb in tabBombs)
        {
            bomb.Detonate(detonatorId);
        }

        /*
        for (int i=0;i<tabBombs.Length;i++)
        {
            Bomb bomb = tabBombs[i];
            bomb.Detonate(detonatorId);
        }
        */
    }
}
