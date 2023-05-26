using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkHeal : MonoBehaviour
{
    [SerializeField] public LifeAndDeath lifeAndDeath;
    [SerializeField] private ink Ink;
    [SerializeField] private InkController inkController;
    [SerializeField] public HealthController healthController;

    public int HealthInk = 1;
    public int InkCost = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            Heal();

        }
    }

    public void Heal()
    {
        if(lifeAndDeath.hp < lifeAndDeath.hpMax && Ink.CurrentInk >= 3)
        {
            lifeAndDeath.hp = lifeAndDeath.hp + HealthInk;
            healthController.SetMaxHealth(lifeAndDeath.hp);
            Ink.CurrentInk -= InkCost;
            inkController.SetMaxInk(Ink.CurrentInk);
        }

    }
}
