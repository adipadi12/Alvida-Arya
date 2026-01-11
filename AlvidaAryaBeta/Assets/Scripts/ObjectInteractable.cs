using UnityEngine;

public class ObjectInteractable : MonoBehaviour, IInteractables
{
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        // Add interaction logic here (e.g., open door, pick up item, etc.)
        Color color = Color.red;
        GetComponent<Renderer>().material.color = color;
        PlayerInteraction.Instance.score += 10;
    }
}
