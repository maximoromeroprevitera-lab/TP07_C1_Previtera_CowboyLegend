using UnityEngine;
public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float stopDistance = 4f;
    private void Update()
    {
        if (player == null)
        {
            return;
        }

        float distance = Vector2.Distance(
            transform.position,
            player.position
        );

        if (distance > stopDistance)
        {
            Vector2 direction = player.position - transform.position;
            direction.Normalize();

            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }
    }
}