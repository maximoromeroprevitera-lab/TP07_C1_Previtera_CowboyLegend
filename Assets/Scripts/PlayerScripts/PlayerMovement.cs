using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private Animator animator;
    private float horizontalInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
        }

        // Warning: StartRunning se llama aunque el jugador esté en el aire, muerto o con el juego en pausa (Update corre igual con timeScale 0).
        // El sonido de correr puede sonar con el panel de pausa abierto. Condicioná también por suelo, muerte y pausa.
        if (horizontalInput != 0)
        {
            AudioManager.Instance.StartRunning();
        }
        else
        {
            AudioManager.Instance.StopRunning();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        rb.linearVelocity = new Vector2(
            horizontalInput * playerData.moveSpeed,
            rb.linearVelocity.y
        );
    }
}
