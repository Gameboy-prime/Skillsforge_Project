using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool<GameObject> enemyPool_l;
    public ObjectPool<GameObject> enemyPool_2;
    public ObjectPool<GameObject> enemyPool_3;
    public ObjectPool<GameObject> enemyPool_4;

    public GameObject[] enemy;
    public int minEnemyCount=20;
    public int maxEnemyCount=30;

    public float spawnTime;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float elapsedTime;

    public static int EnemyDeadCount;
    
    // Start is called before the first frame update
    void Start()
    {
        /*if(SceneManager.GetActiveScene().buildIndex != 3)
        {
            enemyCount = (int)Difficulty.difficulty * 10;
        }*/
        #region EnemyPool1

        enemyPool_l = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[0]);
        },

        obj =>
        {
            obj.SetActive(true);
            obj.GetComponent<NavMeshAgent>().enabled = true;
            obj.GetComponent<EnemyMove>().enabled = true;
            obj.GetComponent<CapsuleCollider>().enabled = true;
        },

        obj =>
        {
            obj.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 200, 300);
        #endregion

        #region EnemyPool2

        enemyPool_2 = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[1]);
        },

        obj =>
        {
            obj.SetActive(true);
            obj.GetComponent<NavMeshAgent>().enabled = true;
            obj.GetComponent<EnemyMove>().enabled = true;
            obj.GetComponent<CapsuleCollider>().enabled = true;
        },

        obj =>
        {
            obj.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 200, 300);
        #endregion


        #region EnemyPool3
        enemyPool_3 = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[2]);
        },

        obj =>
        {
            obj.SetActive(true);
            obj.GetComponent<NavMeshAgent>().enabled = true;
            obj.GetComponent<EnemyMove>().enabled = true;
            obj.GetComponent<CapsuleCollider>().enabled = true;
        },

        obj =>
        {
            obj.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 200, 300);
        #endregion


        #region EnemyPool4
        enemyPool_4 = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(enemy[3]);
        },

        obj =>
        {
            obj.SetActive(true);
            obj.GetComponent<NavMeshAgent>().enabled = true;
            obj.GetComponent<EnemyMove>().enabled = true;
            obj.GetComponent<CapsuleCollider>().enabled = true;
        },

        obj =>
        {
            obj.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 200, 300);
        #endregion



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
        for (int i = 0; i < enemyCount; i++)
        {
            float rad = Random.Range(-6f, 6f);

            if (Difficulty.difficulty < 5)
            {

                int radom = Random.Range(0, 2);
                if (radom == 0)
                {
                    GameObject enemyObject = enemyPool_l.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);

                }
                else if (radom == 1)
                {
                    GameObject enemyObject = enemyPool_4.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                yield return new WaitForSeconds(1f);
            }
            else if (Difficulty.difficulty > 4 && Difficulty.difficulty < 9)
            {
                int radom = Random.Range(0, 3);
                if (radom == 0)
                {
                    GameObject enemyObject = enemyPool_l.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);

                }
                else if (radom == 1)
                {
                    GameObject enemyObject = enemyPool_2.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (radom == 2)
                {
                    GameObject enemyObject = enemyPool_4.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                yield return new WaitForSeconds(1);
            }
            else if (Difficulty.difficulty > 8)
            {
                int radom = Random.Range(0, 4);
                if (radom == 0)
                {
                    GameObject enemyObject = enemyPool_l.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);

                }
                else if (radom == 1)
                {
                    GameObject enemyObject = enemyPool_2.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (radom == 2)
                {
                    GameObject enemyObject = enemyPool_3.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
                else if (radom == 4)
                {
                    GameObject enemyObject = enemyPool_4.Get();
                    enemyObject.transform.position = transform.position + new Vector3(rad, 0, 0);
                    enemyObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                }

                yield return new WaitForSeconds(1);


            }
        }

    }
}
