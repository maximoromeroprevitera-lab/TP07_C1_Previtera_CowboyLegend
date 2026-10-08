using UnityEngine;
public class EnemyBulletCollision : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerLife player = collision.GetComponent<PlayerLife>();

        if (player != null)
        {
            player.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}