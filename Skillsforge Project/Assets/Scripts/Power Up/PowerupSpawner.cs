using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEditor.PlayerSettings;

public class PowerupSpawner : MonoBehaviour
{
    public ObjectPool<GameObject> pool;
    public GameObject powerUp;
    public Transform spawnPos;

    public float minSpawnTime = 3f;
    public float maxSpawnTime = 7f;
    private float spawnTime=3;
    private Vector3 pos;

    public float timeSec;
    private float timeMilli;


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
        Spawn();
        pos= spawnPos.position;
    }

    private void Update()
    {
        timeMilli += Time.deltaTime * 10;
        if (timeMilli > 10)
        {
            timeMilli = 0;
            timeSec += 1;
            if (timeSec > spawnTime)
            {
                Spawn();
                timeSec = 0;

                spawnTime = Random.Range(minSpawnTime,maxSpawnTime);
            }
        }

    }


    public void Spawn()
    {

        GameObject spawnee = pool.Get();
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


        //spawnPos.position += new Vector3(0, 0, 50);

    }
}


