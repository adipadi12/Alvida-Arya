using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static PlayerInteraction Instance { get; private set; }
    [SerializeField] private float interactionRange = 3f;
    [SerializeField] private LayerMask interactableLayerMask;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI scoreText;
    public int health = 100;
    public int score = 0;

    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    void Update() // interface based interaction to decouple player logic from other interactable objects
    {
        InteractionStart();

        ScoreUpdate();

        HealthUpdate();

        CheckForDeath();
    }

    private void InteractionStart()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Debug.DrawRay(transform.position, transform.forward * interactionRange, Color.black, 2f);

            if(Physics.Raycast(transform.position, 
                               transform.forward, 
                               out RaycastHit hitInfo, 
                               interactionRange, 
                               interactableLayerMask))
            {
                IInteractables interactables = hitInfo.collider.GetComponent<IInteractables>();
                Debug.Log("Hit: " + hitInfo.collider.name);
                
                if(interactables != null)
                {                    
                    interactables.Interact(); 
                }
            }
        }
    }

    private void CheckForDeath()
    {
        if(health <= 0)
        {
            Debug.Log("Player Dead.");
            GameManager.Instance.SetState(GameState.GameOver);
            gameObject.SetActive(false);
        }
    }

    public void ResetPlayer()
    {
        health = 100;
        score = 0;
        ScoreUpdate();
        HealthUpdate();
        gameObject.SetActive(true);
    }

    private void ScoreUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    private void HealthUpdate()
    {
        healthText.text = "Health: " + health;
    }
}
