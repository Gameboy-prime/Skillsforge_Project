using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    

    void Update()
    {
        transform.Translate(new Vector3(0, 0, -1) * moveSpeed * Time.deltaTime);
        
    }
}
