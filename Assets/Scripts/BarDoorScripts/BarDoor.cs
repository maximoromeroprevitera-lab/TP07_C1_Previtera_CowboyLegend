using UnityEngine;
public class BarDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerLife player = collision.GetComponentInParent<PlayerLife>();

        if (player != null)
        {
            // Warning: FindFirstObjectByType en runtime y sin null check: si no hay VictoryManager en la escena tira NullReferenceException.
            // Pasale la referencia al instanciar la puerta desde BarDoorSpawner.
            FindFirstObjectByType<VictoryManager>().Win();
        }
    }
}