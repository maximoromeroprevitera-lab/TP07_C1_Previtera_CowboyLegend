using UnityEngine;
// Error: La clase AmmoPickup está en un archivo que se llama distinto (AmmoPickUp.cs, difiere en mayúsculas). Unity lo compila pero tira un warning: renombrá el archivo o la clase para que coincidan.
public class AmmoPickup : MonoBehaviour
{
    [SerializeField] private int amount = 4;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerAmmo playerAmmo = collision.GetComponentInParent<PlayerAmmo>();

        if (playerAmmo != null)
        {
            // Error: Agarrar la munición no tiene feedback sonoro, y la consigna lo pide para "Agarrar coleccionable".
            // Agregá un AudioClip de pickup en AudioManager y llamalo acá antes del Destroy.
            playerAmmo.AddAmmo(amount);
            Destroy(gameObject);
        }
    }
}