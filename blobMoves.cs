using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobMoves : MonoBehaviour
{
    private float horizontalMove;
    private bool isJumping;
    private bool isRising;
    private bool isFalling;
    private bool isGrounded;
    private bool isCeiled;
    private Vector2 zeroVelocity = Vector2.zero;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float initialGravityScale;
    private Animator animator;
    public float timeOnCeiling;
    private float speedModifier = 1f;
    

    // Créer un Animator avec 3 Paramètres Bool pour les conditions de transition
    // Rising
    // Running
    // Falling

    [SerializeField] private float speed = 6f;
    [SerializeField] private float movementSmoothing = 0.2f;
    [SerializeField] private float jumpForce = 6.5f;
    [SerializeField] private float jumpingVelocityThreshold = 1f;
    [SerializeField] private float fallingVelocityThreshold = 1f;
	[SerializeField] private float fallGravityMultiplier = 2.2f;
	[SerializeField] private float lowJumpGravityMultiplier = 2.5f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundedRadius = 0.25f;	
    [SerializeField] private Transform ceilCheck;
    [SerializeField] private float ceilRadius = 0.25f;
    [SerializeField] private float maxTimeOnCeiling = 2f;		
    [SerializeField] private float ceilForce = 0f;	
    [SerializeField] private float ceilSpeedModifier = 0.2f;
    [SerializeField] private Transform wallCheckLeft;
    [SerializeField] private float wallCheckLeftRadius = 0.25f;
    [SerializeField] private Transform wallCheckRight;
    [SerializeField] private float wallCheckRightRadius = 0.25f;

    private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
        initialGravityScale = rb.gravityScale;

        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove > 0)
        {
            spriteRenderer.flipX = false;
        }
		else if (horizontalMove < 0)
        {
            spriteRenderer.flipX = true;
        }

        if(horizontalMove!=0)
        {
            //animator.SetBool("Running", true);
        }else{
            //animator.SetBool("Running", false);
        }

       if(Physics2D.OverlapCircle(groundCheck.position, groundedRadius, groundLayers)!=null){
            // On touche le sol

            // Atterissage ?
            if(!isGrounded && isFalling){
                // on ne le touchait pas à la frame d'avant ET on était en chute
                // donc on vient d'atterir
            }
            
            // Tentative de saut
            if(Input.GetButtonDown("Jump"))
            // On vient d'appuyer sur "Saut"
            {
                isJumping = true;
            }

            // On touche le sol
            isGrounded = true;
        }else{
            // On ne touche pas le sol
            isGrounded = false;
            if(Physics2D.OverlapCircle(ceilCheck.position, ceilRadius, groundLayers)!=null){
                // On touche le plafond
                if(!isCeiled){
                    // On commence à toucher le plafond
                    isCeiled = true;
                    timeOnCeiling = 0f;        
                }   
            }else{
                isCeiled = false;
                timeOnCeiling = 0f;
                rb.gravityScale = initialGravityScale;
            }
        }

        if(isCeiled){
            timeOnCeiling += Time.deltaTime;
            if(timeOnCeiling < maxTimeOnCeiling){
                // On peut rester au plafond
                rb.gravityScale = 0;
            }else{
                // Il est temps de tomber
                rb.gravityScale = initialGravityScale;
            }
            speedModifier = ceilSpeedModifier;
        }else{
            speedModifier = 1f;
        }

        if (!isCeiled && !isGrounded)
        {
            if (Physics2D.OverlapCircle(wallCheckLeft.position, wallCheckLeftRadius, groundLayers) != null)
            {
                // On touche le mur à gauche

            }else if (Physics2D.OverlapCircle(wallCheckRight.position, wallCheckRightRadius, groundLayers) != null)
            {
                // On touche le mur à droite
            }
        }
    }

    void FixedUpdate() {
        Vector2 targetVelocity = new Vector2(horizontalMove * speed * speedModifier, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref zeroVelocity, movementSmoothing);
        
        if(isJumping){
            isJumping = false;
            rb.velocity = Vector2.up * jumpForce;
        }

        if(rb.velocity.y < -fallingVelocityThreshold){
            // Chute
            //animator.SetBool("Falling", true); 
            isFalling = true;
            rb.gravityScale = initialGravityScale * fallGravityMultiplier;
        }else{
            //animator.SetBool("Falling", false); 
            isFalling = false;
        }
        
        if(rb.velocity.y > jumpingVelocityThreshold){
            // Elevation
            if(Input.GetButton("Jump")){
                rb.gravityScale = initialGravityScale ;
            }else{
                rb.gravityScale = initialGravityScale * lowJumpGravityMultiplier;
            } 
            //animator.SetBool("Rising", true);
            isRising = true;
        }else{
            //animator.SetBool("Rising", false);
            isRising = false;
        }

        // if(isCeiled){
        //      rb.velocity = Vector2.up * ceilForce;
        // }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.25f);
        Gizmos.DrawSphere(groundCheck.position, groundedRadius);
        Gizmos.DrawSphere(ceilCheck.position, ceilRadius);
        Gizmos.DrawSphere(wallCheckLeft.position, wallCheckLeftRadius);
        Gizmos.DrawSphere(wallCheckRight.position, wallCheckRightRadius);
    }

    void DoDie()
    {
        print("Je suis mort !");
    }
}
