using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float offsetY = 5f;
    [SerializeField] private float offsetZ = -10f;
    private Vector3 offset;

    void Awake()
    {
        offset = new Vector3(0, offsetY, offsetZ);
        if(!playerTransform)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player")?.transform;
        }
    }

    void LateUpdate() // late update avoids camera jitters and follows after movement
    {
        if (playerTransform != null)
        {
            transform.position = playerTransform.position + offset;
        }
    }
}
