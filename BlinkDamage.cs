using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkDamage : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    Color originalColor;
    float Flashtime = .15f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

  
    void DamageFlashStart()
    {

        spriteRenderer.color = new Color(0f, 0f, 0f, 1f);
        Invoke("DamageFlashStop", Flashtime);

    }

    void DamageFlashStop()
    {
        spriteRenderer.color = originalColor;
    }
    void CollisionEnter2D(Collider2D collision)
    {       
        
        if (collision.gameObject.tag == "Enemy")
        {       
            print("Enemy hit");

            DamageFlashStart();
        } 
    }
}
