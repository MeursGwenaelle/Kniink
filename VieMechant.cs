using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class VieMechant : MonoBehaviour
{

    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;

    }

    public void Damage(int attack)
    {
        health -= attack;
        if (health <= 0)
        {
            Die();
        }
    }

   
   

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attackarea")
        {
            Invoke("Damage", 20f);
            print("touche");


        }
    }

}

