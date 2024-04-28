using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float moveSpeed;    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Difficulty.difficulty *2.5f;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0 ,- 1)*moveSpeed*Time.deltaTime);
        
    }
}
