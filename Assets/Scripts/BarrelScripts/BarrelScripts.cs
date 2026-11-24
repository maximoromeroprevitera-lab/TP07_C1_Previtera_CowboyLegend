using UnityEngine;
// Error: La clase Barrel está en un archivo que se llama distinto (BarrelScripts.cs).
// Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
public class Barrel : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
