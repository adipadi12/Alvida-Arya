using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;

    void Start()
    {
        UpdateUI(GameState.MainMenu);
    }

    void Update()
    {
        UpdateUI(GameManager.Instance.CurrentState);
    }

    private void UpdateUI(GameState state) // UI update based on game state instead of polling every frame
    {
        // sets the panel active based on the current game state
        menuPanel.SetActive(state == GameState.MainMenu);
        hudPanel.SetActive(state == GameState.Playing);
        gameOverPanel.SetActive(state == GameState.GameOver);
    }

    public void OnStartPressed()
    {
        GameManager.Instance.SetState(GameState.Playing);
    }

    public void OnRestartPressed()
    {
        PlayerInteraction.Instance.ResetPlayer();
        FindAnyObjectByType<EnemySpawner>().ResetSpawner();
        GameManager.Instance.SetState(GameState.MainMenu);
    }
}
