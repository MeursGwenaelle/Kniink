using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class totemheal : MonoBehaviour
{
    [SerializeField] public LifeAndDeath lifeAndDeath;
    public HealthController healthController;
    
    public int healthBonus = 3;


    void Start()
    {
        lifeAndDeath = FindObjectOfType<LifeAndDeath>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lifeAndDeath.hp < lifeAndDeath.hpMax)
        {
            Destroy(gameObject);
            lifeAndDeath.hp = lifeAndDeath.hp + healthBonus;
            if (lifeAndDeath.hp > lifeAndDeath.hpMax)
            {
                lifeAndDeath.hp = lifeAndDeath.hpMax;
                healthController.SetMaxHealth(healthBonus);

            }
        }

    }

}