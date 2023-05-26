using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeAndDeath : MonoBehaviour
{
    [SerializeField] public int hpMax = 4;
    [SerializeField] public int hp;
    [SerializeField] private float respawnTime = 2.5f;
    [SerializeField] public Vector3 spawnPointPosition;
    [SerializeField] private MonoBehaviour playerControlerScript;
    private Rigidbody2D rb;
    public HealthController healthController;
    public SpriteRenderer spriteRenderer;
    Color originalColor;
    public float Flashtime = 0.5f;

    void Awake()
    {

    }    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        Spawn();
    }


  
    public void takeDamages(int damage)
    {
        hp -= damage;
        healthController.SetMaxHealth(hp);
        print(damage);

        DamageFlashStart();
        StartCoroutine("GetIFrames");


        if (hp <= 0)
        {
            
            playerControlerScript.enabled = false;
            Invoke("Spawn", respawnTime);
        }
    }


    public void updateSpawnPosition(Vector3 newPosition)
    {
        spawnPointPosition = newPosition;

    }

    private void Spawn()
    {
        playerControlerScript.enabled = true;
        hp = hpMax;
        rb.velocity = Vector2.zero;
        transform.position = spawnPointPosition;
        healthController.SetMaxHealth(hpMax);
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

    IEnumerator GetIFrames()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        yield return new WaitForSeconds(Flashtime);
        Physics2D.IgnoreLayerCollision(6, 7, false);

    }
}
