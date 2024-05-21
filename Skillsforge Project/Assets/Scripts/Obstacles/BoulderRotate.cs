using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderRotate : MonoBehaviour
{
    [SerializeField] private float rotSpeed;
    
    void Update()
    {
        transform.Rotate(-Vector3.right * rotSpeed, Space.Self);
    }
}
