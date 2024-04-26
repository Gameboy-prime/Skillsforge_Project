using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CloneMultiplier : MonoBehaviour
{

    public static int playerNum;
    public static bool isDead;

    private int previousPlayerNum=0;
    public ObjectPool<GameObject> pool;
    

    public Transform playerSpawnPos;

    //Effects
    public GameObject playerSpawnEfffect;
    public GameObject playerDestroyEffect;

    //References
    public Animator anime;
    public WallSpawner wallSpawner;
    public GameObject playerClone;
    public GameObject player;
    public EnemySpawner enemySpawner;

    public List<GameObject> spawnList;

    
    private void Awake()
    {
        //Debug.Log("The clone Multiplayer script is working");
        pool = new ObjectPool<GameObject>(() =>
        {
            return Instantiate(playerClone);


        },
        obj =>
        {
            obj.gameObject.SetActive(true);
        },
        obj =>
        {
            obj.gameObject.SetActive(false);
        },
        obj =>
        {
            Destroy(obj.gameObject);
        }, false, 20, 25);

    }
    private void Start()
    {
        playerNum = 1;
        previousPlayerNum = 1;

        spawnList.Add(player);
    }



    private void OnTriggerEnter(Collider other)
    {
       // Debug.Log("has entered the instruction block");
        if (other.CompareTag("Instruction Block"))
        {
            //Debug.Log("has entered the instruction block");
            string determinant = other.GetComponent<Multiplier>().multiplierState;
            string[] instructionArray = determinant.Split(" ");

            //Get the operator for the instruction
            string opcode = instructionArray[0];
            string operand = instructionArray[1];
            if (instructionArray[0] == "*")
            {
                playerNum *= Convert.ToInt32(operand);
            }
            else if (instructionArray[0] == "+")
            {
                playerNum += Convert.ToInt32(operand);

            }
            else if (instructionArray[0] == "÷")
            {
                playerNum = (int)Mathf.Round(playerNum /= Convert.ToInt32(operand));
                

            }
            else if (instructionArray[0] == "-")
            {
                playerNum -= Convert.ToInt32(operand);
            }

            
            //SpawnPlayer(playerNum);

            if (playerNum <= 0)
            {
                isDead= true;
                playerNum = 0;
                Dying();
            }
            else
            {
                StartCoroutine(SpawnPlayer(playerNum));
            }

        }

        else if (other.CompareTag("Enemy"))
        {
            anime.Play("Stable Sword Outward Slash");
        }


    }

    public void Dying()
    {
        player.GetComponent<CapsuleCollider>().enabled= false;
        player.GetComponent<PlayerFight>().enabled = false;
        player.GetComponent<Movement>().enabled = false;
        anime.Play("Dying");
        wallSpawner.GetComponent<WallSpawner>().enabled = false;
        enemySpawner.GetComponent<EnemySpawner>().enabled = false;



    }

    IEnumerator SpawnPlayer(int num)
    {
        //Check to see if the previous number of player is greate that the current to determine whether or spawn or despawn
        int value = num - previousPlayerNum;
        if(value < 0)
        {
            for(int i=1;i<MathF.Abs(value)+1;i++)
            {
                //Debug.Log("The value of i is " + i);
                pool.Release(spawnList[spawnList.Count-1]);
                spawnList.RemoveAt(spawnList.Count-1);
                
                GameObject effect = Instantiate(playerDestroyEffect, spawnList[spawnList.Count - 1].transform.position, Quaternion.identity);
                Destroy(effect, .1f);
                yield return new WaitForSeconds(.1f);
               // Debug.Log("Has despawned Player");
            }
        }
        else
        {
            for (int i = 0; i < value ; i++)
            {
                Vector3 pos = new Vector3(UnityEngine.Random.Range(playerSpawnPos.position.x - 1.5f, playerSpawnPos.position.x + 2.8f), playerSpawnPos.position.y, UnityEngine.Random.Range(playerSpawnPos.position.z - .3f, 0));
                GameObject playerObj = pool.Get();
                spawnList.Add(playerObj);

                GameObject effect = Instantiate(playerSpawnEfffect, spawnList[i].transform.position, Quaternion.identity);
                Destroy(effect, .1f);
                playerObj.transform.position = pos;
                yield return new WaitForSeconds(.1f);

                //Debug.Log("Has spawned player");
            }
        }
        
        
        
        previousPlayerNum = playerNum;

    }

    
}
