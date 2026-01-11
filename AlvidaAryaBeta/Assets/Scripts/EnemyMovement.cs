using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float stopDistance = 1.5f;

    private Transform playerTransform;

    void OnEnable()
    {
        if(PlayerInteraction.Instance != null)
        {
            playerTransform = PlayerInteraction.Instance.transform;
        }
    }

    void Update()
    {
        if(GameManager.Instance.CurrentState != GameState.Playing)
        {
            return; // only move enemies when the game is in Playing state
        }

        if (playerTransform == null)
        {
            return;
        }

        Vector3 direction = playerTransform.position - transform.position;
        direction.y = 0; // keep movement horizontal

        float distance = direction.magnitude;

        if(distance <= stopDistance)
        {
            return; // stop moving if within stop distance
        }

        transform.position += direction.normalized * moveSpeed * Time.deltaTime; // move towards player without using AI nav mesh
    }
}
