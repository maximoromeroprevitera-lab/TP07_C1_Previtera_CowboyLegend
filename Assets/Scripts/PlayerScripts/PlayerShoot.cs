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

        bulletRb.linearVelocity = Vector2.right * bulletSpeed;

        Destroy(bullet, bulletLifetime);
    }
}