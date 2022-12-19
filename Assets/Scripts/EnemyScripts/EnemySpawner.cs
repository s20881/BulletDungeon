using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get { return _instance; } }

    [SerializeField] private GameObject dronePrefab;
    [SerializeField] private GameObject robotPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private GameObject bossHealthBarPrefab;
    [SerializeField] private GameData gameData;
    private Transform worldSpaceCanvas;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
            _instance = this;
    }
    private void Start()
    {
        worldSpaceCanvas = GameObject.Find("WorldSpaceCanvas").transform;
    }

    public void Spawn(EnemyType type, Vector3 position)
    {
        GameObject enemy = null;
        GameObject healthBar = null;
        if(type == EnemyType.Drone)
        {
            enemy = Instantiate(dronePrefab, position, Quaternion.identity);
            healthBar = Instantiate(healthBarPrefab, worldSpaceCanvas);
            
        }
        else if(type == EnemyType.Robot)
        {
            enemy = Instantiate(robotPrefab, position, Quaternion.identity);
            healthBar = Instantiate(healthBarPrefab, worldSpaceCanvas);
        }
        else if(type == EnemyType.Boss)
        {
            enemy = Instantiate(bossPrefab, position, Quaternion.identity);
            healthBar = Instantiate(bossHealthBarPrefab, worldSpaceCanvas);
        }
        if(enemy != null && healthBar != null)
        {
            healthBar.GetComponent<EnemyHealthBar>().enemy = enemy.GetComponent<Health>();
            enemy.GetComponent<Health>().damageReceivedMultiplier = gameData.levelenem;
        }
    }

    [ContextMenu("Spawn/Drone")]
    private void SpawnDrone()
    {
        Spawn(EnemyType.Drone, GameObject.FindGameObjectWithTag("Player").transform.position);
    }
    [ContextMenu("Spawn/Robot")]
    private void SpawnRobot()
    {
        Spawn(EnemyType.Robot, GameObject.FindGameObjectWithTag("Player").transform.position);
    }
    [ContextMenu("Spawn/Boss")]
    private void SpawnBoss()
    {
        Spawn(EnemyType.Boss, GameObject.FindGameObjectWithTag("Player").transform.position);
    }
}
