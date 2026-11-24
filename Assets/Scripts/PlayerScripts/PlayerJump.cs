using UnityEngine;
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.Instance.PlayJump();

            // Warning: "Grounded" es un string mágico, igual que "Speed", "Shoot", "Hurt", "Death" y "Recharge" en los demás scripts.
            // Un error de tipeo no da error de compilación. Cacheá el ID: private static readonly int GroundedHash = Animator.StringToHash("Grounded");
            animator.SetBool("Grounded", false);

            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x,
                playerData.jumpForce
            );

            isGrounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Warning: isGrounded solo vuelve a true al chocar con un objeto que tenga Ground. Si el jugador cae sobre un Barrel queda sin poder saltar.
        // Usá un chequeo por LayerMask (Physics2D.OverlapCircle en los pies) en lugar de depender del componente Ground.
        if (collision.gameObject.GetComponent<Ground>() != null)
        {
            isGrounded = true;
            animator.SetBool("Grounded", true);
        }
    }
}