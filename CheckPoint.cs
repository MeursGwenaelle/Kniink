using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    Color originalColor;
    public float Flashtime = 0.5f;


    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<LifeAndDeath>().updateSpawnPosition(transform.position);
            spriteRenderer.color = new Color(201f, 220f, 243f, 1f);
            Invoke("DamageFlashStop", Flashtime);
        }

    }

    void DamageFlashStop()
    {
        spriteRenderer.color = originalColor;


    }
}
