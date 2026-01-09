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
    void Update()
    {
        InteractionStart();

        ScoreUpdate();

        HealthUpdate();
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
    private void ScoreUpdate()
    {
        scoreText.text = "Score: " + score;
    }

    private void HealthUpdate()
    {
        healthText.text = "Health: " + health;
    }
}
