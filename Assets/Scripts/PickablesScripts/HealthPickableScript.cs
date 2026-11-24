using UnityEngine;
// Error: La clase HealthPickable está en un archivo que se llama distinto (HealthPickableScript.cs).
// Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
public class HealthPickable : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Suggestion: Acá usás GetComponent y en AmmoPickup y EnemyBulletCollision GetComponentInParent. Unificá el criterio para que no dependa de dónde está el collider del Player.
        PlayerLife player = collision.GetComponent<PlayerLife>();

        if (player != null)
        {
            player.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}