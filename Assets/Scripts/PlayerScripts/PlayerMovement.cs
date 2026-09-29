using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;

    private Rigidbody2D rb;
    private float horizontalInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
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