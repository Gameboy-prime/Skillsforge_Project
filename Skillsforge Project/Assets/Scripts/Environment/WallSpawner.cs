using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class WallSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public ObjectPool<GameObject> pool;
    public GameObject block;
    

    private float timeSec;
    private float timeMilli;

    [SerializeField] float spawnTime=8;
    [SerializeField] float minSpawnTime=15;
    [SerializeField] float maxSpawnTime=25;



    // Start is called before the first frame update
    void Awake()
    {
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(block);


        },
        obj =>
        {
            obj.gameObject.SetActive(true);
            obj.gameObject.GetComponentInChildren<Multiplier>().CallDeterminatState();
        },
        obj =>
        {
            obj.gameObject.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, false, 10, 15);
            

        
    }

    


    public void Spawn()
    {
        //SpawnTime();
        GameObject spawnee = pool.Get();
        spawnee.transform.position = spawnPos.position;
        spawnee.transform.rotation = Quaternion.identity;


        //spawnPos.position += new Vector3(0, 0, 50);

    }

    public void DespawnBlock(GameObject blockObject)
    {
        pool.Release(blockObject);

    }

    

    private void Start()
    {
        
        Spawn();
        //InvokeRepeating(nameof(Spawn), rad, rad);
    }

    private void Update()
    {
        timeMilli+= Time.deltaTime*10;
        if(timeMilli>10)
        {
            timeMilli = 0;
            timeSec += 1;
            if (timeSec > spawnTime)
            {
                Spawn();
                timeSec = 0;
                spawnTime= UnityEngine.Random.Range(minSpawnTime,maxSpawnTime);
            }
        }
        
    }

}
