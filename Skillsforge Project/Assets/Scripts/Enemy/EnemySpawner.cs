using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;
    public int minEnemyCount=20;
    public int maxEnemyCount=30;

    public float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float elapsedTime;

    
    // Start is called before the first frame update
    void Start()
    {
        /*if(SceneManager.GetActiveScene().buildIndex != 3)
        {
            enemyCount = (int)Difficulty.difficulty * 10;
        }*/

        elapsedTime = minSpawnTime;
        

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime-= Time.deltaTime;

        if (elapsedTime < 0)
        {
            StartCoroutine(SpawnEnemy());
            spawnTime=  Random.Range(minSpawnTime, maxSpawnTime);
            elapsedTime = spawnTime;
        }
    }

    public void EnemySpawn()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        int enemyCount = Random.Range(minEnemyCount, maxEnemyCount);
        for(int i=0; i<enemyCount; i++)
        {
            float rad = Random.Range(-3.5f, 3.5f);

            Instantiate(enemy, transform.position+ new Vector3(rad,0,0), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }

    }
}
