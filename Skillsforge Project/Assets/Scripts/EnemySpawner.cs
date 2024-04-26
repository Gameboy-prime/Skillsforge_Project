using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemySpawner : MonoBehaviour
{
    
    public GameObject enemy;
    public int enemyCount=20;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemySpawn()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for(int i=0; i<enemyCount; i++)
        {
            float rad = Random.Range(-3.5f, 3.5f);

            Instantiate(enemy, transform.position+ new Vector3(rad,0,0), Quaternion.identity);
            yield return new WaitForSeconds(.1f);
        }

    }
}
