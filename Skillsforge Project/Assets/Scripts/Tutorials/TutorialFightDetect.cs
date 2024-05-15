using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFightDetect : MonoBehaviour
{
    TutorialCloneMultiplier multiplierReference;
    // Start is called before the first frame update
    void Start()
    {
        multiplierReference = GetComponentInParent<TutorialCloneMultiplier>();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy") )
        {
            FindObjectOfType<TutorialEndGame>().CheckPlayer();
            Debug.Log("Has collided with the enemy");
            multiplierReference.fightClip.Play();

            multiplierReference.anime.Play("Stable Sword Outward Slash");
        }

    }
}
