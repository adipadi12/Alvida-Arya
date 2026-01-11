using UnityEngine;

public class EnemyInteractable : MonoBehaviour, IInteractables
{

    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        TakeDamage(20);
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
        GameManager.Instance.SetState(GameState.GameOver); // when dying we set the game state to GameOver
        Debug.Log("Game Over!");
    }
}