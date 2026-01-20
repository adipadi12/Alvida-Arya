using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int poolSize = 5;
    [SerializeField] private float spawnRadius = 10f;
    [SerializeField] private float spawnInterval = 1.5f;

    private List<GameObject> enemyPool = new List<GameObject>();
    private float spawnTimer;
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        CreatePool();
    }

    void Update()
    {
        if(GameManager.Instance.CurrentState != GameState.Playing)
        {
            return; // only spawn enemies when the game is in Playing state
        }

        spawnTimer += Time.deltaTime; // increment timer

        if (spawnTimer >= spawnInterval) // spawn enemy at intervals
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    private void CreatePool() // avoided runtime instantiation and destroy calls by pooling enemies for mobile performance
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);
            enemyPool.Add(enemy);
        }
    }

    private void SpawnEnemy() // spawns an enemy at a random position within the spawn radius
    {
        GameObject enemy = GetPooledEnemy();
        if (enemy == null)
        {
            return;
        }
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.y = 0f; // keep on ground level

        enemy.transform.position = spawnPosition;
        enemy.SetActive(true);
    }

    private GameObject GetPooledEnemy() // checks for inactive enemies in the pool
    {
        foreach (var enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy)
            {
                return enemy;
            }
        }
        return null;
    }

    public void ResetSpawner() // resets all enemies in the pool
    {
        foreach (var enemy in enemyPool)
        {
            enemy.SetActive(false);
        }
        spawnTimer = 0f;
    }
}
