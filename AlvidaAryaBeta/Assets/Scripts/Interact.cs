using UnityEngine;

public class Interact : MonoBehaviour
{
    public float interactDistance = 3f;
    public LayerMask interactableLayer;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.DrawRay(transform.position, transform.forward * interactDistance, Color.black, 2f);
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.forward, out hit, interactDistance, interactableLayer))
            {
                InteractableObjects interactable = hit.collider.GetComponent<InteractableObjects>();
                Debug.Log("Hit: " + hit.collider.name);
                if(interactable != null)
                {
                    interactable.Interact();
                    if(hit.collider.GetComponent<Renderer>() != null)
                    {
                        hit.collider.GetComponent<Renderer>().material.color = Color.red;
                    }
                }
            }
        }
    }
}
