using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;
    private Rigidbody2D rb;
    private float horizontalInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (horizontalInput != 0 && isGrounded)
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