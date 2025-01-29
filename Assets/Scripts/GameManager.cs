using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player player;

    public int currentWave = 0;            
    public int enemiesPerWave = 5;        
    public float timeBetweenWaves = 10f;   
    public float spawnDelay = 1f;
    public float spawnRadius = 20f;

    
    public GameObject[] enemyPrefab;          
    public GameObject boss;

    private bool isWaveActive = false;     
    private bool gameIsOver = false;       

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    private void Start()
    {
        TimeController.Instance.BeginTimer();
        StartNextWave();
    }


    void Update()
    {
        
      
    }

    public void StartNextWave()
    {
        currentWave++;
        isWaveActive = true;

        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        List<GameObject> enemies = ChooseEnemiesToSpawn(currentWave*5);
        for (int i = 0; i < enemies.Count; i++)
        {
            
            Vector3 randomPosition = GetRandomSpawnPosition();
            Instantiate(enemies[i], randomPosition, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }
        
        yield return new WaitForSeconds(timeBetweenWaves);


        EndWave();
    }


    private void EndWave()
    {
        isWaveActive = false;
        Debug.Log("Wave " + currentWave + " completed!");


        if (!gameIsOver)
        {
            StartNextWave();
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {

        
        float angle = Random.Range(0f, 2f * Mathf.PI);
       
        float distance = Random.Range(1f, spawnRadius);  
  
        Vector3 spawnPosition = new Vector3(
            player.transform.position.x + distance * Mathf.Cos(angle),  
            player.transform.position.y + distance * Mathf.Sin(angle), 0f 
                                                          );

        return spawnPosition;
    }

    public void EndGame()
    {
        gameIsOver = true;
        Debug.Log("Game Over!");
        SceneManager.LoadScene(0);

    }

    private List<GameObject> ChooseEnemiesToSpawn(int points)
    {
        List<GameObject> enemiesList = new List<GameObject>();
        while (points >= 0)
        {
            int randomNumber = Random.Range(0, 4);

            Enemy enemyRef = enemyPrefab[randomNumber].GetComponent<Enemy>();

            if (points >= enemyRef.cost )
            {
                enemiesList.Add(enemyPrefab[randomNumber]);
                points -= enemyRef.cost;
                Debug.Log("The enemy: " + enemyRef.name + " has been chosen, and it costs " + enemyRef.cost);
            }

            if(points <= 0)
            {
                break;
            }
        }
        
        return enemiesList;
    }

}
