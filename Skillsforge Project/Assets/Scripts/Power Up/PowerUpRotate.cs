using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpRotate : MonoBehaviour
{
    [SerializeField] float rotSpeed=10;
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up* rotSpeed, Space.World);
        
    }
}
