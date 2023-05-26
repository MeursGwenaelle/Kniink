using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int attack = 3;
    public VieMechant vieMechant;
    public ink Ink;
    public int ink = 1;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<VieMechant>() != null)
        {
            vieMechant = collider.GetComponent<VieMechant>();
            vieMechant.Damage(attack);
            Ink.UpdateInk(ink);
        }
    }

   
}