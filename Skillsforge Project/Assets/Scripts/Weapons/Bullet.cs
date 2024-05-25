using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage;
    public enum BulletType
    {
        TypeA, TypeB, TypeC, TypeD
    }
    [HideInInspector] public BulletType bulletType;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            DamageControl damageControl= other.GetComponent<DamageControl>();
            damageControl.TakeDamage(damage);


            if (bulletType == BulletType.TypeA)
            {
                FindObjectOfType<WeaponHandler>().bulletPool1.Release(gameObject);
            }
            else if(bulletType== BulletType.TypeB)
            {
                FindObjectOfType<WeaponHandler>().bulletPool2.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeC)
            {
                FindObjectOfType<WeaponHandler>().bulletPool3.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeD)
            {
                FindObjectOfType<WeaponHandler>().bulletPool4.Release(gameObject);
            }


        }

        if(other.CompareTag("Boundary"))
        {
            if (bulletType == BulletType.TypeA)
            {
                FindObjectOfType<WeaponHandler>().bulletPool1.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeB)
            {
                FindObjectOfType<WeaponHandler>().bulletPool2.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeC)
            {
                FindObjectOfType<WeaponHandler>().bulletPool3.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeD)
            {
                FindObjectOfType<WeaponHandler>().bulletPool4.Release(gameObject);
            }
        }

        if (other.CompareTag("Boulder"))
        {
            BoulderDamageControl damageControl= other.GetComponent<BoulderDamageControl>();
            damageControl.TakeDamage(damage);
            if (bulletType == BulletType.TypeA)
            {
                FindObjectOfType<WeaponHandler>().bulletPool1.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeB)
            {
                FindObjectOfType<WeaponHandler>().bulletPool2.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeC)
            {
                FindObjectOfType<WeaponHandler>().bulletPool3.Release(gameObject);
            }
            else if (bulletType == BulletType.TypeD)
            {
                FindObjectOfType<WeaponHandler>().bulletPool4.Release(gameObject);
            }
        }
    }
}
