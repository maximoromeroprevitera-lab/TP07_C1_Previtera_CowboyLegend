using UnityEngine;
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float bulletSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
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
    }
}