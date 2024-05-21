using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [HideInInspector] public int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            DamageControl damageControl= other.GetComponent<DamageControl>();
            damageControl.TakeDamage(damage);

            

            FindObjectOfType<WeaponHandler>().bulletPool.Release(gameObject);

        }

        if(other.CompareTag("Boundary"))
        {
            FindObjectOfType<WeaponHandler>().bulletPool.Release(gameObject);
        }

        if (other.CompareTag("Boulder"))
        {
            BoulderDamageControl damageControl= other.GetComponent<BoulderDamageControl>();
            damageControl.TakeDamage(damage);
            FindObjectOfType<WeaponHandler>().bulletPool.Release(gameObject);
        }
    }
}
