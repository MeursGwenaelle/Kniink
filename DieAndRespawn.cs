using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAndRespawn : MonoBehaviour
{
    [SerializeField] private bool autoRespawn;
    [SerializeField] private float respawnTime = 0f;
    private Vector2 initialPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
    }

    public void DoDie()
    {
        if (autoRespawn)
        {
            Invoke("Respawn", respawnTime);
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Respawn()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.rotation = Quaternion.identity;
        transform.position = initialPosition;
    }
}
