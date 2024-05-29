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
    public BulletType bulletType;
    
    private void OnTriggerEnter(Collider other)
    {//
        //Debug.Log("The Bullet has entered a trigger");
        if (other.CompareTag("enemy"))
        {
            //Debug.Log("It Has collided with enemy");
            DamageControl damageControl= other.GetComponent<DamageControl>();
            damageControl.TakeDamage(damage);


                if (bulletType == BulletType.TypeA)
                {
                    WeaponHandler.bulletPools[0].Release(this.gameObject);
                }
                else if(bulletType== BulletType.TypeB)
                {
                    WeaponHandler.bulletPools[1].Release(this.gameObject);
                }
                else if (bulletType == BulletType.TypeC)
                {
                    WeaponHandler.bulletPools[2].Release(this.gameObject);
                }
                else if (bulletType == BulletType.TypeD)
                {
                    WeaponHandler.bulletPools[3].Release(this.gameObject);
                }


        }

        else if (other.CompareTag("Boundary"))
        {

            if (bulletType == BulletType.TypeA)
            {
                WeaponHandler.bulletPools[0].Release(this.gameObject);
            }
            else if (bulletType == BulletType.TypeB)
            {
                WeaponHandler.bulletPools[1].Release(this.gameObject);
            }
            else if (bulletType == BulletType.TypeC)
            {
                WeaponHandler.bulletPools[2].Release(this.gameObject);
            }
            else if (bulletType == BulletType.TypeD)
            {
                WeaponHandler.bulletPools[3].Release(this.gameObject);
            }

            /* if (bulletType == BulletType.TypeA)
             {
                 Debug.Log("THe bullet type that was released is the type A");
                 WeaponHandler.Instance.GetBulletPool(0).Release(gameObject);
             }
             else if (bulletType == BulletType.TypeB)
             {
                 WeaponHandler.Instance.GetBulletPool(1).Release(gameObject);
             }
             else if (bulletType == BulletType.TypeC)
             {
                 WeaponHandler.Instance.GetBulletPool(2).Release(gameObject);
             }
             else if (bulletType == BulletType.TypeD)
             {
                 WeaponHandler.Instance.GetBulletPool(3).Release(gameObject);
             }*/
        }

        if (other.CompareTag("Boulder"))
        {
            //Debug.Log("It has collided with Boulder");
            BoulderDamageControl damageControl= other.GetComponent<BoulderDamageControl>();
            damageControl.TakeDamage(damage);


            if (bulletType == BulletType.TypeA)
            {
                WeaponHandler.bulletPools[0].Release(this.gameObject);
            }
            else if (bulletType == BulletType.TypeB)
            {
                WeaponHandler.bulletPools[1].Release(this.gameObject);
            }
            else if (bulletType == BulletType.TypeC)
            {
                WeaponHandler.bulletPools[2].Release(this.gameObject);
            }
            else if (bulletType == BulletType.TypeD)
            {
                WeaponHandler.bulletPools[3].Release(this.gameObject);
            }
        }
    }
}
