using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    // Warning: player es public y mutable. Pasalo a [SerializeField] private Transform player;
    public Transform player;
    // Suggestion: smoothSpeed no se usa en ningún lado, la cámara copia la posición sin suavizado. Usalo con Vector3.Lerp o borralo.
    public float smoothSpeed = 5f;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
    }
    // Suggestion: El seguimiento de cámara va en LateUpdate, así se mueve después de que el jugador ya se movió en el frame y evitás jitter.
    private void Update()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}