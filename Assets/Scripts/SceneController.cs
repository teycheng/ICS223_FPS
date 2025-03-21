using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField]
    private GameObject enemyPrefab;
    private GameObject enemy;
    private GameObject[] enemies;
    private Vector3 spawnPoint = new Vector3 (0, 0, 5);
    private int enemiesCount = 5;
    [SerializeField] private GameObject iguanaPrefab;
    private GameObject[] iguanas;
    [SerializeField] private Transform iguanaSpawnPoint;
    private int iguanasCount = 10;
    [SerializeField] private UIManager ui;
    private int score = 0;


    private void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.AddListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_DEAD, OnEnemyDead);
        Messenger<int>.RemoveListener(GameEvent.DIFFICULTY_CHANGED, OnDifficultyChanged);
    }

    void Start()
    {

        ui.UpdateScore(score);
        // Allocate the array
        enemies = new GameObject[enemiesCount];
        iguanas = new GameObject[iguanasCount];
        // Spawn initial enemies
        for (int i = 0; i < enemiesCount; i++)
        {
            CreateEnemy(i);
        }
        for (int i = 0; i < iguanasCount; i++)
        {
            CreateIguana(i);
        }
    }
    private void OnEnemyDead()
    {
        score++;
        ui.UpdateScore(score);
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < enemies.Length; i++) {
            if (enemies[i] == null) {
                CreateEnemy(i);
                WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
                ai.SetDifficulty(GetDifficulty());
            }
        }
    }

    void CreateEnemy(int i){
        // Instantiate and store the enemy
        enemies[i] = Instantiate(enemyPrefab);
        enemies[i].transform.position = spawnPoint;
        // Apply a random rotation
        float angle = Random.Range(0, 360);
        enemies[i].transform.Rotate(0, angle, 0);
        WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
        ai.SetDifficulty(GetDifficulty());
    }

    void CreateIguana(int i)
    {
        iguanas[i] = Instantiate(iguanaPrefab);
        iguanas[i].transform.position = iguanaSpawnPoint.position;
        // Apply a random rotation
        float angle = Random.Range(0, 360);
        iguanas[i].transform.Rotate(0, angle, 0);
    }

    private void OnDifficultyChanged(int newDifficulty)
    {
        Debug.Log("Scene.OnDifficultyChanged(" + newDifficulty + ")");
        for (int i = 0; i < enemies.Length; i++)
        {
            WanderingAI ai = enemies[i].GetComponent<WanderingAI>();
            ai.SetDifficulty(newDifficulty);
        }
    }

    public int GetDifficulty()
    {
        return PlayerPrefs.GetInt("difficulty", 1);
    }

    public int GetHealth()
    {
        return PlayerPrefs.GetInt("health", 1);
    }
}
