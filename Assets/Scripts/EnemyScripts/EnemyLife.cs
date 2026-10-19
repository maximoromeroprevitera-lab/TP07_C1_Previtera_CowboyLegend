using UnityEngine;
public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private EnemyHealthBar healthBar;
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private GameObject ammoBoxPrefab;
    [SerializeField] private float dropOffsetY = -0.75f;
    private int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        AudioManager.Instance.PlayEnemyHit();
        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            AudioManager.Instance.PlayEnemyDeath();
            Die();
        }
    }
    private void Die()
    {
        Instantiate(
            deathParticles,
            transform.position,
            Quaternion.identity
        );

        Instantiate(
            ammoBoxPrefab,
            new Vector2(transform.position.x, transform.position.y + dropOffsetY),
            Quaternion.identity
        );
        Destroy(gameObject);
    }
}