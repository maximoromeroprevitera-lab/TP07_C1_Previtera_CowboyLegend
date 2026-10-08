using UnityEngine;
public class PlayerLife : MonoBehaviour
{
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
    private void Die()
    {
        Debug.Log("Player defeated");
    }
}
