using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        //Inputs
        
       
        if (this.transform.position.x < Boundary.rightMove && Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(6, 0, 0));
            

        }
        if(this.transform.position.x> Boundary.leftMove && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-6,0,0));
            
        }
        
    }
}
