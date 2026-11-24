using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float bulletLifetime = 2f;
    [SerializeField] private float shootCooldown = 0.5f;
    private PlayerAmmo ammo;
    private Animator animator;
    private float cooldownTimer;
    private void Awake()
    {
        ammo = GetComponent<PlayerAmmo>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Bug: El input se procesa aunque Time.timeScale sea 0 (pausa, game over, victoria) o el jugador esté muerto (PlayerLife.IsDead).
        // Con el juego pausado apretás J, se instancia la bala, suena el disparo y se gasta munición. Salí del Update si Time.timeScale <= 0f o si el jugador murió (pasa lo mismo con Space en PlayerJump.Update).
        if (Input.GetKeyDown(KeyCode.J) &&
            cooldownTimer <= 0 &&
            ammo.CanShoot)
        {
            Shoot();
            ammo.UseBullet();

            cooldownTimer = shootCooldown;

            animator.SetTrigger("Shoot");

            AudioManager.Instance.PlayShoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(
            bulletPrefab,
            shootPoint.position,
            shootPoint.rotation
        );

        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Bug: La bala siempre sale con Vector2.right, aunque el personaje mire a la izquierda (spriteRenderer.flipX en PlayerMovement).
        // Hacia la izquierda no se puede disparar. Calculá la dirección según flipX (o el último input) y espejá también la posición de shootPoint.
        bulletRb.linearVelocity = Vector2.right * bulletSpeed;

        Destroy(bullet, bulletLifetime);
    }
}