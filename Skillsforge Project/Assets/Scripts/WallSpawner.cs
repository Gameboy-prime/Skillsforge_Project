using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class WallSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public ObjectPool<GameObject> pool;
    public GameObject block;
    public float rad=3f;

    public float timeSec;
    private float timeMilli;

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
        rad = 5 - (Difficulty.difficulty/2);
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
            if (timeSec > rad)
            {
                Spawn();
                timeSec = 0;
            }
        }
        
    }

}
