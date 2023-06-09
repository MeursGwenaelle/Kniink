using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    private float timeSinceLastShot = 0f;
    [SerializeField] private float shootingInterval = 2f;
    
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject Projectile;

    [SerializeField] private float range = 5f;

    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private int ProjectileDamage = 15;
    [SerializeField] private float ProjectileSpeed;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        timeSinceLastShot += Time.deltaTime;
        if (distance <= range) //si on est dans la distance de tir
        {
                
                Vector2 direction = player.transform.position - transform.position;
                RaycastHit2D hit = Physics2D.Raycast(transform.position, direction,distance, groundLayers);
               
            if (hit.transform ==null)
            {

                if (timeSinceLastShot >= shootingInterval)
                {
                    //On remet le compteur � 0
                    timeSinceLastShot = 0f;
                    //calcul de l'angle entre les 2vect en degr�, 
                    float angle = Vector2.SignedAngle(Vector2.right, direction.normalized) ;
                    GameObject projectile = Instantiate (Projectile, transform.position, Quaternion.Euler(0,0,angle));
                    projectile.GetComponent<Projectile>().setDamage(ProjectileDamage);
                    projectile.GetComponent<Projectile>().setSpeed(ProjectileSpeed);


                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 direction = player.transform.position - transform.position;
        Gizmos.DrawRay(transform.position, direction.normalized * range);
    }   
}
