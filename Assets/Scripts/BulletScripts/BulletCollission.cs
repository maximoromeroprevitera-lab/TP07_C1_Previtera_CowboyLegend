using UnityEngine;
// Suggestion: Collission tiene un error de ortografía (Collision). Renombrá clase y archivo, igual que EnemyBulletCollision.
public class BulletCollission : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Barrel barrel = collision.GetComponent<Barrel>();

        if (barrel != null)
        {
            barrel.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        EnemyLife enemy = collision.GetComponent<EnemyLife>();

        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
