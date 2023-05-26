
using UnityEngine;

public class PlayerMoveAndJump : MonoBehaviour
{
    private float horizontalMove;
    private bool isJumpingRequired;
    private bool isFalling;
    private bool isGrounded;
    private bool isMoving;
    private Vector2 zeroVelocity = Vector2.zero;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float initialGravityScale;
    private Animator animator;
    public float jumpforce = 4f;
    public bool isFacingRight;



    public ClePorte clePorte;
    public PorteRouge porteRouge;
    public PorteVerte porteVerte;
    public PorteNoire porteNoire;
    public PorteNoire1 porteNoire1;



    [SerializeField] private float speed = 6f;
    [SerializeField] private float movementSmoothing = 0.1f;
   // [SerializeField] private float maxFallingMagnitudeOnWall = 5f;
    //[SerializeField] private float velocityThreshold = 0.15f;
	//[SerializeField] private float fallGravityMultiplier = 4f;
	//[SerializeField] private float lowJumpGravityMultiplier = 5.5f;
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float groundCheckWidth;
    [SerializeField] private float groundCheckHeight;
    [SerializeField] private Transform groundCheck;
   
    private void Awake()
	{
        // On r�cup�re le composant Rigidbody2D du player
		rb = GetComponent<Rigidbody2D>();
        // On r�cup�re l'animateur du player
        animator = GetComponent<Animator>();

        // On m�morise l'echelle de gravit� de d�part
       // initialGravityScale = rb.gravityScale;


        // On r�cup�re le composant SpriteRenderer du player
        spriteRenderer = GetComponent<SpriteRenderer>();
        isFacingRight = true;
	}

    void Update()
    {
        Animation();
        // On r�cup�re une valeur qui vaudra -1 si on le joueur utilise la fleche gauche, 1 si il utilise la droite, et sinon 0
        horizontalMove = Input.GetAxisRaw("Horizontal");

        // Si on va � droite 
        if (horizontalMove > 0)
        {
            // On ne fait pas de sym�trie sur le sprite du player
            spriteRenderer.flipX = false;
            isFacingRight = true;
        } // Sinon ET Si on va � gauche
		else if (horizontalMove < 0)
        {
            // On fait une sym�trie sur le sprite du player
            spriteRenderer.flipX = true;
            isFacingRight = false;

        }

        if (Input.GetButtonDown("Jump") && (isGrounded))
        {
            // On dit qu'on veut sauter
            isJumpingRequired = true;
        }
        // Si il y a un mouvement horizontal
        if (horizontalMove != 0 && isGrounded && !isJumpingRequired){
            // On dit � l'animateur qu'on est en mode course
            animator.SetBool("Running", true);
        }else{// Sinon
            // On dit � l'animateur qu'on est PAS en mode course
            animator.SetBool("Running", false);
        }
    }

    void FixedUpdate() {

        // Une variable locale pour stocker la vitesse � appliquer, elle pourra �tre modifi�e avant utilisation !
        float tempSpeed = speed;

        // On test si une zone rectangulaire au niveau des pieds ("groundCheck") se superpose � un ou plusieurs �l�ments du calque sp�cifi� ("Ground")
        if (Physics2D.OverlapBox(groundCheck.position, new Vector2(groundCheckWidth,groundCheckHeight),0f, groundLayers)!=null)
        {
            // Si on ne touchait pas le sol avant
            if(isGrounded == false){
                // On vient de faire un Aterissage !

                //animator.SetBool("Jumping", false);   
                //animator.SetBool("Falling", false);
                //isFalling = false;

                // On passe la variable qui dit si on est au sol � VRAI
                isGrounded = true;
            }
        }
        else // SINON
        {
            // On touche pas le sol donc on passe la variable qui dit si on est au sol � FAUX
            isGrounded = false;
        }

        Vector2 targetVelocity = new Vector2(horizontalMove * tempSpeed, rb.velocity.y);
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref zeroVelocity, movementSmoothing);

        if (isJumpingRequired)
        {
            if (isGrounded)
            {
                //  rb.velocity = Vector2.up * jumpForce;
                rb.AddForce(transform.up * jumpforce,ForceMode2D.Impulse);
                isJumpingRequired = false;
            }

        }
    }

    private void Animation()
    {
        animator.SetFloat("VelocityY", rb.velocity.y);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("Jump", isJumpingRequired);
        animator.SetBool("BlueDoor", clePorte.BlueDoor);
        animator.SetBool("RedDoor", porteRouge.RedDoor);
        animator.SetBool("GreenDoor", porteVerte.GreenDoor);
        animator.SetBool("BlackDoor", porteNoire.BlackDoor);
        animator.SetBool("BlackDoorVerte", porteNoire1.BlackDoorVerte);
       
    }
    void OnDrawGizmos()
    {
        // Dessine un cube vert � la position du groundCheck
        Gizmos.color = new Color32(0, 255, 0, 90);
        Gizmos.DrawCube(groundCheck.position, new Vector2(groundCheckWidth, groundCheckHeight));
       
    }
}
