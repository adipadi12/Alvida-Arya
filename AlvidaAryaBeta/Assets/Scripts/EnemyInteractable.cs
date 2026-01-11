using System;
using UnityEngine;

public class EnemyInteractable : MonoBehaviour, IInteractables
{

    [SerializeField] private int damageToPlayer = 20;
    [SerializeField] private int scoreOnKill = 20;
    public void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
        Killed();
    }

    private void OnTriggerEnter(Collider other) // i use trigger instead of collision to avoid expensive physics on mobile
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }

        PlayerInteraction.Instance.health -= damageToPlayer;
        Debug.Log("Player hit by " + gameObject.name + ". Health reduced by " + damageToPlayer);
    }

    private void Killed()
    {
        Debug.Log(gameObject.name + " Killed.");
        PlayerInteraction.Instance.score += scoreOnKill;
        gameObject.SetActive(false);
    }
}