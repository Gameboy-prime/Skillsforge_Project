using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public static float rightMove = 6f;
    public static float leftMove = -6f;
    public float internalLeft;
    public float internalRight;
    // Start is called before the first frame update
    void Start()
    {
        internalLeft = leftMove;
        internalRight = rightMove;
    }

    // Update is called once per frame
    void Update()
    {


    }
}
