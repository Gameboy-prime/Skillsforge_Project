using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TutorialWallSpawner : MonoBehaviour
{
    public Transform spawnPos;
    public ObjectPool<GameObject> pool;
    
    public float rad = 3f;

    public float timeSec;
    private float timeMilli;

    public List<GameObject> BlockList;
    int index;

    // Start is called before the first frame update
    void Awake()
    {
        



    }




    public void Spawn()
    {
        //SpawnTime();
        GameObject spawnee = BlockList[index];
        spawnee.SetActive(true);
        spawnee.transform.position = spawnPos.position;
        spawnee.transform.rotation = Quaternion.identity;
        index++;
        if(index>= BlockList.Count)
        {
            index= 0;
        }

    }

    



    private void Start()
    {
        
        Spawn();
        //InvokeRepeating(nameof(Spawn), rad, rad);
    }

    private void Update()
    {
        timeMilli += Time.deltaTime * 10;
        if (timeMilli > 10)
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
