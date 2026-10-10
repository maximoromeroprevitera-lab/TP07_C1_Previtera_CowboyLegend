using UnityEngine;
public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private EnemyHealthBar healthBar;
    [SerializeField] private GameObject deathParticles;
    private int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth, maxHealth);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
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
        Destroy(gameObject);
    }
}