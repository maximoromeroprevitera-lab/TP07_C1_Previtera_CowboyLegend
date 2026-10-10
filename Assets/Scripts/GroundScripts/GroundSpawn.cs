using UnityEngine;
public class GroundSpawn : MonoBehaviour
{
    public Transform player;
    public float groundWidth = 20f;
    private float startY;
    private float startZ;
    private void Start()
    {
        startY = transform.position.y;
        startZ = transform.position.z;
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        if (player.position.x - transform.position.x > groundWidth)
        {
            transform.position = new Vector3(
                transform.position.x + groundWidth * 3f,
                startY,
                startZ
            );
        }
    }
}