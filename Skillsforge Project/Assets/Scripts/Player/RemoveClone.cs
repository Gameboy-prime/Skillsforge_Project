using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveClone : MonoBehaviour
{
    [SerializeField] int boulderDamage = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Clone"))
        {
            other.GetComponent<CloneDamageControl>().TakeDamage(boulderDamage);
        }
        else if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerDamageControl>().TakeDamage(boulderDamage);
        }
    }
}
