using UnityEngine;
public class PlayerLife : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField] private PlayerDataSO playerData;
    private int currentHealth;
    private void Start()
    {
        currentHealth = playerData.maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > playerData.maxHealth)
        {
            currentHealth = playerData.maxHealth;
        }

        Debug.Log("Player health: " + currentHealth);
    }
    private void Die()
    {
        gameManager.GameOver();
        Debug.Log("Player defeated");
    }
}
