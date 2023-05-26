using UnityEngine;

public class PlateformeTimerPlus : MonoBehaviour
{
    [SerializeField] private float timeToLive = 3f;
    private Rigidbody2D rb;
    private BoxCollider2D myCollider;
    private int nbObjects;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        myCollider = GetComponent<BoxCollider2D>();
        nbObjects = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                // On ajoute 1  au nombre d'objet en collision
                nbObjects += 1;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Rigidbody2D rb))
        {
            if (rb.bodyType == RigidbodyType2D.Dynamic)
            {
                // On enleve 1  au nombre d'objet en collision
                nbObjects -= 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (nbObjects>0)
        {
            timeToLive -= Time.fixedDeltaTime;
            if (timeToLive <= 0)
            {
                rb.constraints = RigidbodyConstraints2D.None;
                myCollider.enabled = false;
                Destroy(gameObject,5f);
            }
        }
    }
}
