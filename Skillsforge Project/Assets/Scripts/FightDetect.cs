using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightDetect : MonoBehaviour
{
    CloneMultiplier multiplierReference;
    // Start is called before the first frame update
    void Start()
    {
        multiplierReference= GetComponentInParent<CloneMultiplier>();
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") && !CloneMultiplier.isDead)
        {
            Debug.Log("Has collided with the enemy");
            

            multiplierReference.anime.Play("Stable Sword Outward Slash");
        }

    }

    
}
