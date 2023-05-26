using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed = 5f;
    [SerializeField] private int damages = 1;
    public LifeAndDeath lifeAndDeath;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            lifeAndDeath = collision.gameObject.GetComponent<LifeAndDeath>();
            lifeAndDeath.takeDamages(damages);
        }
        Destroy(gameObject);
    }

    public void setSpeed (float newSpeed)
    {
        speed = newSpeed;
    }

    public void setDamage (int newDamage)
    {
        damages = newDamage;
    }
}
