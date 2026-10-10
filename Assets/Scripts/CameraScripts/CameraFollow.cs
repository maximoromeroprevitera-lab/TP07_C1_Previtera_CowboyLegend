using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
    }
    private void Update()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position + offset;

            transform.position = Vector3.Lerp(
                transform.position,
                newPosition,
                smoothSpeed * Time.deltaTime
            );
        }
    }
}