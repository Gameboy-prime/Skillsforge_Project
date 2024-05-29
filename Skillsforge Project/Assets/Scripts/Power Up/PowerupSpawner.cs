using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


public class PowerupSpawner : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject powerUp;
    public Transform spawnPos;

    public float minSpawnTime = 3f;
    public float maxSpawnTime = 7f;
    private float spawnTime=3;
    private Vector3 pos;

    private float elapsedTime;

    private int counter;

    private void Awake()
    {
        pool = new ObjectPool<GameObject>(() =>

        {
            return Instantiate(powerUp);
        },
        obj =>
        {
            obj.SetActive(true);
            obj.GetComponent<PowerUp>().Activate();
            obj.GetComponent<SphereCollider>().enabled = true;
            BoulderDamageControl control = obj.GetComponent<BoulderDamageControl>();
            control.sphere.SetActive(true);
            control.currentHealth = control.health;
        },
        obj =>
        {
            obj.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, true, 10, 15);
    }

    private void Start()
    {
        counter = 0;
        pos = spawnPos.position;
        elapsedTime = spawnTime;
        
        
    }

    private void Update()
    {
        elapsedTime-=Time.deltaTime;
        if (elapsedTime < 0)
        {
            Spawn();
            spawnTime=Random.Range(minSpawnTime, maxSpawnTime);
            elapsedTime = spawnTime;
        }
        

        //Debug.Log($"THe Quality Level is {QualitySettings.GetQualityLevel()}");

    }


    private void Spawn()
    {
        counter += 1;

        
        /*spawnee.transform.position = spawnPos.position;
        spawnee.transform.rotation = Quaternion.identity;*/
        //SpawnTime();
        
        int rad = Random.Range(0, 2);
        if (rad == 0)
        {
            pos.x = spawnPos.position.x - 6;
        }

        else if (rad == 1)
        {
            pos.x = spawnPos.position.x + 6;
        }

        GameObject spawnee = pool.Get();

        spawnee.transform.position = pos;
        spawnee.transform.rotation = Quaternion.identity;



        //Reset the effect of modifying the position
        if (rad == 0)
        {
            pos.x = spawnPos.position.x + 6;
        }
        else if (rad == 1)
        {
            pos.x = spawnPos.position.x - 6;
        }

        Debug.Log($"The counter is {counter}");
        //spawnPos.position += new Vector3(0, 0, 50);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boulder"))
        {
            pool.Release(other.gameObject);
        }
        {

        }
    }
}


