using UnityEngine;

public class InteractableObjects : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 3f);
    }

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }
}
