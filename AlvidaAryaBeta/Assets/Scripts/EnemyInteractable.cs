using UnityEngine;

public class EnemyInteractable : MonoBehaviour, IInteractables
{

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        // Add interaction logic here (e.g., attack enemy, etc.)
        TakeDamage(20);
        FindAnyObjectByType<PlayerInteraction>().GetComponent<Renderer>().material.color = Color.red;
    }

    private void TakeDamage(int damage)
    {
        PlayerInteraction.Instance.health -= damage;
        Debug.Log(gameObject.name + " took " + damage + " damage. Remaining health: " + PlayerInteraction.Instance.health);
        if (PlayerInteraction.Instance.health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died.");
        Destroy(FindAnyObjectByType<PlayerInteraction>().gameObject);
    }
}